namespace TLABS.OCR.CHBCR.LetterImageProcessor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.ProgressPanel = new System.Windows.Forms.Panel();
            this.labCurrentFile = new System.Windows.Forms.Label();
            this.labCurrentFolder = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.FoldersSelectionPanel = new System.Windows.Forms.Panel();
            this.txtSourceFolderPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectSourceFolder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelectDestinationFolder = new System.Windows.Forms.Button();
            this.txtDestinationFolderPath = new System.Windows.Forms.TextBox();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.comboOutputImageFormat = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.panelRenameOptions = new System.Windows.Forms.Panel();
            this.txtRenamePrefix = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cbRename = new System.Windows.Forms.CheckBox();
            this.panelResize = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtResizeHeight = new System.Windows.Forms.TextBox();
            this.txtResizeWidth = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbResize = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panelOption_Binarization = new System.Windows.Forms.Panel();
            this.cbAutoBinarizationThreshold = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.sliderBinarizationThreshold = new System.Windows.Forms.TrackBar();
            this.labBinarizationThreshold = new System.Windows.Forms.Label();
            this.cbApplyConvolution = new System.Windows.Forms.CheckBox();
            this.cbBinarize = new System.Windows.Forms.CheckBox();
            this.cbCropToFit = new System.Windows.Forms.CheckBox();
            this.panelOption_ConvolutionKernel = new System.Windows.Forms.Panel();
            this.comboConvolutionPresets = new System.Windows.Forms.ComboBox();
            this.txtCM_22 = new System.Windows.Forms.TextBox();
            this.txtCM_21 = new System.Windows.Forms.TextBox();
            this.txtCM_12 = new System.Windows.Forms.TextBox();
            this.txtCM_11 = new System.Windows.Forms.TextBox();
            this.txtCM_20 = new System.Windows.Forms.TextBox();
            this.txtCM_02 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCM_10 = new System.Windows.Forms.TextBox();
            this.txtCM_01 = new System.Windows.Forms.TextBox();
            this.txtCM_00 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelCropToFitOptions = new System.Windows.Forms.Panel();
            this.txtCropMargin = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.ProgressPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.FoldersSelectionPanel.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.panelRenameOptions.SuspendLayout();
            this.panelResize.SuspendLayout();
            this.panelOption_Binarization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBinarizationThreshold)).BeginInit();
            this.panelOption_ConvolutionKernel.SuspendLayout();
            this.panelCropToFitOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1382, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Letter processor";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.panelFooter.Controls.Add(this.label3);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 913);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1382, 40);
            this.panelFooter.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1216, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "TLABS + CSTE © 2018";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.panelContent.Controls.Add(this.ProgressPanel);
            this.panelContent.Controls.Add(this.ButtonPanel);
            this.panelContent.Controls.Add(this.FoldersSelectionPanel);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1382, 853);
            this.panelContent.TabIndex = 2;
            // 
            // ProgressPanel
            // 
            this.ProgressPanel.Controls.Add(this.labCurrentFile);
            this.ProgressPanel.Controls.Add(this.labCurrentFolder);
            this.ProgressPanel.Controls.Add(this.label7);
            this.ProgressPanel.Controls.Add(this.label6);
            this.ProgressPanel.Controls.Add(this.label4);
            this.ProgressPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressPanel.Location = new System.Drawing.Point(0, 202);
            this.ProgressPanel.Name = "ProgressPanel";
            this.ProgressPanel.Size = new System.Drawing.Size(1382, 535);
            this.ProgressPanel.TabIndex = 12;
            this.ProgressPanel.Visible = false;
            // 
            // labCurrentFile
            // 
            this.labCurrentFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCurrentFile.Location = new System.Drawing.Point(118, 115);
            this.labCurrentFile.Margin = new System.Windows.Forms.Padding(3, 0, 100, 0);
            this.labCurrentFile.Name = "labCurrentFile";
            this.labCurrentFile.Size = new System.Drawing.Size(606, 55);
            this.labCurrentFile.TabIndex = 10;
            this.labCurrentFile.Text = "---";
            // 
            // labCurrentFolder
            // 
            this.labCurrentFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCurrentFolder.Location = new System.Drawing.Point(118, 70);
            this.labCurrentFolder.Margin = new System.Windows.Forms.Padding(3, 0, 50, 0);
            this.labCurrentFolder.Name = "labCurrentFolder";
            this.labCurrentFolder.Size = new System.Drawing.Size(596, 45);
            this.labCurrentFolder.TabIndex = 10;
            this.labCurrentFolder.Text = "---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(50, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "File: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(50, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Folder:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Currently Processing...";
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.btnStop);
            this.ButtonPanel.Controls.Add(this.btnStart);
            this.ButtonPanel.Controls.Add(this.btnPauseResume);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 737);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(1382, 116);
            this.ButtonPanel.TabIndex = 11;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(506, 29);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(209, 53);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(53, 29);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(209, 53);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnPauseResume.FlatAppearance.BorderSize = 0;
            this.btnPauseResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPauseResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPauseResume.ForeColor = System.Drawing.Color.White;
            this.btnPauseResume.Location = new System.Drawing.Point(280, 29);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(209, 53);
            this.btnPauseResume.TabIndex = 9;
            this.btnPauseResume.Text = "Pause";
            this.btnPauseResume.UseVisualStyleBackColor = false;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // FoldersSelectionPanel
            // 
            this.FoldersSelectionPanel.Controls.Add(this.txtSourceFolderPath);
            this.FoldersSelectionPanel.Controls.Add(this.label2);
            this.FoldersSelectionPanel.Controls.Add(this.btnSelectSourceFolder);
            this.FoldersSelectionPanel.Controls.Add(this.label5);
            this.FoldersSelectionPanel.Controls.Add(this.btnSelectDestinationFolder);
            this.FoldersSelectionPanel.Controls.Add(this.txtDestinationFolderPath);
            this.FoldersSelectionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FoldersSelectionPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FoldersSelectionPanel.Location = new System.Drawing.Point(0, 0);
            this.FoldersSelectionPanel.Name = "FoldersSelectionPanel";
            this.FoldersSelectionPanel.Size = new System.Drawing.Size(1382, 202);
            this.FoldersSelectionPanel.TabIndex = 10;
            // 
            // txtSourceFolderPath
            // 
            this.txtSourceFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceFolderPath.Location = new System.Drawing.Point(53, 66);
            this.txtSourceFolderPath.Name = "txtSourceFolderPath";
            this.txtSourceFolderPath.Size = new System.Drawing.Size(603, 27);
            this.txtSourceFolderPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(50, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Source folder";
            // 
            // btnSelectSourceFolder
            // 
            this.btnSelectSourceFolder.Location = new System.Drawing.Point(662, 64);
            this.btnSelectSourceFolder.Name = "btnSelectSourceFolder";
            this.btnSelectSourceFolder.Size = new System.Drawing.Size(53, 33);
            this.btnSelectSourceFolder.TabIndex = 4;
            this.btnSelectSourceFolder.Text = "...";
            this.btnSelectSourceFolder.UseVisualStyleBackColor = true;
            this.btnSelectSourceFolder.Click += new System.EventHandler(this.btnSelectSourceFolder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(50, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Destination folder";
            // 
            // btnSelectDestinationFolder
            // 
            this.btnSelectDestinationFolder.Location = new System.Drawing.Point(662, 137);
            this.btnSelectDestinationFolder.Name = "btnSelectDestinationFolder";
            this.btnSelectDestinationFolder.Size = new System.Drawing.Size(53, 34);
            this.btnSelectDestinationFolder.TabIndex = 8;
            this.btnSelectDestinationFolder.Text = "...";
            this.btnSelectDestinationFolder.UseVisualStyleBackColor = true;
            this.btnSelectDestinationFolder.Click += new System.EventHandler(this.btnSelectDestinationFolder_Click);
            // 
            // txtDestinationFolderPath
            // 
            this.txtDestinationFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestinationFolderPath.Location = new System.Drawing.Point(53, 140);
            this.txtDestinationFolderPath.Name = "txtDestinationFolderPath";
            this.txtDestinationFolderPath.Size = new System.Drawing.Size(603, 27);
            this.txtDestinationFolderPath.TabIndex = 7;
            // 
            // panelOptions
            // 
            this.panelOptions.AutoScroll = true;
            this.panelOptions.Controls.Add(this.panelCropToFitOptions);
            this.panelOptions.Controls.Add(this.comboOutputImageFormat);
            this.panelOptions.Controls.Add(this.label21);
            this.panelOptions.Controls.Add(this.panelRenameOptions);
            this.panelOptions.Controls.Add(this.label19);
            this.panelOptions.Controls.Add(this.cbRename);
            this.panelOptions.Controls.Add(this.panelResize);
            this.panelOptions.Controls.Add(this.label15);
            this.panelOptions.Controls.Add(this.cbResize);
            this.panelOptions.Controls.Add(this.label13);
            this.panelOptions.Controls.Add(this.label12);
            this.panelOptions.Controls.Add(this.label11);
            this.panelOptions.Controls.Add(this.panelOption_Binarization);
            this.panelOptions.Controls.Add(this.cbApplyConvolution);
            this.panelOptions.Controls.Add(this.cbBinarize);
            this.panelOptions.Controls.Add(this.cbCropToFit);
            this.panelOptions.Controls.Add(this.panelOption_ConvolutionKernel);
            this.panelOptions.Controls.Add(this.label8);
            this.panelOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelOptions.Location = new System.Drawing.Point(782, 60);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(600, 853);
            this.panelOptions.TabIndex = 3;
            // 
            // comboOutputImageFormat
            // 
            this.comboOutputImageFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboOutputImageFormat.FormattingEnabled = true;
            this.comboOutputImageFormat.Items.AddRange(new object[] {
            "Bitmap 24bpp",
            "Bitmap 8bpp",
            "Bitmap 1bpp",
            "Jpeg",
            "PNG"});
            this.comboOutputImageFormat.Location = new System.Drawing.Point(143, 67);
            this.comboOutputImageFormat.Name = "comboOutputImageFormat";
            this.comboOutputImageFormat.Size = new System.Drawing.Size(309, 28);
            this.comboOutputImageFormat.TabIndex = 11;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label21.Location = new System.Drawing.Point(35, 69);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 20);
            this.label21.TabIndex = 11;
            this.label21.Text = "Output as";
            // 
            // panelRenameOptions
            // 
            this.panelRenameOptions.Controls.Add(this.txtRenamePrefix);
            this.panelRenameOptions.Controls.Add(this.label20);
            this.panelRenameOptions.Location = new System.Drawing.Point(118, 722);
            this.panelRenameOptions.Name = "panelRenameOptions";
            this.panelRenameOptions.Size = new System.Drawing.Size(433, 38);
            this.panelRenameOptions.TabIndex = 23;
            // 
            // txtRenamePrefix
            // 
            this.txtRenamePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtRenamePrefix.Location = new System.Drawing.Point(88, 5);
            this.txtRenamePrefix.MinimumSize = new System.Drawing.Size(50, 25);
            this.txtRenamePrefix.Multiline = true;
            this.txtRenamePrefix.Name = "txtRenamePrefix";
            this.txtRenamePrefix.Size = new System.Drawing.Size(110, 25);
            this.txtRenamePrefix.TabIndex = 22;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label20.Location = new System.Drawing.Point(20, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 20);
            this.label20.TabIndex = 22;
            this.label20.Text = "Prefix";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.Gray;
            this.label19.Location = new System.Drawing.Point(35, 695);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 22);
            this.label19.TabIndex = 22;
            this.label19.Text = "Step 5";
            // 
            // cbRename
            // 
            this.cbRename.AutoSize = true;
            this.cbRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbRename.Location = new System.Drawing.Point(118, 695);
            this.cbRename.Name = "cbRename";
            this.cbRename.Size = new System.Drawing.Size(186, 24);
            this.cbRename.TabIndex = 21;
            this.cbRename.Text = "Rename sequentially";
            this.cbRename.UseVisualStyleBackColor = true;
            this.cbRename.CheckedChanged += new System.EventHandler(this.cbRename_CheckedChanged);
            // 
            // panelResize
            // 
            this.panelResize.Controls.Add(this.checkBox1);
            this.panelResize.Controls.Add(this.txtResizeHeight);
            this.panelResize.Controls.Add(this.txtResizeWidth);
            this.panelResize.Controls.Add(this.label18);
            this.panelResize.Controls.Add(this.label17);
            this.panelResize.Controls.Add(this.label16);
            this.panelResize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panelResize.Location = new System.Drawing.Point(118, 584);
            this.panelResize.Name = "panelResize";
            this.panelResize.Size = new System.Drawing.Size(433, 101);
            this.panelResize.TabIndex = 20;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(20, 65);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(187, 24);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "Maintain aspect ratio";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtResizeHeight
            // 
            this.txtResizeHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtResizeHeight.Location = new System.Drawing.Point(123, 32);
            this.txtResizeHeight.MinimumSize = new System.Drawing.Size(50, 25);
            this.txtResizeHeight.Multiline = true;
            this.txtResizeHeight.Name = "txtResizeHeight";
            this.txtResizeHeight.Size = new System.Drawing.Size(75, 25);
            this.txtResizeHeight.TabIndex = 14;
            this.txtResizeHeight.Text = "50";
            this.txtResizeHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtResizeWidth
            // 
            this.txtResizeWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtResizeWidth.Location = new System.Drawing.Point(20, 32);
            this.txtResizeWidth.MinimumSize = new System.Drawing.Size(50, 25);
            this.txtResizeWidth.Multiline = true;
            this.txtResizeWidth.Name = "txtResizeWidth";
            this.txtResizeWidth.Size = new System.Drawing.Size(75, 25);
            this.txtResizeWidth.TabIndex = 11;
            this.txtResizeWidth.Text = "50";
            this.txtResizeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(101, 36);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 18);
            this.label18.TabIndex = 13;
            this.label18.Text = "X";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label17.Location = new System.Drawing.Point(116, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 20);
            this.label17.TabIndex = 12;
            this.label17.Text = "Height";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label16.Location = new System.Drawing.Point(20, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 20);
            this.label16.TabIndex = 11;
            this.label16.Text = "Width ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.Gray;
            this.label15.Location = new System.Drawing.Point(35, 553);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 22);
            this.label15.TabIndex = 19;
            this.label15.Text = "Step 4";
            // 
            // cbResize
            // 
            this.cbResize.AutoSize = true;
            this.cbResize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbResize.Location = new System.Drawing.Point(118, 553);
            this.cbResize.Name = "cbResize";
            this.cbResize.Size = new System.Drawing.Size(83, 24);
            this.cbResize.TabIndex = 18;
            this.cbResize.Text = "Resize";
            this.cbResize.UseVisualStyleBackColor = true;
            this.cbResize.CheckedChanged += new System.EventHandler(this.cbResize_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Gray;
            this.label13.Location = new System.Drawing.Point(35, 472);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 22);
            this.label13.TabIndex = 17;
            this.label13.Text = "Step 3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(35, 289);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 22);
            this.label12.TabIndex = 17;
            this.label12.Text = "Step 2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(35, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 22);
            this.label11.TabIndex = 17;
            this.label11.Text = "Step 1";
            // 
            // panelOption_Binarization
            // 
            this.panelOption_Binarization.Controls.Add(this.cbAutoBinarizationThreshold);
            this.panelOption_Binarization.Controls.Add(this.label10);
            this.panelOption_Binarization.Controls.Add(this.sliderBinarizationThreshold);
            this.panelOption_Binarization.Controls.Add(this.labBinarizationThreshold);
            this.panelOption_Binarization.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panelOption_Binarization.Location = new System.Drawing.Point(118, 316);
            this.panelOption_Binarization.Name = "panelOption_Binarization";
            this.panelOption_Binarization.Size = new System.Drawing.Size(433, 151);
            this.panelOption_Binarization.TabIndex = 16;
            // 
            // cbAutoBinarizationThreshold
            // 
            this.cbAutoBinarizationThreshold.AutoSize = true;
            this.cbAutoBinarizationThreshold.Checked = true;
            this.cbAutoBinarizationThreshold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoBinarizationThreshold.Location = new System.Drawing.Point(25, 45);
            this.cbAutoBinarizationThreshold.Name = "cbAutoBinarizationThreshold";
            this.cbAutoBinarizationThreshold.Size = new System.Drawing.Size(212, 24);
            this.cbAutoBinarizationThreshold.TabIndex = 21;
            this.cbAutoBinarizationThreshold.Text = "Determine automatically";
            this.cbAutoBinarizationThreshold.UseVisualStyleBackColor = true;
            this.cbAutoBinarizationThreshold.CheckedChanged += new System.EventHandler(this.cbAutoBinarizationThreshold_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Binarization threshold";
            // 
            // sliderBinarizationThreshold
            // 
            this.sliderBinarizationThreshold.Enabled = false;
            this.sliderBinarizationThreshold.Location = new System.Drawing.Point(14, 87);
            this.sliderBinarizationThreshold.Maximum = 192;
            this.sliderBinarizationThreshold.Minimum = 64;
            this.sliderBinarizationThreshold.Name = "sliderBinarizationThreshold";
            this.sliderBinarizationThreshold.Size = new System.Drawing.Size(320, 56);
            this.sliderBinarizationThreshold.TabIndex = 11;
            this.sliderBinarizationThreshold.TickFrequency = 8;
            this.sliderBinarizationThreshold.Value = 128;
            this.sliderBinarizationThreshold.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // labBinarizationThreshold
            // 
            this.labBinarizationThreshold.AutoSize = true;
            this.labBinarizationThreshold.Enabled = false;
            this.labBinarizationThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labBinarizationThreshold.Location = new System.Drawing.Point(340, 88);
            this.labBinarizationThreshold.Name = "labBinarizationThreshold";
            this.labBinarizationThreshold.Size = new System.Drawing.Size(45, 25);
            this.labBinarizationThreshold.TabIndex = 12;
            this.labBinarizationThreshold.Text = "128";
            // 
            // cbApplyConvolution
            // 
            this.cbApplyConvolution.AutoSize = true;
            this.cbApplyConvolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbApplyConvolution.Location = new System.Drawing.Point(118, 121);
            this.cbApplyConvolution.Name = "cbApplyConvolution";
            this.cbApplyConvolution.Size = new System.Drawing.Size(161, 24);
            this.cbApplyConvolution.TabIndex = 15;
            this.cbApplyConvolution.Text = "Apply convolution";
            this.cbApplyConvolution.UseVisualStyleBackColor = true;
            this.cbApplyConvolution.CheckedChanged += new System.EventHandler(this.cbApplyConvolution_CheckedChanged);
            // 
            // cbBinarize
            // 
            this.cbBinarize.AutoSize = true;
            this.cbBinarize.Checked = true;
            this.cbBinarize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBinarize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbBinarize.Location = new System.Drawing.Point(118, 289);
            this.cbBinarize.Name = "cbBinarize";
            this.cbBinarize.Size = new System.Drawing.Size(143, 24);
            this.cbBinarize.TabIndex = 14;
            this.cbBinarize.Text = "Binarize image";
            this.cbBinarize.UseVisualStyleBackColor = true;
            this.cbBinarize.CheckedChanged += new System.EventHandler(this.cbBinarize_CheckedChanged);
            // 
            // cbCropToFit
            // 
            this.cbCropToFit.AutoSize = true;
            this.cbCropToFit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbCropToFit.Location = new System.Drawing.Point(118, 472);
            this.cbCropToFit.Name = "cbCropToFit";
            this.cbCropToFit.Size = new System.Drawing.Size(105, 24);
            this.cbCropToFit.TabIndex = 13;
            this.cbCropToFit.Text = "Crop to fit";
            this.cbCropToFit.UseVisualStyleBackColor = true;
            this.cbCropToFit.CheckedChanged += new System.EventHandler(this.cbCropToFit_CheckedChanged);
            // 
            // panelOption_ConvolutionKernel
            // 
            this.panelOption_ConvolutionKernel.Controls.Add(this.comboConvolutionPresets);
            this.panelOption_ConvolutionKernel.Controls.Add(this.txtCM_22);
            this.panelOption_ConvolutionKernel.Controls.Add(this.txtCM_21);
            this.panelOption_ConvolutionKernel.Controls.Add(this.txtCM_12);
            this.panelOption_ConvolutionKernel.Controls.Add(this.txtCM_11);
            this.panelOption_ConvolutionKernel.Controls.Add(this.txtCM_20);
            this.panelOption_ConvolutionKernel.Controls.Add(this.txtCM_02);
            this.panelOption_ConvolutionKernel.Controls.Add(this.label14);
            this.panelOption_ConvolutionKernel.Controls.Add(this.label9);
            this.panelOption_ConvolutionKernel.Controls.Add(this.txtCM_10);
            this.panelOption_ConvolutionKernel.Controls.Add(this.txtCM_01);
            this.panelOption_ConvolutionKernel.Controls.Add(this.txtCM_00);
            this.panelOption_ConvolutionKernel.Enabled = false;
            this.panelOption_ConvolutionKernel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panelOption_ConvolutionKernel.Location = new System.Drawing.Point(118, 148);
            this.panelOption_ConvolutionKernel.Name = "panelOption_ConvolutionKernel";
            this.panelOption_ConvolutionKernel.Size = new System.Drawing.Size(433, 123);
            this.panelOption_ConvolutionKernel.TabIndex = 2;
            // 
            // comboConvolutionPresets
            // 
            this.comboConvolutionPresets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboConvolutionPresets.FormattingEnabled = true;
            this.comboConvolutionPresets.Items.AddRange(new object[] {
            "Default",
            "Preset 1",
            "Preset 2",
            "Preset 3"});
            this.comboConvolutionPresets.Location = new System.Drawing.Point(216, 34);
            this.comboConvolutionPresets.Name = "comboConvolutionPresets";
            this.comboConvolutionPresets.Size = new System.Drawing.Size(118, 28);
            this.comboConvolutionPresets.TabIndex = 10;
            this.comboConvolutionPresets.SelectedIndexChanged += new System.EventHandler(this.comboConvolutionPresets_SelectedIndexChanged);
            // 
            // txtCM_22
            // 
            this.txtCM_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCM_22.Location = new System.Drawing.Point(119, 88);
            this.txtCM_22.MinimumSize = new System.Drawing.Size(50, 25);
            this.txtCM_22.Multiline = true;
            this.txtCM_22.Name = "txtCM_22";
            this.txtCM_22.Size = new System.Drawing.Size(50, 25);
            this.txtCM_22.TabIndex = 0;
            this.txtCM_22.Text = "0.0";
            this.txtCM_22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCM_21
            // 
            this.txtCM_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCM_21.Location = new System.Drawing.Point(72, 88);
            this.txtCM_21.MinimumSize = new System.Drawing.Size(50, 25);
            this.txtCM_21.Multiline = true;
            this.txtCM_21.Name = "txtCM_21";
            this.txtCM_21.Size = new System.Drawing.Size(50, 25);
            this.txtCM_21.TabIndex = 0;
            this.txtCM_21.Text = "0.0";
            this.txtCM_21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCM_12
            // 
            this.txtCM_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCM_12.Location = new System.Drawing.Point(119, 61);
            this.txtCM_12.MinimumSize = new System.Drawing.Size(50, 25);
            this.txtCM_12.Multiline = true;
            this.txtCM_12.Name = "txtCM_12";
            this.txtCM_12.Size = new System.Drawing.Size(50, 25);
            this.txtCM_12.TabIndex = 0;
            this.txtCM_12.Text = "0.0";
            this.txtCM_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCM_11
            // 
            this.txtCM_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCM_11.Location = new System.Drawing.Point(72, 61);
            this.txtCM_11.MinimumSize = new System.Drawing.Size(50, 25);
            this.txtCM_11.Multiline = true;
            this.txtCM_11.Name = "txtCM_11";
            this.txtCM_11.Size = new System.Drawing.Size(50, 25);
            this.txtCM_11.TabIndex = 0;
            this.txtCM_11.Text = "1.0";
            this.txtCM_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCM_20
            // 
            this.txtCM_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCM_20.Location = new System.Drawing.Point(25, 88);
            this.txtCM_20.MinimumSize = new System.Drawing.Size(50, 25);
            this.txtCM_20.Multiline = true;
            this.txtCM_20.Name = "txtCM_20";
            this.txtCM_20.Size = new System.Drawing.Size(50, 25);
            this.txtCM_20.TabIndex = 0;
            this.txtCM_20.Text = "0.0";
            this.txtCM_20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCM_02
            // 
            this.txtCM_02.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCM_02.Location = new System.Drawing.Point(119, 34);
            this.txtCM_02.MinimumSize = new System.Drawing.Size(50, 25);
            this.txtCM_02.Multiline = true;
            this.txtCM_02.Name = "txtCM_02";
            this.txtCM_02.Size = new System.Drawing.Size(50, 25);
            this.txtCM_02.TabIndex = 0;
            this.txtCM_02.Text = "0.0";
            this.txtCM_02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.Location = new System.Drawing.Point(213, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 20);
            this.label14.TabIndex = 9;
            this.label14.Text = "Choose preset";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(20, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Convolution kernel";
            // 
            // txtCM_10
            // 
            this.txtCM_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCM_10.Location = new System.Drawing.Point(25, 61);
            this.txtCM_10.MinimumSize = new System.Drawing.Size(50, 25);
            this.txtCM_10.Multiline = true;
            this.txtCM_10.Name = "txtCM_10";
            this.txtCM_10.Size = new System.Drawing.Size(50, 25);
            this.txtCM_10.TabIndex = 0;
            this.txtCM_10.Text = "0.0";
            this.txtCM_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCM_01
            // 
            this.txtCM_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCM_01.Location = new System.Drawing.Point(72, 34);
            this.txtCM_01.MinimumSize = new System.Drawing.Size(50, 25);
            this.txtCM_01.Multiline = true;
            this.txtCM_01.Name = "txtCM_01";
            this.txtCM_01.Size = new System.Drawing.Size(50, 25);
            this.txtCM_01.TabIndex = 0;
            this.txtCM_01.Text = "0.0";
            this.txtCM_01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCM_00
            // 
            this.txtCM_00.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCM_00.Location = new System.Drawing.Point(25, 34);
            this.txtCM_00.MinimumSize = new System.Drawing.Size(50, 25);
            this.txtCM_00.Multiline = true;
            this.txtCM_00.Name = "txtCM_00";
            this.txtCM_00.Size = new System.Drawing.Size(50, 25);
            this.txtCM_00.TabIndex = 0;
            this.txtCM_00.Text = "0.0";
            this.txtCM_00.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(16, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 26);
            this.label8.TabIndex = 1;
            this.label8.Text = "Options";
            // 
            // panelCropToFitOptions
            // 
            this.panelCropToFitOptions.Controls.Add(this.txtCropMargin);
            this.panelCropToFitOptions.Controls.Add(this.label23);
            this.panelCropToFitOptions.Controls.Add(this.label22);
            this.panelCropToFitOptions.Location = new System.Drawing.Point(118, 502);
            this.panelCropToFitOptions.Name = "panelCropToFitOptions";
            this.panelCropToFitOptions.Size = new System.Drawing.Size(433, 38);
            this.panelCropToFitOptions.TabIndex = 24;
            // 
            // txtCropMargin
            // 
            this.txtCropMargin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCropMargin.Location = new System.Drawing.Point(88, 5);
            this.txtCropMargin.MinimumSize = new System.Drawing.Size(50, 25);
            this.txtCropMargin.Multiline = true;
            this.txtCropMargin.Name = "txtCropMargin";
            this.txtCropMargin.Size = new System.Drawing.Size(110, 25);
            this.txtCropMargin.TabIndex = 22;
            this.txtCropMargin.Text = "1";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label22.Location = new System.Drawing.Point(20, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 20);
            this.label22.TabIndex = 22;
            this.label22.Text = "Margin";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label23.Location = new System.Drawing.Point(204, 8);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(73, 20);
            this.label23.TabIndex = 22;
            this.label23.Text = "pixels(s)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 953);
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Letter Image Processor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.ProgressPanel.ResumeLayout(false);
            this.ProgressPanel.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            this.FoldersSelectionPanel.ResumeLayout(false);
            this.FoldersSelectionPanel.PerformLayout();
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.panelRenameOptions.ResumeLayout(false);
            this.panelRenameOptions.PerformLayout();
            this.panelResize.ResumeLayout(false);
            this.panelResize.PerformLayout();
            this.panelOption_Binarization.ResumeLayout(false);
            this.panelOption_Binarization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBinarizationThreshold)).EndInit();
            this.panelOption_ConvolutionKernel.ResumeLayout(false);
            this.panelOption_ConvolutionKernel.PerformLayout();
            this.panelCropToFitOptions.ResumeLayout(false);
            this.panelCropToFitOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSelectDestinationFolder;
        private System.Windows.Forms.TextBox txtDestinationFolderPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelectSourceFolder;
        private System.Windows.Forms.TextBox txtSourceFolderPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel FoldersSelectionPanel;
        private System.Windows.Forms.Panel ProgressPanel;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Label labCurrentFile;
        private System.Windows.Forms.Label labCurrentFolder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelOption_ConvolutionKernel;
        private System.Windows.Forms.TextBox txtCM_00;
        private System.Windows.Forms.TextBox txtCM_22;
        private System.Windows.Forms.TextBox txtCM_21;
        private System.Windows.Forms.TextBox txtCM_12;
        private System.Windows.Forms.TextBox txtCM_11;
        private System.Windows.Forms.TextBox txtCM_20;
        private System.Windows.Forms.TextBox txtCM_02;
        private System.Windows.Forms.TextBox txtCM_10;
        private System.Windows.Forms.TextBox txtCM_01;
        private System.Windows.Forms.Label labBinarizationThreshold;
        private System.Windows.Forms.TrackBar sliderBinarizationThreshold;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbBinarize;
        private System.Windows.Forms.CheckBox cbCropToFit;
        private System.Windows.Forms.CheckBox cbApplyConvolution;
        private System.Windows.Forms.Panel panelOption_Binarization;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboConvolutionPresets;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox cbResize;
        private System.Windows.Forms.Panel panelResize;
        private System.Windows.Forms.TextBox txtResizeHeight;
        private System.Windows.Forms.TextBox txtResizeWidth;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox cbAutoBinarizationThreshold;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox cbRename;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtRenamePrefix;
        private System.Windows.Forms.Panel panelRenameOptions;
        private System.Windows.Forms.ComboBox comboOutputImageFormat;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panelCropToFitOptions;
        private System.Windows.Forms.TextBox txtCropMargin;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
    }
}

