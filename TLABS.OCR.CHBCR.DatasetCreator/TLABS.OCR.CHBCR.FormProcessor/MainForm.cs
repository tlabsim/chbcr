using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLABS.Extensions;
using TLABS.OCR.CHBCR.Common;

namespace TLABS.OCR.CHBCR.FormProcessor
{
    public partial class MainForm : Form
    {
        int RowsPerPage = 15;
        int ColumnsPerPage = 14;
        int ColumnSpanPerCharacter = 2;

        bool GuessBounds = false;
        bool IsBoundGuessed = false;

        double DPI = 300;
        double PageWidthInInches = 8.27;
        double PageHeightInInches = 11.69;
        double HorizontalPageMarginInInches = 0.1;
        double VerticalPageMarginInInches = 0.1;
        double ColumnWidthInInches = 0.5;
        double RowHeightInInches = 0.5;
        double LabelBoxHeightInInches = 0.2;
        int LetterCropMargin = 5;
        double SkewToleranceDueToScanError = double.MaxValue;


        int PageWidth { get { return (int)(PageWidthInInches * DPI); } }
        int PageHeight { get { return (int)(PageHeightInInches * DPI); } }
        int HorizontalPageMargin { get { return (int)(HorizontalPageMarginInInches * DPI); } }
        int VerticalPageMargin { get { return (int)(VerticalPageMarginInInches * DPI); } }
        int ColumnWidth { get { return (int)(this.ColumnWidthInInches * DPI); } }
        int RowHeight { get { return (int)(RowHeightInInches * DPI); } }
        int LabelBoxHeight { get { return (int)(LabelBoxHeightInInches * DPI); } }
        int HeaderPanelHeight { get { return (int)(0.3 * DPI); } }

        int ScannerMarginLeft = 0, ScannerMarginTop = 0;

        float ThickLineWidth = 2;
        float ThinLineWidth = 1;
        string LabelFont = "Vrinda";
        float LabelFontSize = -1; //Auto

        ConfigFileReader ConfigFileReader;

        List<FileInfo> FormScans = new List<FileInfo>();
        List<Bitmap> ScanThumbnails = new List<Bitmap>();
        Dictionary<Bitmap, PictureBox> ThumbPictureBoxes = new Dictionary<Bitmap, PictureBox>();

        FileInfo CurrentProcessingFile;
        Bitmap CurrentProcessing;

        string ScanFolder = string.Empty;
        string OutputFolder = string.Empty;
        string OutputGuessedFolder = string.Empty;
        string DoneFolder = string.Empty;
        string DoneGuessedFolder = string.Empty;
        string FailedFolder = string.Empty;
        string LogFolder = string.Empty;
        string Logfile = "";

        bool SignalledToStop = false;

        Random RNG = new Random();        

        public MainForm()
        {
            InitializeComponent();

            this.ConfigFileReader = new ConfigFileReader("configs.txt");
            LoadConfigs();
        }

        void ImageProcessingTest()
        {
            string file = "test.jpg";

            if (File.Exists(file))
            {
                Bitmap bmp = (Bitmap)Image.FromFile(file);
                bmp.Show();

                BitmapProcessor bmpp = new BitmapProcessor(bmp);
                bmpp.Background = Color.Red;
                bmpp.AdjustGamma(1.1).Resize(0.5);
                bmpp.Show();
                bmpp.Rotate(25, false);
                bmpp.Show();
                bmpp.FlipHorizontal();
                bmpp.Show();
                bmpp.FlipVertical();
                bmpp.Show();
            }
        }

