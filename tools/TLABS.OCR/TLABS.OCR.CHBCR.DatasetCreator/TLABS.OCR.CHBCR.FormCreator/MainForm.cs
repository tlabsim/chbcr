using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLABS.Extensions;
using TLABS.OCR.CHBCR.Common;

namespace TLABS.OCR.CHBCR.FormCreator
{
    public partial class MainForm : Form
    {
        int RowsPerPage = 15;
        int ColumnsPerPage = 14;
        int ColumnSpanPerCharacter = 2;

        double DPI = 300;
        double PageWidthInInches = 8.27;
        double PageHeightInInches = 11.69;    
        double HorizontalPageMarginInInches = 0.1;
        double VerticalPageMarginInInches = 0.1;
        double ColumnWidthInInches = 0.5; 
        double RowHeightInInches = 0.5;
        double LabelBoxHeightInInches = 0.2;
        double GuideLineThicknessInInches = 0.05;

        int PageWidth { get { return (int)(PageWidthInInches * DPI); } }
        int PageHeight { get { return (int)(PageHeightInInches * DPI); } }
        int HorizontalPageMargin { get { return (int)(HorizontalPageMarginInInches * DPI); } }
        int VerticalPageMargin { get { return (int)(VerticalPageMarginInInches * DPI); } }     
        int ColumnWidth { get { return (int)(this.ColumnWidthInInches * DPI); } }
        int RowHeight { get { return (int)(RowHeightInInches * DPI); } }        
        int LabelBoxHeight { get { return (int)(LabelBoxHeightInInches * DPI); } }
        int HeaderPanelHeight { get { return (int)(0.3 * DPI); } }
        int GuideLineThickness { get { return (int)(GuideLineThicknessInInches * DPI); } }

        float ThickLineWidth = 2;
        float ThinLineWidth = 1;
        string LabelFont = "Vrinda";
        float LabelFontSize = -1; //Auto

        string ConfigFilePath = "configs.txt";
        ConfigFileReader ConfigFileReader;
        FormNavigator FormNavigator;        

        public MainForm()
        {
            InitializeComponent();

            this.ConfigFileReader = new ConfigFileReader(this.ConfigFilePath);
            LoadConfigs();

            this.FormNavigator = new FormNavigator(imgCurrentForm, btnPrevForm, btnNextForm, btnExpandForm, btnPrintForm, btnSaveForm, btnSaveAll, labCounter);
        }
        
        void SelectInputFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files | *.txt";
            ofd.DefaultExt = ".txt";

