namespace TLABS.OCR.CHBCR.FormProcessor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CurrentScanInfoPanel = new System.Windows.Forms.Panel();
            this.btnSignalToStop = new System.Windows.Forms.Button();
            this.labSl = new System.Windows.Forms.Label();
            this.labProgress = new System.Windows.Forms.Label();
            this.progressCurrent = new System.Windows.Forms.ProgressBar();
            this.picCurrentSmall = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.nudFormNo = new System.Windows.Forms.NumericUpDown();
            this.labHeader = new System.Windows.Forms.Label();
            this.btnStartScanning = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.tbSelectedFolder = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.picCurrentLarge = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ThumbnailPanel = new System.Windows.Forms.Panel();
            this.flpThumbnails = new System.Windows.Forms.FlowLayoutPanel();
            this.FolderViewHeaderPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.CurrentScanInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentSmall)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFormNo)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentLarge)).BeginInit();
            this.ThumbnailPanel.SuspendLayout();
            this.FolderViewHeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.panel1.Controls.Add(this.CurrentScanInfoPanel);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(682, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 753);
            this.panel1.TabIndex = 0;
            // 
            // CurrentScanInfoPanel
            // 
            this.CurrentScanInfoPanel.Controls.Add(this.btnSignalToStop);
            this.CurrentScanInfoPanel.Controls.Add(this.labSl);
            this.CurrentScanInfoPanel.Controls.Add(this.labProgress);
            this.CurrentScanInfoPanel.Controls.Add(this.progressCurrent);
            this.CurrentScanInfoPanel.Controls.Add(this.picCurrentSmall);
            this.CurrentScanInfoPanel.Controls.Add(this.label4);
            this.CurrentScanInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentScanInfoPanel.Location = new System.Drawing.Point(0, 246);
            this.CurrentScanInfoPanel.Name = "CurrentScanInfoPanel";
            this.CurrentScanInfoPanel.Size = new System.Drawing.Size(500, 476);
            this.CurrentScanInfoPanel.TabIndex = 7;
            this.CurrentScanInfoPanel.Visible = false;
            // 
            // btnSignalToStop
            // 
            this.btnSignalToStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignalToStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSignalToStop.FlatAppearance.BorderSize = 0;
            this.btnSignalToStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignalToStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignalToStop.ForeColor = System.Drawing.Color.White;
            this.btnSignalToStop.Location = new System.Drawing.Point(152, 409);
            this.btnSignalToStop.Name = "btnSignalToStop";
            this.btnSignalToStop.Size = new System.Drawing.Size(193, 49);
            this.btnSignalToStop.TabIndex = 10;
            this.btnSignalToStop.Text = "Signal to stop";
            this.btnSignalToStop.UseVisualStyleBackColor = false;
            this.btnSignalToStop.Visible = false;
            this.btnSignalToStop.Click += new System.EventHandler(this.btnSignalToStop_Click);
            // 
            // labSl
            // 
            this.labSl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labSl.Location = new System.Drawing.Point(102, 48);
            this.labSl.Name = "labSl";
            this.labSl.Size = new System.Drawing.Size(296, 24);
            this.labSl.TabIndex = 9;
            this.labSl.Text = "0/0";
            this.labSl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labProgress
            // 
            this.labProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.labProgress.Location = new System.Drawing.Point(46, 394);
            this.labProgress.Name = "labProgress";
            this.labProgress.Size = new System.Drawing.Size(413, 22);
            this.labProgress.TabIndex = 8;
            this.labProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressCurrent
            // 
            this.progressCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.progressCurrent.Location = new System.Drawing.Point(46, 381);
            this.progressCurrent.Name = "progressCurrent";
            this.progressCurrent.Size = new System.Drawing.Size(413, 10);
            this.progressCurrent.TabIndex = 7;
            // 
            // picCurrentSmall
            // 
            this.picCurrentSmall.Location = new System.Drawing.Point(98, 75);
            this.picCurrentSmall.Name = "picCurrentSmall";
            this.picCurrentSmall.Size = new System.Drawing.Size(300, 300);
            this.picCurrentSmall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCurrentSmall.TabIndex = 6;
            this.picCurrentSmall.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label4.Location = new System.Drawing.Point(98, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Currently processing..";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.panel7.Controls.Add(this.label3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 722);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(500, 31);
            this.panel7.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "TLABS + CSTE © 2018";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnLoad);
            this.panel6.Controls.Add(this.nudFormNo);
            this.panel6.Controls.Add(this.labHeader);
            this.panel6.Controls.Add(this.btnStartScanning);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.btnSelectFolder);
            this.panel6.Controls.Add(this.tbSelectedFolder);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(500, 246);
            this.panel6.TabIndex = 5;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnLoad.Location = new System.Drawing.Point(171, 194);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(104, 30);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // nudFormNo
            // 
            this.nudFormNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.nudFormNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudFormNo.Font = new System.Drawing.Font("Arial", 9F);
            this.nudFormNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.nudFormNo.Location = new System.Drawing.Point(33, 197);
            this.nudFormNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFormNo.Name = "nudFormNo";
            this.nudFormNo.Size = new System.Drawing.Size(132, 25);
            this.nudFormNo.TabIndex = 5;
            this.nudFormNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labHeader
            // 
            this.labHeader.AutoSize = true;
            this.labHeader.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHeader.Location = new System.Drawing.Point(27, 48);
            this.labHeader.Name = "labHeader";
            this.labHeader.Size = new System.Drawing.Size(337, 33);
            this.labHeader.TabIndex = 0;
            this.labHeader.Text = "CHBCR Form Processor";
            // 
            // btnStartScanning
            // 
            this.btnStartScanning.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartScanning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnStartScanning.Location = new System.Drawing.Point(281, 194);
            this.btnStartScanning.Name = "btnStartScanning";
            this.btnStartScanning.Size = new System.Drawing.Size(169, 30);
            this.btnStartScanning.TabIndex = 4;
            this.btnStartScanning.Text = "Start processing";
            this.btnStartScanning.UseVisualStyleBackColor = true;
            this.btnStartScanning.Click += new System.EventHandler(this.btnStartScanning_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label5.Location = new System.Drawing.Point(31, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Form number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label1.Location = new System.Drawing.Point(31, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select folder to scan";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFolder.Location = new System.Drawing.Point(415, 133);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(35, 30);
            this.btnSelectFolder.TabIndex = 3;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // tbSelectedFolder
            // 
            this.tbSelectedFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.tbSelectedFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSelectedFolder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSelectedFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tbSelectedFolder.Location = new System.Drawing.Point(34, 136);
            this.tbSelectedFolder.Name = "tbSelectedFolder";
            this.tbSelectedFolder.Size = new System.Drawing.Size(375, 25);
            this.tbSelectedFolder.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.ThumbnailPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(682, 753);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.picCurrentLarge);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(253, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(429, 753);
            this.panel4.TabIndex = 2;
            // 
            // picCurrentLarge
            // 
            this.picCurrentLarge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCurrentLarge.Location = new System.Drawing.Point(0, 0);
            this.picCurrentLarge.Name = "picCurrentLarge";
            this.picCurrentLarge.Size = new System.Drawing.Size(429, 753);
            this.picCurrentLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCurrentLarge.TabIndex = 0;
            this.picCurrentLarge.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(250, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 753);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // ThumbnailPanel
            // 
            this.ThumbnailPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.ThumbnailPanel.Controls.Add(this.flpThumbnails);
            this.ThumbnailPanel.Controls.Add(this.FolderViewHeaderPanel);
            this.ThumbnailPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ThumbnailPanel.Location = new System.Drawing.Point(0, 0);
            this.ThumbnailPanel.Name = "ThumbnailPanel";
            this.ThumbnailPanel.Size = new System.Drawing.Size(250, 753);
            this.ThumbnailPanel.TabIndex = 0;
            this.ThumbnailPanel.Visible = false;
            // 
            // flpThumbnails
            // 
            this.flpThumbnails.AutoScroll = true;
            this.flpThumbnails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpThumbnails.Location = new System.Drawing.Point(0, 78);
            this.flpThumbnails.Name = "flpThumbnails";
            this.flpThumbnails.Size = new System.Drawing.Size(250, 675);
            this.flpThumbnails.TabIndex = 1;
            // 
            // FolderViewHeaderPanel
            // 
            this.FolderViewHeaderPanel.BackColor = System.Drawing.Color.LightGray;
            this.FolderViewHeaderPanel.Controls.Add(this.label2);
            this.FolderViewHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FolderViewHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.FolderViewHeaderPanel.Name = "FolderViewHeaderPanel";
            this.FolderViewHeaderPanel.Size = new System.Drawing.Size(250, 78);
            this.FolderViewHeaderPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Folder view";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHBCR Form Processor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.CurrentScanInfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentSmall)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFormNo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentLarge)).EndInit();
            this.ThumbnailPanel.ResumeLayout(false);
            this.FolderViewHeaderPanel.ResumeLayout(false);
            this.FolderViewHeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnStartScanning;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox tbSelectedFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel ThumbnailPanel;
        private System.Windows.Forms.FlowLayoutPanel flpThumbnails;
        private System.Windows.Forms.Panel FolderViewHeaderPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picCurrentLarge;
        private System.Windows.Forms.Panel CurrentScanInfoPanel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudFormNo;
        private System.Windows.Forms.PictureBox picCurrentSmall;
        private System.Windows.Forms.ProgressBar progressCurrent;
        private System.Windows.Forms.Label labProgress;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label labSl;
        private System.Windows.Forms.Button btnSignalToStop;
    }
}

