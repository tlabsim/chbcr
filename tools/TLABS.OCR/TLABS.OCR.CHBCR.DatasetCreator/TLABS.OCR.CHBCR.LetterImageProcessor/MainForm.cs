using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLABS.Extensions;

namespace TLABS.OCR.CHBCR.LetterImageProcessor
{
    public partial class MainForm : Form
    {
        string SourceFolderPath = string.Empty;
        string DestinationFolderPath = string.Empty;

        string LogFolder = string.Empty;
        string Logfile = "";
              
        //Options
        System.Drawing.Imaging.ImageFormat OutputImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
        System.Drawing.Imaging.PixelFormat OutputPixelFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb; 
        string OutputFileExtension = ".bmp";

        bool ApplyConvolution = true;
        bool DoBinarize = true;
        bool DetermineBinarizationThresholdAutomatically = false;
        bool DoCropToFit = false;
        bool DoResize = false;
        bool DoRename = false;

        double[,] ConvolutionMatrix = new double[3,3];
        int BinarizationThreshold = 128;
        int CropMargin = 1;
        int ResizeWidth = 50;
        int ResizeHeight = 50;
        string RenamePrefix = string.Empty;

        ManualResetEvent mrePauseResume = new ManualResetEvent(true);
        bool IsStopSignalled = false;

        public MainForm()
        {
            InitializeComponent();

            SetControls();
            SetUI();
            AddEventHandlers();
        }

        void SetControls()
        {
            comboOutputImageFormat.SelectedIndex = 0;

            this.LogFolder = GetExecutingDirectory().FullName.TrimEnd('\\') + @"\Log";

            if (!Directory.Exists(this.LogFolder))
            {
                Directory.CreateDirectory(this.LogFolder);
            }

            this.Logfile = this.LogFolder.TrimEnd('\\') + @"\log_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
        }

        void SetUI()
        {
            btnStart.Enabled = false;
            btnPauseResume.Enabled = false;
            btnStop.Enabled = false;
        }

        void AddEventHandlers() { }

        void SelectSourceFolder()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;
            var dr = FBD.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.Cancel)
            {
                txtSourceFolderPath.Text = FBD.SelectedPath;
            }