        void SelectScanFolder()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;
            var dr = FBD.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.Cancel)
            {
                tbSelectedFolder.Text = FBD.SelectedPath;
            }
        }

        void GetFormScans()
        {
            FormScans.Clear();
            ScanThumbnails.Clear();
            flpThumbnails.Controls.Clear();

            string selected_folder_path = tbSelectedFolder.Text.Trim();
            if (string.IsNullOrEmpty(selected_folder_path))
            {

                ShowError("Select the folder to process");
            }
            else if (!Directory.Exists(selected_folder_path))
            {
                ShowError("Selected folder does not exist");
                return;
            }

            this.ScanFolder = selected_folder_path;
            this.OutputFolder = selected_folder_path.TrimEnd('\\') + @"\output\";
            this.OutputGuessedFolder = selected_folder_path.TrimEnd('\\') + @"\output_guessed\";
            this.DoneFolder = selected_folder_path.TrimEnd('\\') + @"\done\";
            this.DoneGuessedFolder = selected_folder_path.TrimEnd('\\') + @"\done_guessed\";
            this.FailedFolder = selected_folder_path.TrimEnd('\\') + @"\failed\";
            this.LogFolder = selected_folder_path.TrimEnd('\\') + @"\log\";

            var files = Directory.GetFiles(selected_folder_path, "*.jpg");
            if (files.Length > 0)
            {
                foreach (var file in files)
                {
                    try
                    {
                        FileInfo fi = new FileInfo(file);
                        if (fi.Exists && fi.Extension.ToLower() == ".jpg")
                        {
                            using (Bitmap thumb = (Bitmap)Image.FromFile(fi.FullName))
                            {

                                ScanThumbnails.Add(thumb.Resize(300.0 / thumb.Height));
                            }

                            FormScans.Add(fi);
                        }
                    }
                    catch { }
                }

                if (ScanThumbnails.Count > 0)
                {
                    ThumbnailPanel.Visible = true;

                    foreach (var thumb in ScanThumbnails)
                    {
                        PictureBox pb = new PictureBox();
                        pb.Width = 150;
                        pb.Height = 150 * (thumb.Height / thumb.Width);
                        pb.Margin = new Padding(5, 5, 5, 5);
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Image = thumb;

                        flpThumbnails.Controls.Add(pb);
                        ThumbPictureBoxes.Add(thumb, pb);
                    }
                }
                else
                {
                    ThumbnailPanel.Visible = false;
                }
            }
            else
            {
                ShowError("No forms found in the selected folder");
            }
        }

        async void ProcessScannedForms()
        {
            // Steps:
            // 0. Load config
            // 1: Get JPEG files in the folder as bitmap
            // 2. Read config
            // 3. For each Bitmap
            //    3.1 Preprocess (Crop + Adjust brighness + Adjust contrast)
            //    3.2 Get key points
            //    3.3 Rotate
            //    3.4 Crop again
            //    3.5 Canculate each char position    
            
            CurrentProcessing = null;
            picCurrentLarge.Image = null;
            picCurrentSmall.Image = null;

            nudFormNo.Enabled = false;
            btnLoad.Enabled = false;
            btnStartScanning.Enabled = false;
            btnSignalToStop.Visible = true;
            btnSignalToStop.Text = "Signal to stop";
            CurrentScanInfoPanel.Visible = true;

            if (FormScans.Count > 0)
            {
                if (!Directory.Exists(this.OutputFolder))
                {
                    Directory.CreateDirectory(this.OutputFolder);
                }
                if (GuessBounds && !Directory.Exists(this.OutputGuessedFolder))
                {
                    Directory.CreateDirectory(this.OutputGuessedFolder);
                }
                if (!Directory.Exists(this.DoneFolder))
                {
                    Directory.CreateDirectory(this.DoneFolder);
                }
                if (GuessBounds && !Directory.Exists(this.DoneGuessedFolder))
                {
                    Directory.CreateDirectory(this.DoneGuessedFolder);
                }
                if (!Directory.Exists(this.FailedFolder))
                {
                    Directory.CreateDirectory(this.FailedFolder);
                }
                if (!Directory.Exists(this.LogFolder))
                {
                    Directory.CreateDirectory(this.LogFolder);
                }

                this.Logfile = this.LogFolder.TrimEnd('\\') + @"\log_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";  

                btnSignalToStop.Visible = true;
                this.SignalledToStop = false;
                btnSignalToStop.Enabled = true;

                for (int i = 0; i < FormScans.Count; i++)
                {
                    if (this.SignalledToStop) break;

                    await Task.Run(() => { ExtractFromFileAsync(i); });
                }
            }
                        
            nudFormNo.Enabled = true;
            btnLoad.Enabled = true;
            btnStartScanning.Enabled = true;
            btnSignalToStop.Visible = false;
            CurrentScanInfoPanel.Visible = false;

            MessageBox.Show("Form processing completed", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        void ExtractFromFileAsync(int i)
        {
            bool error = false;

            this.Invoke((MethodInvoker)delegate() { labSl.Text = string.Format("{0}/{1}", i + 1, FormScans.Count); });

            FileInfo fi = FormScans[i];
            Bitmap thumb = ScanThumbnails[i];

            Log("Processing started: " + fi.FullName);

            //Highlight the current thumbnail
            this.Invoke((MethodInvoker)delegate()
            {
                if (ThumbPictureBoxes.ContainsKey(thumb))
                {
                    PictureBox pb = ThumbPictureBoxes[thumb];
                    pb.Padding = new Padding(10, 10, 10, 10);
                    pb.BackColor = Color.Blue;
                }
            });

            CurrentProcessingFile = fi;

            error = ProcessFile(fi);

            if (error)
            {
                //Move to failed folder
                try
                {
                    fi.MoveTo(this.FailedFolder + fi.Name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //Move to done folder
                try
                {
                    if(!IsBoundGuessed)
                    {
                        fi.MoveTo(this.DoneFolder + fi.Name);
                    }
                    else
                    {
                        fi.MoveTo(this.DoneGuessedFolder + fi.Name);
                    }                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            this.Invoke((MethodInvoker)delegate()
            {
                if (ThumbPictureBoxes.ContainsKey(thumb))
                {
                    PictureBox pb = ThumbPictureBoxes[thumb];
                    pb.Padding = new Padding(5, 5, 5, 5);
                    if (error)
                    {
                        pb.BackColor = Color.Red;
                    }
                    else
                    {
                        pb.BackColor = Color.Green;
                    }
                }
            });
        }

        /// <summary>
        /// Returns true if an error is occurred
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        bool ProcessFile(FileInfo file)
        {
            bool ERROR = false;

            using (Bitmap bmp = (Bitmap)Image.FromFile(file.FullName))
            {
                CurrentProcessing = bmp;

                this.Invoke((MethodInvoker)delegate()
                {
                    picCurrentLarge.Image = CurrentProcessing;
                    picCurrentSmall.Image = CurrentProcessing;
                    this.Refresh();
                });

                using (BitmapProcessor bmpp = new BitmapProcessor(CurrentProcessing))
                {

                    ShowProgress("Pre-processing form...", 0);

                    PreProcessImage(bmpp);

                    ShowProgress("Pre-processing done...", 5);

                    PointF tl, tr, dl, dr;
                    ERROR = StraightenAndGetBounds(out tl, out tr, out dl, out dr);
                    if (ERROR) return ERROR;

                    Rectangle roi = new Rectangle();
                    roi.X = (int)Math.Round(tl.X);
                    roi.Y = (int)Math.Round(tl.Y);
                    roi.Width = (int)(Math.Round((tr.X - tl.X + dr.X - dl.X) / 2.0));
                    roi.Height = (int)(Math.Round((dl.Y - tl.Y + dr.Y - tr.Y) / 2.0));

                    ERROR = CropLetters(roi);
                }

                if(CurrentProcessing != null)
                {
                    picCurrentLarge.Image = null;
                    picCurrentSmall.Image = null;

                    Bitmap tmp_bmp = CurrentProcessing;
                    tmp_bmp.Dispose();
                }

                CurrentProcessing = null;
            }

            return ERROR;
        }

        void PreProcessImage(BitmapProcessor bmpp)
        {
            bmpp.AdjustContrast(50);

            this.Invoke((MethodInvoker)delegate()
            {
                picCurrentLarge.Image = CurrentProcessing;
                this.Refresh();
            });
        }

        /// <summary>e
        /// Gets ROI, returns true if an error occurrs
        /// </summary>
        /// <param name="tl"></param>
        /// <param name="tr"></param>
        /// <param name="dl"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        bool StraightenAndGetBounds(out PointF tl, out PointF tr, out PointF dl, out PointF dr)
        {
            bool ERROR = true;
            bool DEBUG = true;

            IsBoundGuessed = false;

            int page_width_minus_margin = this.PageWidth - this.HorizontalPageMargin * 2;
            int page_height_minus_margin = this.PageHeight - this.VerticalPageMargin * 2;

            int box_width = this.ColumnWidth;
            int box_height = this.RowHeight;
            int label_box_height = this.LabelBoxHeight;

            int header_panel_height = this.HeaderPanelHeight;

            int total_width = box_width * ColumnsPerPage;
            int total_grid_height = (box_height + label_box_height) * RowsPerPage;
            int total_height = total_grid_height + header_panel_height;
            int left_whitespace_to_remove = 0;
            int allowed_extra_ws = 0; // (int)(DPI * .05);
            
            if (total_width > page_width_minus_margin || total_height > page_height_minus_margin)
            {
                ShowError("Form size exceeds page size");

                tl = new PointF(0, 0);
                tr = new PointF(0, 0);
                dl = new PointF(0, 0);
                dr = new PointF(0, 0);

                LogError("Form size exceeds page size");
                return ERROR;
            }

            int margin_left = 0, margin_top = 0, margin_right = 0, margin_bottom = 0;
            margin_left = (page_width_minus_margin - total_width) / 2;
            margin_top = (page_height_minus_margin - total_height) / 2 + header_panel_height;
            margin_right = page_width_minus_margin - margin_left;
            margin_bottom = page_height_minus_margin - margin_top;            

            Rectangle likely_bound = new Rectangle(margin_left, margin_top, margin_right - margin_left, margin_bottom - margin_top);

            PointF
                ltl = new PointF(likely_bound.Left, likely_bound.Top),
                ltr = new PointF(likely_bound.Right, likely_bound.Top),
                ldl = new PointF(likely_bound.Left, likely_bound.Bottom),
                ldr = new PointF(likely_bound.Right, likely_bound.Bottom);

            tl = ltl;
            tr = ltr;
            dl = ldl;
            dr = ldr;

            #region Initial straightening
            {
                try
                {
                    ShowProgress("Straightening form...");

                    int likely_height = (likely_bound.Bottom - likely_bound.Top);

                    int scan_points = 2, scan_gap = 1;
                    int[] scan_ys = new int[scan_points];
                    int[] out_xs = new int[scan_points]; // Output of scanning

                    scan_ys[0] = (int)(this.PageHeight / 3.0);
                    scan_ys[1] = (int)(this.PageHeight * 2.0 / 3.0);

                    int likely_xs = this.HorizontalPageMargin + this.ScannerMarginLeft + margin_left;

                    out_xs[0] = likely_xs;
                    out_xs[1] = likely_xs;

                    int scan_lines = 50, max_x = likely_xs * 2;
                    List<int> scan_ends = new List<int>();

                    for (int sp = 0; sp < scan_points; sp++)
                    {
                        scan_ends.Clear();
                        for (int sy = 0; sy < scan_lines / 2; sy++)
                        {
                            int sy1 = scan_ys[sp] - ((scan_gap + 1) * sy + 1),
                                sy2 = scan_ys[sp] + ((scan_gap + 1) * sy + 1);

                            int blacks_sy1 = 0;
                            for (int sx = 0; sx < max_x; sx++)
                            {
                                Color c = CurrentProcessing.GetPixel(sx, sy1);
                                if (c.IsBlackish())
                                {
                                    blacks_sy1++;
                                    if (blacks_sy1 >= 3)
                                    {
                                        scan_ends.Add(sx);
                                        break;
                                    }
                                }
                                else
                                {
                                    blacks_sy1 = 0; // Reset
                                }
                                if (DEBUG) CurrentProcessing.SetPixel(sx, sy1, Color.Red);
                            }

                            int blacks_sy2 = 0;
                            for (int sx = 0; sx < max_x; sx++)
                            {
                                Color c = CurrentProcessing.GetPixel(sx, sy2);
                                if (c.IsBlackish())
                                {
                                    blacks_sy2++;
                                    if (blacks_sy2 >= 3)
                                    {
                                        scan_ends.Add(sx);
                                        break;
                                    }
                                }
                                else
                                {
                                    blacks_sy2 = 0; // Reset
                                }
                                if (DEBUG) CurrentProcessing.SetPixel(sx, sy1, Color.Red);
                            }
                        }

                        out_xs[sp] = (int)(Math.Round(GetMean(scan_ends)));
                    }

                    double x_diff = out_xs[1] - out_xs[0];
                    if (x_diff != 0) // Skewed
                    {
                        double y_diff = scan_ys[1] - scan_ys[0];
                        var skew_angle = RadianToDegree(Math.Atan(x_diff / y_diff));

                        CurrentProcessing = CurrentProcessing.Rotate(new Point(0, 0), skew_angle);

                        this.Invoke((MethodInvoker)delegate()
                        {
                            picCurrentLarge.Image = CurrentProcessing;
                            this.Refresh();
                        });
                    }

                    int outxs_avg = (int)((out_xs[1] + out_xs[0]) / 2);                    
                    if(outxs_avg > (this.HorizontalPageMargin + this.ScannerMarginLeft + margin_left + allowed_extra_ws))
                    {
                        left_whitespace_to_remove = outxs_avg - this.HorizontalPageMargin - this.ScannerMarginLeft - margin_left - allowed_extra_ws;
                        if(left_whitespace_to_remove < 0) left_whitespace_to_remove = 0;                        
                    }                    

                    ShowProgress("Straightening done...", 10);
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                    return ERROR;
                }
            }
            #endregion

            //Remove excess part of the scan            
            CurrentProcessing = CurrentProcessing.Crop(this.HorizontalPageMargin + this.ScannerMarginLeft + left_whitespace_to_remove, this.VerticalPageMargin + this.ScannerMarginTop, page_width_minus_margin + allowed_extra_ws * 2, page_height_minus_margin + allowed_extra_ws * 2);

            this.Invoke((MethodInvoker)delegate()
            {
                picCurrentLarge.Image = CurrentProcessing;
                this.Refresh();
            });

            PointF[] hit_points = new PointF[8];
            #region Get bounds
            {
                ShowProgress("Getting bounds...");

                int width = CurrentProcessing.Width,
                    height = CurrentProcessing.Height;

                int x, y, blacks, endx, endy, scan_gap = 0;
                List<int> scan_ends = new List<int>();
                List<int> hit_ats = new List<int>();

                #region Top left
                // tl.X
                {
                    endx = likely_bound.Left * 2;
                    endy = likely_bound.Top * 2;
                    scan_ends.Clear();
                    hit_ats.Clear();

                    for (y = 0; y < endy; y += (1 + scan_gap))
                    {
                        blacks = 0;
                        for (x = 0; x < endx; x++)
                        {
                            Color c = CurrentProcessing.GetPixel(x, y);
                            if (c.IsBlackish())
                            {
                                blacks++;
                                if (blacks >= 3)
                                {
                                    scan_ends.Add(x - 2);
                                    hit_ats.Add(y);
                                    break;
                                }
                            }
                            else blacks = 0;
                            if (DEBUG) CurrentProcessing.SetPixel(x, y, Color.Red);
                        }
                        if (scan_ends.Count >= 20) break;
                    }
                    if (scan_ends.Count < 10)
                    {
                        LogError("Could not get tl.X");
                        return ERROR;
                    }

                    hit_points[0] = new PointF((float)GetMean(scan_ends), (float)GetMean(hit_ats));
                    tl.X = hit_points[0].X;
                }

                // tl.Y
                {
                    endx = likely_bound.Left * 2;
                    endy = likely_bound.Top * 2;
                    scan_ends.Clear();
                    hit_ats.Clear();

                    for (x = 0; x < endx; x += (1 + scan_gap))
                    {
                        blacks = 0;
                        for (y = 0; y < endy; y++)
                        {
                            Color c = CurrentProcessing.GetPixel(x, y);
                            if (c.IsBlackish())
                            {
                                blacks++;
                                if (blacks >= 3)
                                {
                                    scan_ends.Add(y - 2);
                                    hit_ats.Add(x);
                                    break;
                                }
                            }
                            else blacks = 0;
                            if (DEBUG) CurrentProcessing.SetPixel(x, y, Color.Red);
                        }
                        if (scan_ends.Count >= 20) break;
                    }
                    if (scan_ends.Count < 10)
                    {
                        LogError("Could not get tl.Y");
                        return ERROR;
                    }

                    hit_points[1] = new PointF((float)GetMean(hit_ats), (float)GetMean(scan_ends));
                    tl.Y = hit_points[1].Y;
                }
                #endregion

                #region Top Right
                // tr.X
                {
                    endx = width - (width - likely_bound.Right) * 2;
                    endy = likely_bound.Top * 2;
                    scan_ends.Clear();
                    hit_ats.Clear();

                    for (y = 0; y < endy; y += (1 + scan_gap))
                    {
                        blacks = 0;
                        for (x = width - 1; x >= endx; x--)
                        {
                            Color c = CurrentProcessing.GetPixel(x, y);
                            if (c.IsBlackish())
                            {
                                blacks++;
                                if (blacks >= 3)
                                {
                                    scan_ends.Add(x + 2);
                                    hit_ats.Add(y);
                                    break;
                                }
                            }
                            else blacks = 0;
                            if (DEBUG) CurrentProcessing.SetPixel(x, y, Color.Red);
                        }
                        if (scan_ends.Count >= 20) break;
                    }
                    if (scan_ends.Count < 10)
                    {
                        LogError("Could not get tr.X");
                        return ERROR;
                    }

                    hit_points[2] = new PointF((float)GetMean(scan_ends), (float)GetMean(hit_ats));
                    tr.X = hit_points[2].X;
                }

                // tr.Y
                {
                    endx = width - (width - likely_bound.Right) * 2;
                    endy = likely_bound.Top * 2;
                    scan_ends.Clear();
                    hit_ats.Clear();

                    for (x = width - 1; x >= endx; x -= (1 + scan_gap))
                    {
                        blacks = 0;
                        for (y = 0; y < endy; y++)
                        {
                            Color c = CurrentProcessing.GetPixel(x, y);
                            if (c.IsBlackish())
                            {
                                blacks++;
                                if (blacks >= 3)
                                {
                                    scan_ends.Add(y - 2);
                                    hit_ats.Add(x);
                                    break;
                                }
                            }
                            else blacks = 0;
                            if (DEBUG) CurrentProcessing.SetPixel(x, y, Color.Red);
                        }
                        if (scan_ends.Count >= 20) break;
                    }
                    if (scan_ends.Count < 10)
                    {
                        LogError("Could not get tr.Y");
                        return ERROR;
                    }

                    hit_points[3] = new PointF((float)GetMean(hit_ats), (float)GetMean(scan_ends));
                    tr.Y = hit_points[3].Y;
                }
                #endregion

                #region Bottom left
                // dl.X
                {
                    endx = likely_bound.Left * 2;
                    endy = height - (height - likely_bound.Bottom) * 2;
                    scan_ends.Clear();
                    hit_ats.Clear();

                    for (y = height - 1; y >= endy; y -= (1 + scan_gap))
                    {
                        blacks = 0;
                        for (x = 0; x < endx; x++)
                        {
                            Color c = CurrentProcessing.GetPixel(x, y);
                            if (c.IsBlackish())
                            {
                                blacks++;
                                if (blacks >= 3)
                                {
                                    scan_ends.Add(x - 2);
                                    hit_ats.Add(y);
                                    break;
                                }
                            }
                            else blacks = 0;
                            if (DEBUG) CurrentProcessing.SetPixel(x, y, Color.Red);
                        }
                        if (scan_ends.Count >= 20) break;
                    }
                    if (scan_ends.Count < 10)
                    {
                        LogError("Could not get dl.X");
                        return ERROR;
                    }

                    hit_points[4] = new PointF((float)GetMean(scan_ends), (float)GetMean(hit_ats));
                    dl.X = hit_points[4].X;
                }

                // dl.Y
                {
                    endx = likely_bound.Left * 2;
                    endy = height - (height - likely_bound.Bottom) * 2;
                    scan_ends.Clear();
                    hit_ats.Clear();

                    for (x = 0; x < endx; x += (1 + scan_gap))
                    {
                        blacks = 0;
                        for (y = height - 1; y >= endy; y--)
                        {
                            Color c = CurrentProcessing.GetPixel(x, y);
                            if (c.IsBlackish())
                            {
                                blacks++;
                                if (blacks >= 3)
                                {
                                    scan_ends.Add(y + 2);
                                    hit_ats.Add(x);
                                    break;
                                }
                            }
                            else blacks = 0;
                            if (DEBUG) CurrentProcessing.SetPixel(x, y, Color.Red);
                        }
                        if (scan_ends.Count >= 20) break;                        
                    }
                    if (scan_ends.Count < 10)
                    {
                        LogError("Could not get dl.Y");
                        return ERROR;
                    }

                    hit_points[5] = new PointF((float)GetMean(hit_ats), (float)GetMean(scan_ends));
                    dl.Y = hit_points[5].Y;
                }
                #endregion

                #region Bottom Right
                // dr.X
                {
                    endx = width - (width - likely_bound.Right) * 2;
                    endy = height - (height - likely_bound.Bottom) * 2;
                    scan_ends.Clear();
                    hit_ats.Clear();

                    for (y = height - 1; y >= endy; y -= (1 + scan_gap))
                    {
                        blacks = 0;
                        for (x = width - 1; x >= endx; x--)
                        {
                            Color c = CurrentProcessing.GetPixel(x, y);
                            if (c.IsBlackish())
                            {
                                blacks++;
                                if (blacks >= 3)
                                {
                                    scan_ends.Add(x + 2);
                                    hit_ats.Add(y);
                                    break;
                                }
                            }
                            else blacks = 0;
                            if (DEBUG) CurrentProcessing.SetPixel(x, y, Color.Red);
                        }
                        if (scan_ends.Count >= 20) break;
                    }
                    if (scan_ends.Count < 10)
                    {
                        LogError("Could not get dr.X");
                        return ERROR;
                    }

                    hit_points[6] = new PointF((float)GetMean(scan_ends), (float)GetMean(hit_ats));
                    dr.X = hit_points[6].X;
                }

                // dr.Y
                {
                    endx = width - (width - likely_bound.Right) * 2;
                    endy = height - (height - likely_bound.Bottom) * 2;
                    scan_ends.Clear();
                    hit_ats.Clear();

                    for (x = width - 1; x >= endx; x -= (1 + scan_gap))
                    {
                        blacks = 0;
                        for (y = height - 1; y >= endy; y--)
                        {
                            Color c = CurrentProcessing.GetPixel(x, y);
                            if (c.IsBlackish())
                            {
                                blacks++;
                                if (blacks >= 3)
                                {
                                    scan_ends.Add(y + 2);
                                    hit_ats.Add(x);
                                    break;
                                }
                            }
                            else blacks = 0;
                            if (DEBUG) CurrentProcessing.SetPixel(x, y, Color.Red);
                        }
                        if (scan_ends.Count >= 20) break;
                    }
                    if (scan_ends.Count < 10)
                    {
                        LogError("Could not get dr.Y");
                        return ERROR;
                    }

                    hit_points[7] = new PointF((float)GetMean(hit_ats), (float)GetMean(scan_ends));
                    dr.Y = hit_points[7].Y;
                }
                #endregion

                ShowProgress("Got bounds...", 15);
            }
            #endregion
                      
            #region Final straighting
            if (!IsBoundGuessed)
            {
                double x_diff = dl.X - tl.X;
                double y_diff = dl.Y - tl.Y;

                if (x_diff != 0) // Skewed
                {
                    ShowProgress("Fine tuning bounds...", 15);

                    // Recalculate/fine tune bounds
                    tl.X += (float)((tl.Y - hit_points[0].Y) * (x_diff / y_diff));
                    tr.X += (float)((tr.Y - hit_points[2].Y) * (x_diff / y_diff));
                    dl.X -= (float)((hit_points[4].Y - dl.Y) * (x_diff / y_diff));
                    dr.X -= (float)((hit_points[6].Y - dr.Y) * (x_diff / y_diff));

                    x_diff = tr.X - tl.X;
                    y_diff = tr.Y - tl.Y;

                    tl.Y += (float)((tl.X - hit_points[1].X) * (y_diff / x_diff));
                    tr.Y += (float)((tr.X - hit_points[3].X) * (y_diff / x_diff));
                    dl.Y -= (float)((hit_points[5].X - dl.X) * (y_diff / x_diff));
                    dr.Y -= (float)((hit_points[7].X - dr.X) * (y_diff / x_diff));
                }
                x_diff = dl.X - tl.X;
                y_diff = dl.Y - tl.Y;

                if (x_diff != 0) // Still Skewed
                {
                    ShowProgress("Final straightening...", 15);

                    var skew_angle = RadianToDegree(Math.Atan(x_diff / y_diff));
                    CurrentProcessing = CurrentProcessing.Rotate(new Point(0, 0), skew_angle);

                    this.Invoke((MethodInvoker)delegate()
                    {
                        picCurrentLarge.Image = CurrentProcessing;
                        this.Refresh();
                    });

                    tl = RotatePoint(tl, new PointF(0, 0), skew_angle);
                    tr = RotatePoint(tr, new PointF(0, 0), skew_angle);
                    dl = RotatePoint(dl, new PointF(0, 0), skew_angle);
                    dr = RotatePoint(dr, new PointF(0, 0), skew_angle);
                }

                ShowProgress("Ready to crop letters...", 20);
            }
            #endregion

            #region Check for skew
            if ((Math.Abs((tr.X - tl.X) - (dr.X - dl.X)) > SkewToleranceDueToScanError) || (Math.Abs((dl.Y - tl.Y) - (dr.Y - tr.Y)) > SkewToleranceDueToScanError))
            {
                if (!GuessBounds)
                {
                    LogError(string.Format("Couldn't properly get the bounds.\r\nDetermined bounds: [({0}, {1}), ({2}, {3}), ({4}, {5}), ({6}, {7})]", tl.X, tl.Y, tr.X, tr.Y, dl.X, dl.Y, dr.X, dr.Y));
                    return ERROR;
                }
                else
                {
                    tr.X = tl.X + total_width;
                    tr.Y = tl.Y;

                    dl.X = tl.X;
                    dl.Y = tl.Y + total_grid_height;

                    dr.X = tr.X;
                    dr.Y = dl.Y;

                    IsBoundGuessed = true;
                }
            }
            #endregion
                      
            if (DEBUG)
            {
                using (Graphics g = Graphics.FromImage(CurrentProcessing))
                {
                    Pen pen = new Pen(new SolidBrush(Color.Green), 10);

                    g.DrawRectangle(pen, tl.X, tl.Y, tr.X - tl.X, dl.Y - tl.Y);
                }
            }
                 
            int cx = (int)tl.X - 1, cy = (int)tl.Y - 1, cw = (int)(tr.X - tl.X) + 2, ch = (int)(dl.Y - tl.Y) + 2;
            CurrentProcessing = CurrentProcessing.DrawOutCropArea(cx, cy, cw, ch, new SolidBrush(Color.FromArgb(100, 200, 200, 100)));

            this.Invoke((MethodInvoker)delegate()
            {
                picCurrentLarge.Image = CurrentProcessing;
                this.Refresh();
            });

            return !ERROR;
        }

        bool CropLetters(Rectangle roi)
        {
            bool error = false;

            ShowProgress("Cropping letters...");

            try
            {
                string output_folder = IsBoundGuessed ? this.OutputGuessedFolder : this.OutputFolder;

                double box_width = this.ColumnWidth;
                double box_height = this.RowHeight;
                double label_box_height = this.LabelBoxHeight;
                double roi_width = roi.Width;
                double roi_height = roi.Height;
                double actual_column_width = roi_width / this.ColumnsPerPage;
                double actual_row_height_with_label = roi_height / this.RowsPerPage;
                double actual_row_height = roi_height / (this.RowsPerPage * (1 + (label_box_height / box_height)));
                double actual_label_box_height = actual_row_height_with_label * (label_box_height / (label_box_height + box_height));
                
                double cur_x = roi.X, cur_y = roi.Y;

                int crop_width = (int)Math.Floor(actual_column_width) - LetterCropMargin * 2,
                    crop_height = (int)Math.Floor(actual_row_height) - LetterCropMargin * 2;

                int form_no = (int)nudFormNo.Value;
                int letters_per_page = this.RowsPerPage * (this.ColumnsPerPage / this.ColumnSpanPerCharacter);
                int current_letter_id = (form_no - 1) * letters_per_page + 1;
                int span = 0, progress = 0;

                Brush fill_brush = new SolidBrush(Color.FromArgb(100, 50, 200, 80));
                using (Graphics g = Graphics.FromImage(CurrentProcessing))
                {
                    for (int row = 0; row < this.RowsPerPage; row++)
                    {
                        for (int col = 0; col < this.ColumnsPerPage; col++)
                        {
                            int x = (int)Math.Round(cur_x) + LetterCropMargin,
                                y = (int)Math.Round(cur_y + actual_label_box_height) + LetterCropMargin;

                            string current_letter_folder = output_folder + current_letter_id.ToString(4) + @"\";
                            if (!Directory.Exists(current_letter_folder))
                            {
                                Directory.CreateDirectory(current_letter_folder);
                            }

                            string current_letter_file = current_letter_folder + DateTime.Now.Ticks + "_" + RNG.Next(1000).ToString(4) + ".jpg";

                            using (Bitmap cropped = CurrentProcessing.Clone(new Rectangle(x, y, crop_width, crop_height), CurrentProcessing.PixelFormat))
                            {
                                try
                                {
                                    this.Invoke((MethodInvoker)delegate()
                                    {
                                        picCurrentSmall.Image = (Bitmap)cropped.Clone();
                                        this.Refresh();
                                    });
                                   
                                    cropped.Save(current_letter_file, System.Drawing.Imaging.ImageFormat.Jpeg);
                                }
                                catch (Exception ex)
                                {
                                    LogError(ex.Message + ex.StackTrace, "Save failed");
                                }
                            }

                            g.FillRectangle(fill_brush, x, y, crop_width, crop_height);

                            this.Invoke((MethodInvoker)delegate()
                            {
                                picCurrentLarge.Image = CurrentProcessing;
                                this.Refresh();
                            });

                            span++;
                            if (span == this.ColumnSpanPerCharacter)
                            {
                                span = 0;
                                current_letter_id++;
                                progress++;

                                ShowProgress(20 + (int)(((double)progress / (double)letters_per_page) * 80.0));
                            }
                            cur_x += actual_column_width;
                        }

                        cur_x = roi.X;
                        cur_y += actual_row_height_with_label;
                    }
                }

                ShowProgress("Form processing coompleted", 100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                error = true;
            }

            return error;
        }

        void LoadConfigs()
        {
            //DPI 
            this.DPI = this.ConfigFileReader.GetConfig("DPI").ToDouble(300);
            if (this.DPI < 72) this.DPI = 72;
            if (this.DPI > 1200) this.DPI = 1200;

            //Page width in inches
            this.PageWidthInInches = this.ConfigFileReader.GetConfig("PAGE_WIDTH").ToDouble(8.27);
            if (this.PageWidthInInches < 8) this.PageWidthInInches = 8;
            if (this.PageWidthInInches > 20) this.PageWidthInInches = 20;

            //Page height in inches
            this.PageHeightInInches = this.ConfigFileReader.GetConfig("PAGE_HEIGHT").ToDouble(11.69);
            if (this.PageHeightInInches < 8) this.PageHeightInInches = 8;
            if (this.PageHeightInInches > 20) this.PageHeightInInches = 20;

            //Horizontal Page margin in inches
            this.HorizontalPageMarginInInches = this.ConfigFileReader.GetConfig("PAGE_MARGIN_X").ToDouble(0.1);
            if (this.HorizontalPageMarginInInches < 0) this.HorizontalPageMarginInInches = 0;
            if (this.HorizontalPageMarginInInches > 1) this.HorizontalPageMarginInInches = 1;

            //Vertical Page Margin in inches
            this.VerticalPageMarginInInches = this.ConfigFileReader.GetConfig("PAGE_MARGIN_Y").ToDouble(0.1);
            if (this.VerticalPageMarginInInches < 0) this.VerticalPageMarginInInches = 0;
            if (this.VerticalPageMarginInInches > 1) this.VerticalPageMarginInInches = 1;

            //Rows per page
            this.RowsPerPage = this.ConfigFileReader.GetConfig("ROWS_PER_PAGE").ToInt(15);
            if (this.RowsPerPage < 10) this.RowsPerPage = 10;
            if (this.RowsPerPage > 20) this.RowsPerPage = 20;

            //Columns per page
            this.ColumnsPerPage = this.ConfigFileReader.GetConfig("COLS_PER_PAGE").ToInt(14);
            if (this.ColumnsPerPage < 1) this.ColumnsPerPage = 1;
            if (this.ColumnsPerPage > 20) this.ColumnsPerPage = 20;

            //Columns per char
            this.ColumnSpanPerCharacter = this.ConfigFileReader.GetConfig("COLS_PER_CHAR").ToInt(2);
            if (this.ColumnSpanPerCharacter < 1) this.ColumnSpanPerCharacter = 1;
            if (this.ColumnSpanPerCharacter > 5) this.ColumnSpanPerCharacter = 5;

            //Column width
            this.ColumnWidthInInches = this.ConfigFileReader.GetConfig("COLUMN_WIDTH").ToDouble(0.5);
            if (this.ColumnWidthInInches < 0.4) this.ColumnWidthInInches = 0.4;
            if (this.ColumnWidthInInches > 5) this.ColumnWidthInInches = 5;

            //Row height
            this.RowHeightInInches = this.ConfigFileReader.GetConfig("ROW_HEIGHT").ToDouble(0.5);
            if (this.RowHeightInInches < 0.4) this.RowHeightInInches = 0.4;
            if (this.RowHeightInInches > 2) this.RowHeightInInches = 2;

            //Label box height
            this.LabelBoxHeightInInches = this.ConfigFileReader.GetConfig("LABEL_HEIGHT").ToDouble(0.2);
            if (this.LabelBoxHeightInInches < 0.1) this.LabelBoxHeightInInches = 0.1;
            if (this.LabelBoxHeightInInches > 1) this.LabelBoxHeightInInches = 1;

            //Thin line width
            this.ThinLineWidth = this.ConfigFileReader.GetConfig("THIN_LINE_WIDTH").ToFloat(1F);
            if (this.ThinLineWidth < 0.5F) this.ThinLineWidth = 0.5F;
            if (this.ThinLineWidth > 10F) this.ThinLineWidth = 10F;

            //Thick line width
            this.ThickLineWidth = this.ConfigFileReader.GetConfig("THICK_LINE_WIDTH").ToFloat(2F);
            if (this.ThickLineWidth < 0.5F) this.ThickLineWidth = 0.5F;
            if (this.ThickLineWidth > 10F) this.ThickLineWidth = 10F;

            //Font
            this.LabelFont = this.ConfigFileReader.GetConfig("FONT");
            if (string.IsNullOrEmpty(this.LabelFont)) this.LabelFont = "Vrinda";

            //Font size
            this.LabelFontSize = this.ConfigFileReader.GetConfig("FONTSIZE").ToFloat(-1F);
            if (this.LabelFontSize < 0)
            {
                //this.LabelFontSize = GetAutoFontSize();
            }
            else
            {
                if (this.LabelFontSize > 0 && this.LabelFontSize < 8) this.LabelFontSize = 8;
                if (this.LabelFontSize > this.LabelBoxHeight) this.LabelFontSize = this.LabelBoxHeight;
            }

            LetterCropMargin = (int)(0.03 * DPI);
            SkewToleranceDueToScanError = LetterCropMargin;
        }

        void ShowProgress(string text, int progress)
        {
            MethodInvoker show_progress = delegate()
            {
                labProgress.Text = text;
                progressCurrent.Value = progress;
            };

            if (this.InvokeRequired)
                this.Invoke(show_progress);
            else
                show_progress();
        }

        void ShowProgress(string text)
        {
            MethodInvoker show_progress = delegate()
            {
                labProgress.Text = text;
            };

            if (this.InvokeRequired)
                this.Invoke(show_progress);
            else
                show_progress();
        }

        void ShowProgress(int progress)
        {
            MethodInvoker show_progress = delegate()
            {
                progressCurrent.Value = progress;
            };

            if (this.InvokeRequired)
                this.Invoke(show_progress);
            else
                show_progress();
        }

        void Log(string event_info, string additional_data = "")
        {
            File.AppendAllText(this.Logfile, "\r\nOn " + DateTime.Now.ToString() + ":\r\nEvent: " + event_info + "\r\nAdditional data: \r\n" + additional_data);
            //MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void LogError(string error, string additional_data = "")
        {
            File.AppendAllText(this.Logfile, "\r\nOn " + DateTime.Now.ToString() + ":\r\nError: " + error + "\r\nAdditional data: \r\n" + additional_data);
            //MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void ShowError(string error, string additional_data = "")
        {
            //File.AppendAllText(this.Logfile, "\r\nOn " + DateTime.Now.ToString() + ":\r\nError: " + error + "\r\nAdditional data: \r\n" + additional_data);
            MessageBox.Show(error + "\r\n" + additional_data, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region Helper methods
        double GetMean(List<int> vals)
        {
            if (vals.Count > 0)
            {
                double mean = vals.Average();
                double threshold = mean * 0.2;
                var fv = vals.FindAll(x => Math.Abs(mean - x) < threshold);

                if (fv.Count > 0) 
                    return fv.Average();
                else 
                    return mean;
            }
            return 0;
        }

        double RadianToDegree(double rad)
        {
            return rad * 180 / Math.PI;
        }

        double DegreeToRadian(double degree)
        {
            return degree * Math.PI / 180.0;
        }
        public double Cos(double degrees)
        {
            return Math.Cos(DegreeToRadian(degrees));
        }

        public double Sin(double degrees)
        {
            return Math.Sin(DegreeToRadian(degrees));
        }

        public PointF RotatePoint(PointF point, PointF axis, double angle)
        {
            if (angle == 0) return point;

            double cos = Cos(angle);
            double sin = Sin(angle);
            double rdx = 0, rdy = 0;
            double dx, dy;

            PointF rotated = new PointF();

            dx = point.X - axis.X;
            dy = point.Y - axis.Y;

            rdx = dx * cos - dy * sin;
            rdy = dx * sin + dy * cos;

            rdx += axis.X;
            rdy += axis.Y;

            rotated.X = (float)rdx;
            rotated.Y = (float)rdy;

            return rotated;
        }
        #endregion

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            SelectScanFolder();
        }

        private void btnStartScanning_Click(object sender, EventArgs e)
        {
            if(nudFormNo.Value < 1)
            {
                ShowError("Form number is invalid.");

                return;
            }

            if (MessageBox.Show("Is the form number ( " + nudFormNo.Value.ToString() + " ) okay?", "Check form number", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) return;

            ProcessScannedForms();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        public int sl2 { get; set; }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            GetFormScans();
        }

        private void btnSignalToStop_Click(object sender, EventArgs e)
        {
            MethodInvoker signal_stop = delegate()
                { 
                    this.SignalledToStop = true;
                    btnSignalToStop.Text = "Stop pending...";
                    btnSignalToStop.Enabled = false;
                };

            if (this.InvokeRequired)
                this.Invoke(signal_stop);
            else
                signal_stop();
        }
    }
}