            var dr = ofd.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.Cancel)
            {
                tbSelectedFile.Text = ofd.FileName;
            }
        }

        List<string> GetInputFileContent(string input_file)
        {
            if (!File.Exists(input_file)) return null;

            return File.ReadAllLines(input_file, Encoding.Unicode).ToList();
        }

        void CreateDataForms()
        {
            try
            {
                string input_file = tbSelectedFile.Text.Trim();

                if (!File.Exists(input_file))
                {
                    LogError("Input dataset file not found");
                    return;
                }

                if (AreFormParametersValid())
                {
                    this.FormNavigator.Reset();

                    List<string> labels = GetInputFileContent(input_file);
                    if (labels != null)
                    {
                        int lc = labels.Count;
                        int labels_per_page = this.RowsPerPage * (this.ColumnsPerPage / this.ColumnSpanPerCharacter);

                        int fn = 1;
                        int l = 0;
                        while (l < lc)
                        {
                            int lpp = labels_per_page;
                            if (lc - l < labels_per_page) lpp = lc - l;

                            var page_labels = labels.GetRange(l, lpp);

                            CreateForm(page_labels, fn);

                            l += lpp;
                            fn++;
                        }
                    }

                    this.FormNavigator.Init();
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }

        bool AreFormParametersValid()
        {
            bool is_valid = true;

            if (RowsPerPage * (RowHeightInInches + LabelBoxHeightInInches) > PageHeightInInches) is_valid = false;
            if (ColumnsPerPage * ColumnWidthInInches > PageWidthInInches) is_valid = false;
            if (ColumnsPerPage % ColumnSpanPerCharacter != 0) is_valid = false;

            return is_valid;
        }

        void CreateForm(List<string> labels, int form_number)
        {
            int page_width = this.PageWidth - this.HorizontalPageMargin * 2;
            int page_height = this.PageHeight - this.VerticalPageMargin * 2;

            int box_width = this.ColumnWidth;
            int box_height = this.RowHeight;
            int label_box_height = this.LabelBoxHeight;

            int header_panel_height = this.HeaderPanelHeight;

            int total_width = box_width * ColumnsPerPage;
            int total_grid_height = (box_height + label_box_height) * RowsPerPage;
            int total_height = total_grid_height + header_panel_height;

            if (total_width > page_width || total_height > page_height)
            {
                LogError("Form size exceeds page size");
                return;
            }

            int actual_cols = this.ColumnsPerPage / this.ColumnSpanPerCharacter;
            int grid_width = box_width * this.ColumnSpanPerCharacter;
            int grid_height = box_height + label_box_height;

            int margin_x = 0, margin_y = 0;
            margin_x = (page_width - total_width) / 2;
            margin_y = (page_height - total_grid_height) / 2;

            if (margin_y < header_panel_height) margin_y = header_panel_height;

            int curx = margin_x , cury = margin_y - header_panel_height;

            Brush background_brush = new SolidBrush(Color.White);
            Brush light_brush = new SolidBrush(Color.FromArgb(255, 230, 230, 230));
            Brush black_brush = new SolidBrush(Color.Black);
            Brush grey_brush = new SolidBrush(Color.FromArgb(255, 96, 96, 96));
            Brush faint_brush = new SolidBrush(Color.FromArgb(230, 230, 230));

            Pen thin_pen = new Pen(black_brush, this.ThinLineWidth);
            Pen thick_pen = new Pen(black_brush, this.ThickLineWidth);
            Pen thick_pen2 = new Pen(black_brush, this.ThickLineWidth + 1);
            Pen faint_pen = new Pen(faint_brush, this.ThinLineWidth);
            faint_pen.DashPattern = new float[4]{3,5,3,5};
            Pen faint_pen2 = new Pen(faint_brush, this.ThinLineWidth);
            faint_pen2.DashPattern = new float[4] { 3, 5, 3, 5 };

            int box_inside_margin = (int)(0.05 * this.DPI);
            int box_inside_width = box_height - box_inside_margin*2;
            int box_inside_height = box_height - box_inside_margin *2;
            int matra_line_y = box_inside_margin + (int)(box_inside_height * 0.3);

            if (this.LabelFontSize < 0) this.LabelFontSize = GetAutoFontSize();

            System.Drawing.Font english_font = new System.Drawing.Font("Arial", this.LabelFontSize);
            System.Drawing.Font letter_id_font = new System.Drawing.Font("Consolas", (float)(this.LabelFontSize * 0.6));
            System.Drawing.Font bangla_font = new System.Drawing.Font(this.LabelFont, this.LabelFontSize);

            StringFormat label_string_format = new StringFormat();
            label_string_format.Alignment = StringAlignment.Center;
            label_string_format.LineAlignment = StringAlignment.Center;
            label_string_format.Trimming = StringTrimming.EllipsisCharacter;

            StringFormat id_string_format = new StringFormat();
            id_string_format.Alignment = StringAlignment.Near;
            id_string_format.LineAlignment = StringAlignment.Center;
            id_string_format.Trimming = StringTrimming.EllipsisCharacter;            

            using (Bitmap bmp = new Bitmap(page_width, page_height))
            {                
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.FillRectangle(background_brush, new Rectangle(0, 0, page_width, page_height));

                    //Draw header
                    string header_string1 = string.Format("(Form {0}) |   Sl:                          Contributor ID:", form_number);
                    string header_string2 = "Age:                  (√) □ Male / □ Female";

                    StringFormat hs2sf = new StringFormat();
                    hs2sf.Alignment = StringAlignment.Far;

                    float header_horizontal_margin = (float)((0.1 + this.GuideLineThicknessInInches) * this.DPI);
                    RectangleF header_rect = new RectangleF(curx + header_horizontal_margin, cury, total_width - header_horizontal_margin * 2, header_panel_height);

                    g.DrawString(header_string1, english_font, black_brush, header_rect);
                    g.DrawString(header_string2, english_font, black_brush, header_rect, hs2sf);

                    cury += this.HeaderPanelHeight;
                    // int basex = curx, basey = cury;

                    // Draw Guide lines
                    int guide_line_margin = (int)(0.05 * this.DPI);
                    int guide_line_thickness = this.GuideLineThickness;

                    int farx = curx + total_width, fary = cury + total_grid_height;

                    g.FillRectangle(black_brush, 0, cury, curx - guide_line_margin, guide_line_thickness);
                    g.FillRectangle(black_brush, curx, 0, guide_line_thickness, cury - guide_line_margin);

                    g.FillRectangle(black_brush, farx + guide_line_margin, cury, page_width - farx - guide_line_margin, guide_line_thickness);
                    g.FillRectangle(black_brush, farx - guide_line_thickness, 0, guide_line_thickness, cury - guide_line_margin);

                    g.FillRectangle(black_brush, 0, fary - guide_line_thickness, curx - guide_line_margin, guide_line_thickness);
                    g.FillRectangle(black_brush, curx, fary + guide_line_margin, guide_line_thickness, page_height - fary - guide_line_margin);

                    g.FillRectangle(black_brush, farx + guide_line_margin, fary - guide_line_thickness, page_width - farx - guide_line_margin, guide_line_thickness);
                    g.FillRectangle(black_brush, farx - guide_line_thickness, fary + guide_line_margin, guide_line_thickness, page_height - fary - guide_line_margin);

                    // Vertical guide lines
                    g.FillRectangle(black_brush, curx- guide_line_thickness, cury, guide_line_thickness, fary - cury);
                    g.FillRectangle(black_brush, farx, cury, guide_line_thickness, fary - cury);

                    int l = 0;

                    // Draw character input grids
                    for (int r = 0; r < RowsPerPage; r++)
                    {
                        for (int c = 0; c < actual_cols; c++)
                        {
                            Point kp1 = new Point(curx, cury);
                            Point kp2 = new Point(curx + grid_width, cury);
                            Point kp3 = new Point(curx, cury + label_box_height);
                            Point kp4 = new Point(kp2.X, kp3.Y);
                            Point kp5 = new Point(curx, cury + grid_height);
                            Point kp6 = new Point(kp2.X, kp5.Y);

                            g.FillRectangle(light_brush, new Rectangle(kp1.X, kp1.Y, grid_width, label_box_height));

                            g.DrawLine(thick_pen, kp1, kp2);
                            g.DrawLine(thin_pen, kp3, kp4);
                            g.DrawLine(thick_pen2, kp5, kp6);
                            g.DrawLine(thick_pen, kp1, kp5);
                            g.DrawLine(thick_pen, kp2, kp6);

                            //g.DrawRectangle(faint_pen, kp3.X + box_inside_margin, kp3.Y + box_inside_margin, box_inside_width, box_inside_height);
                            g.DrawLine(faint_pen2, kp3.X + box_inside_margin, kp3.Y + matra_line_y, kp3.X + box_inside_margin + box_inside_width, kp3.Y + matra_line_y);

                            for (int i = 1; i < this.ColumnSpanPerCharacter; i++)
                            {
                                Point kp7 = new Point(curx + box_width * i, cury + label_box_height);
                                Point kp8 = new Point(kp7.X, kp5.Y);

                                g.DrawLine(thin_pen, kp7, kp8);

                                //g.DrawRectangle(faint_pen, kp7.X + box_inside_margin, kp7.Y + box_inside_margin, box_inside_width, box_inside_height);
                                g.DrawLine(faint_pen2, kp7.X + box_inside_margin, kp7.Y + matra_line_y, kp7.X + box_inside_margin + box_inside_width, kp7.Y + matra_line_y);
                            }                            

                            if (labels.Count > l)
                            {
                                //Draw label
                                string label = labels[l];
                                g.DrawString(label, bangla_font, black_brush, new RectangleF(kp1.X, kp1.Y + 4, grid_width, label_box_height), label_string_format);

                                int letter_id = (form_number - 1) * (this.RowsPerPage * actual_cols) + l + 1;
                                g.DrawString(letter_id.ToString(), letter_id_font, grey_brush, new RectangleF(kp1.X, kp1.Y + 4, grid_width, label_box_height), id_string_format);
                            }
                            l++;

                            curx += grid_width;
                        }

                        curx = margin_x;
                        cury += grid_height;
                    }
                }

                this.FormNavigator.FormImages.Add((Bitmap)bmp.Clone());
            }

            GC.Collect();
            //bmp.Show();
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
            if (this.RowsPerPage < 5) this.RowsPerPage = 10;
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
                this.LabelFontSize = GetAutoFontSize();
            }
            else
            {
                if (this.LabelFontSize > 0 && this.LabelFontSize < 8) this.LabelFontSize = 8;
                if (this.LabelFontSize > this.LabelBoxHeight) this.LabelFontSize = this.LabelBoxHeight;
            }
        }

        void LogError(string error, string additional_data = "")
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        float GetAutoFontSize()
        {
            float cur_size = 8, prev_size = 4;
            float max_height = this.LabelBoxHeight * 1.0F;

            string test_string = @"ক্কৌগ্ধ্যস্থ্যু";            

            using (Bitmap bmp = new Bitmap(this.PageWidth, this.PageHeight))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    int max_iteration = 20, iteration = 0;

                    while (iteration < max_iteration)
                    {
                        Font f = new Font(this.LabelFont, cur_size);
                        var text_height = g.MeasureString(test_string, f).Height;

                        if(Math.Abs(max_height - text_height) < (max_height * .05)) break;

                        if (text_height > max_height)
                        {
                            if (cur_size > prev_size)
                            {
                                float cur_copy = cur_size;
                                cur_size = (cur_size + prev_size) / 2F;
                                prev_size = cur_copy;
                            }
                            else
                            {
                                float cur_copy = cur_size;
                                cur_size /= 2F;
                                prev_size = cur_copy;
                            }

                        }
                        else if (text_height < max_height)
                        {
                            if (prev_size < cur_size)
                            {
                                float cur_copy = cur_size;
                                cur_size *= 2F;
                                prev_size = cur_copy;
                            }
                            else
                            {
                                float cur_copy = cur_size;
                                cur_size = (prev_size + cur_size) / 2F;
                                prev_size = cur_copy;
                            }
                        }

                        iteration++;
                    }
                }
            }

            return cur_size;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            SelectInputFile();
        }

        private void btnCreateDataForms_Click(object sender, EventArgs e)
        {
            CreateDataForms();
        }

        private void ToolPanel_Resize(object sender, EventArgs e)
        {
            panelFormToolbar.Left = (ToolPanel.Width - panelFormToolbar.Width) / 2;
        }

        private void ImagePanel_Resize(object sender, EventArgs e)
        {
            if (imgCurrentForm.Dock == DockStyle.None)
            {
                if (ImagePanel.Width > imgCurrentForm.Width)
                {
                    imgCurrentForm.Left = (ImagePanel.Width - imgCurrentForm.Width) / 2;
                }
                else
                {
                    imgCurrentForm.Left = 0;
                }
            }
        }

        private void imgCurrentForm_Resize(object sender, EventArgs e)
        {
            if (imgCurrentForm.Dock == DockStyle.None)
            {
                if (ImagePanel.Width > imgCurrentForm.Width)
                {
                    imgCurrentForm.Left = (ImagePanel.Width - imgCurrentForm.Width) / 2;
                }
                else
                {
                    imgCurrentForm.Left = 0;
                }
            }
        }

        private void btnViewConfigFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.ConfigFilePath);
        }

        private void btnReloadConfigs_Click(object sender, EventArgs e)
        {
            this.ConfigFileReader.Reload();
            LoadConfigs();
        }
    }
}