            if (IsBothFolderSelected())
                btnStart.Enabled = true;
            else
                btnStart.Enabled = false;
        }

        void SelectDestinationFolder()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = true;
            var dr = FBD.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.Cancel)
            {
                txtDestinationFolderPath.Text = FBD.SelectedPath;
            }

            if (IsBothFolderSelected())
                btnStart.Enabled = true;
            else
                btnStart.Enabled = false;
        }

        bool IsBothFolderSelected()
        {
            string source_folder = txtSourceFolderPath.Text.Trim();
            string destination_folder = txtDestinationFolderPath.Text.Trim();

            if (string.IsNullOrEmpty(source_folder) || string.IsNullOrEmpty(destination_folder)) return false;

            if (!Directory.Exists(source_folder)) return false;

            if (!Directory.Exists(destination_folder))
            {
                try
                {
                    Directory.CreateDirectory(destination_folder);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        async void StartProcessing()
        {
            this.IsStopSignalled = false;

            string source_folder = txtSourceFolderPath.Text.Trim();
            string destination_folder = txtDestinationFolderPath.Text.Trim();

            if (string.IsNullOrEmpty(source_folder) || string.IsNullOrEmpty(destination_folder))
            {
                ShowError("Select source and destinatoin folder");
                Retreat();
                return;
            }

            if (!Directory.Exists(source_folder))
            {
                ShowError("Source folder doesn't exist");
                Retreat();
                return;
            }

            if (!Directory.Exists(destination_folder))
            {
                try
                {
                    Directory.CreateDirectory(destination_folder);
                }
                catch
                {
                    ShowError("Couldn't create destination folder");
                    Retreat();
                    return;
                }
            }
            else if(source_folder == destination_folder)
            {
                ShowError("Source and destination folders can't be same");
                Retreat();
                return;
            }
            else
            {
                if(MessageBox.Show("The output folder -\r\n\r\n" + destination_folder + "\r\n\r\nwill be emptied. Do you want to proceed?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    CleanDirectory(destination_folder);
                }
                else
                {
                    Retreat();
                    return;
                }
            }

            this.SourceFolderPath = source_folder;
            this.DestinationFolderPath = destination_folder;

            //Load options
            switch(comboOutputImageFormat.SelectedIndex)
            {
                case 1:
                    this.OutputImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                    this.OutputPixelFormat = System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
                    this.OutputFileExtension = ".bmp";
                    break;
                case 2:
                    this.OutputImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                    this.OutputPixelFormat = System.Drawing.Imaging.PixelFormat.Format1bppIndexed;
                    this.OutputFileExtension = ".bmp";
                    break;
                case 3:
                    this.OutputImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                    this.OutputPixelFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb; 
                    this.OutputFileExtension = ".jpg";
                    break;

                case 4:
                    this.OutputImageFormat = System.Drawing.Imaging.ImageFormat.Png;
                    this.OutputPixelFormat = System.Drawing.Imaging.PixelFormat.Format32bppArgb; 
                    this.OutputFileExtension = ".png";
                    break;
                case 0:
                default:
                    this.OutputImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                    this.OutputPixelFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb; 
                    this.OutputFileExtension = ".bmp";
                    break;
            }


            this.ApplyConvolution = cbApplyConvolution.Checked;
            if (this.ApplyConvolution)
            {
                this.ConvolutionMatrix[0, 0] = txtCM_00.Text.Trim().ToDouble(0.0);
                this.ConvolutionMatrix[0, 1] = txtCM_01.Text.Trim().ToDouble(0.0);
                this.ConvolutionMatrix[0, 2] = txtCM_02.Text.Trim().ToDouble(0.0);
                this.ConvolutionMatrix[1, 0] = txtCM_10.Text.Trim().ToDouble(0.0);
                this.ConvolutionMatrix[1, 1] = txtCM_11.Text.Trim().ToDouble(1.0);
                this.ConvolutionMatrix[1, 2] = txtCM_12.Text.Trim().ToDouble(0.0);
                this.ConvolutionMatrix[2, 0] = txtCM_20.Text.Trim().ToDouble(0.0);
                this.ConvolutionMatrix[2, 1] = txtCM_21.Text.Trim().ToDouble(0.0);
                this.ConvolutionMatrix[2, 2] = txtCM_22.Text.Trim().ToDouble(0.0);
            }

            this.DoBinarize = cbBinarize.Checked;
            this.DetermineBinarizationThresholdAutomatically = cbAutoBinarizationThreshold.Checked;
            this.BinarizationThreshold = sliderBinarizationThreshold.Value;            

            this.DoCropToFit = cbCropToFit.Checked;
            this.CropMargin = txtCropMargin.Text.Trim().ToInt(-1);
            if(this.CropMargin < 0)
            {
                this.CropMargin = 1;
                txtCropMargin.Text = "1";
            }

            this.DoResize = cbResize.Checked;
            if (this.DoResize)
            {
                this.ResizeWidth = txtResizeWidth.Text.Trim().ToInt(-1);
                if (ResizeWidth < 0)
                {
                    txtResizeWidth.Text = "50";
                    this.ResizeWidth = 50;
                }
                else if (this.ResizeWidth < 32)
                {
                    txtResizeWidth.Text = "32";
                    this.ResizeWidth = 32;
                }
                else if (this.ResizeWidth > 150)
                {
                    txtResizeWidth.Text = "150";
                    this.ResizeWidth = 150;
                }

                this.ResizeHeight = txtResizeHeight.Text.Trim().ToInt(-1);
                if (ResizeHeight < 0)
                {
                    txtResizeHeight.Text = "50";
                    this.ResizeHeight = 50;
                }
                else if (this.ResizeHeight < 32)
                {
                    txtResizeHeight.Text = "32";
                    this.ResizeHeight = 32;
                }
                else if (this.ResizeHeight > 150)
                {
                    txtResizeHeight.Text = "150";
                    this.ResizeHeight = 150;
                }
            }

            this.DoRename = cbRename.Checked;
            this.RenamePrefix = txtRenamePrefix.Text.Trim();

            if(!this.ApplyConvolution && !this.DoBinarize && !this.DoCropToFit && !this.DoResize && !DoRename)
            {
                ShowError("No processing step is selected");
                return;
            }

            ProgressPanel.Visible = true;
            panelOptions.Enabled = false;
            btnPauseResume.Enabled = true;
            btnStop.Enabled = true;
            this.Refresh();

            await Task.Run(() => { ProcessDirectory(source_folder); });

            Retreat();
        }

        void ProcessDirectory(string dir)
        {
            if (IsStopSignalled) return;

            this.Invoke((MethodInvoker)delegate()
            {
                labCurrentFolder.Text = dir;
                this.Refresh();
            });

            if (IsStopSignalled) return;

            var sub_dirs = Directory.EnumerateDirectories(dir);

            foreach (var sub_dir in sub_dirs)
            {
                if (IsStopSignalled) return;
                ProcessDirectory(sub_dir);
            }

            if (IsStopSignalled) return;

            var image_files = Directory.EnumerateFiles(dir, "*.jpg");

            int image_index = 0;
            foreach (var image_file in image_files)
            {
                if (IsStopSignalled) return;
                ProcessImage(image_file, image_index);
                image_index++;
            }
        }

        void ProcessImage(string image_file, int image_index)
        {
            mrePauseResume.WaitOne();

            this.Invoke((MethodInvoker)delegate()
            {
                labCurrentFile.Text = image_file;
                this.Refresh();
            });

            FileInfo fi = new FileInfo(image_file);

            if (!fi.Exists)
            {
                LogError("File doesn't exist", "Location: " + image_file);
                return;
            }

            //Calculate output file


            string out_file_name = fi.FullName;
            if (this.DoRename)
            {
                out_file_name = out_file_name.Replace(fi.Name, this.RenamePrefix + fi.Directory.Name + "_" + image_index.ToString(4) + this.OutputFileExtension);
            }
            else
            {
                out_file_name = out_file_name.Replace(fi.Extension, "") + this.OutputFileExtension;
            }
            
            string out_file_path = this.DestinationFolderPath.TrimEnd('\\') + @"\" + GetRelativePath(out_file_name, this.SourceFolderPath);
            FileInfo ofi = new FileInfo(out_file_path);
            if (!ofi.Directory.Exists)
            {
                ofi.Directory.Create();
            }

            using (Bitmap bmp = (Bitmap)Image.FromFile(fi.FullName))
            {
                Bitmap _processed = bmp;

                try
                {
                    int width = bmp.Width,
                        height = bmp.Height;

                    BitmapProcessor bmpp = new BitmapProcessor(bmp);

                    if (this.ApplyConvolution)
                    {
                        bmpp.GrayscaleInverseConvolve3x3(this.ConvolutionMatrix);
                    }

                    if (this.DoBinarize)
                    {
                        if (this.DetermineBinarizationThresholdAutomatically)
                        {
                            bmpp.Binarise();
                        }
                        else
                        {
                            bmpp.Binarise(this.BinarizationThreshold);
                        }                       
                        
                        _processed = bmp;
                    }                    

                    if (this.DoCropToFit)
                    {
                        var rect = bmpp.GetFittingRectangle(Color.White, this.CropMargin);
                        _processed = (Bitmap)bmp.Clone(rect, bmp.PixelFormat);
                    }

                    if(this.DoResize)
                    {
                        using (Bitmap resized = new Bitmap(this.ResizeWidth, this.ResizeHeight))
                        {
                            using (Graphics g = Graphics.FromImage(resized))
                            {
                                g.FillRectangle(new SolidBrush(Color.White), 0, 0, resized.Width, resized.Height);

                                //Calculate aspect
                                int _w = _processed.Width,
                                    _h = _processed.Height;
                                int _nw, _nh;
                                int margin_x, margin_y;

                                double aspect_w = (double)_w / (double)this.ResizeWidth;
                                double aspect_h = (double)_h / (double)this.ResizeHeight;

                                double max = Math.Max(aspect_w, aspect_h);
                                //double min = Math.Min(aspect_w, aspect_h);
                                double resize_factor = 1 / max;                                

                                _processed = _processed.Resize(resize_factor);
                                _nw = _processed.Width;
                                _nh = _processed.Height;

                                margin_x = (this.ResizeWidth - _nw) / 2;
                                margin_y = (this.ResizeHeight - _nh) / 2;

                                g.DrawImage(_processed, margin_x, margin_y);
                            }

                            _processed = (Bitmap)resized.Clone();
                        }
                    }

                    if (this.OutputPixelFormat != System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                    {
                        _processed = (Bitmap)_processed.Clone(new Rectangle(0, 0, _processed.Width, _processed.Height), this.OutputPixelFormat);
                    }

                    _processed.Save(out_file_path, this.OutputImageFormat);

                    _processed.Dispose();
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
            }
        }

        void Retreat()
        {
            btnStart.Enabled = IsBothFolderSelected();
            btnPauseResume.Enabled = false;
            btnStop.Enabled = false;

            ProgressPanel.Visible = false;
            panelOptions.Enabled = true;

            this.Refresh();
        }       

        string GetRelativePath(string file, string folder)
        {
            Uri file_Uri = new Uri(file);

            // Folders must end in a slash
            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                folder += Path.DirectorySeparatorChar;
            }
            Uri folder_Uri = new Uri(folder);
            return Uri.UnescapeDataString(folder_Uri.MakeRelativeUri(file_Uri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }

        private void CleanDirectory(string dir)
        {
            DirectoryInfo di = new DirectoryInfo(dir);

            foreach (FileInfo fi in di.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo sdi in di.GetDirectories())
            {
                CleanDirectory(sdi.FullName);
                sdi.Delete();
            }            
        }

        void Log(string event_info, string additional_data = "")
        {
            try
            {
                File.AppendAllText(this.Logfile, "\r\nOn " + DateTime.Now.ToString() + ":\r\nEvent: " + event_info + "\r\nAdditional data: \r\n" + additional_data);

            }
            catch { }
            //MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void LogError(string error, string additional_data = "")
        {
            try
            {
                File.AppendAllText(this.Logfile, "\r\nOn " + DateTime.Now.ToString() + ":\r\nError: " + error + "\r\nAdditional data: \r\n" + additional_data);
            }
            catch { }
            //MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void ShowError(string error, string additional_data = "")
        {
            //File.AppendAllText(this.Logfile, "\r\nOn " + DateTime.Now.ToString() + ":\r\nError: " + error + "\r\nAdditional data: \r\n" + additional_data);
            MessageBox.Show(error + "\r\n" + additional_data, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DirectoryInfo GetExecutingDirectory()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.AbsolutePath).Directory;
        }

        #region Event handlers
        private void btnSelectSourceFolder_Click(object sender, EventArgs e)
        {
            SelectSourceFolder();
        }

        private void btnSelectDestinationFolder_Click(object sender, EventArgs e)
        {
            SelectDestinationFolder();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartProcessing();
        }

        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            if (btnPauseResume.Text == "Pause")
            {
                mrePauseResume.Reset();

                btnPauseResume.Text = "Resume";
            }
            else
            {
                mrePauseResume.Set();

                btnPauseResume.Text = "Pause";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {           
            this.IsStopSignalled = true;

            if (btnPauseResume.Text == "Resume")
            {
                mrePauseResume.Set();

                btnPauseResume.Text = "Pause";
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            labBinarizationThreshold.Text = sliderBinarizationThreshold.Value.ToString();
        }

        private void cbApplyConvolution_CheckedChanged(object sender, EventArgs e)
        {
            panelOption_ConvolutionKernel.Enabled = cbApplyConvolution.Checked;
        }

        private void cbBinarize_CheckedChanged(object sender, EventArgs e)
        {
            panelOption_Binarization.Enabled = cbBinarize.Checked;
        }

        private void cbAutoBinarizationThreshold_CheckedChanged(object sender, EventArgs e)
        {
            sliderBinarizationThreshold.Enabled = !cbAutoBinarizationThreshold.Checked;
            labBinarizationThreshold.Enabled = !cbAutoBinarizationThreshold.Checked;
        }

        private void cbCropToFit_CheckedChanged(object sender, EventArgs e)
        {
            panelCropToFitOptions.Enabled = cbCropToFit.Checked;
        }

        private void cbResize_CheckedChanged(object sender, EventArgs e)
        {
            panelResize.Enabled = cbResize.Checked;
        }

        private void cbRename_CheckedChanged(object sender, EventArgs e)
        {
            panelRenameOptions.Enabled = cbRename.Checked;
        }

        private void comboConvolutionPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboConvolutionPresets.SelectedIndex)
            {
                case 1:
                    txtCM_00.Text = "0.1";
                    txtCM_01.Text = "0.1";
                    txtCM_02.Text = "0.1";
                    txtCM_10.Text = "0.1";
                    txtCM_11.Text = "1.0";
                    txtCM_12.Text = "0.1";
                    txtCM_20.Text = "0.1";
                    txtCM_21.Text = "0.1";
                    txtCM_22.Text = "0.1";
                    break;

                case 2:
                    txtCM_00.Text = "0.125";
                    txtCM_01.Text = "0.125";
                    txtCM_02.Text = "0.125";
                    txtCM_10.Text = "0.125";
                    txtCM_11.Text = "1.0";
                    txtCM_12.Text = "0.125";
                    txtCM_20.Text = "0.125";
                    txtCM_21.Text = "0.125";
                    txtCM_22.Text = "0.125";
                    break;

                case 3:
                    txtCM_00.Text = "0.0";
                    txtCM_01.Text = "0.1";
                    txtCM_02.Text = "0.0";
                    txtCM_10.Text = "0.1";
                    txtCM_11.Text = "1.0";
                    txtCM_12.Text = "0.1";
                    txtCM_20.Text = "0.0";
                    txtCM_21.Text = "0.1";
                    txtCM_22.Text = "0.0";
                    break;

                case 0:
                default:
                    txtCM_00.Text = "0.0";
                    txtCM_01.Text = "0.0";
                    txtCM_02.Text = "0.0";
                    txtCM_10.Text = "0.0";
                    txtCM_11.Text = "1.0";
                    txtCM_12.Text = "0.0";
                    txtCM_20.Text = "0.0";
                    txtCM_21.Text = "0.0";
                    txtCM_22.Text = "0.0";
                    break;

            }
        }
        #endregion        
    }
}
