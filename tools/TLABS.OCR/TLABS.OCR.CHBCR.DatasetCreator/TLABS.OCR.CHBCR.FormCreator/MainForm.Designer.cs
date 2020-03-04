namespace TLABS.OCR.CHBCR.FormCreator
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
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.labelFooter = new System.Windows.Forms.Label();
            this.panelSelectFile = new System.Windows.Forms.Panel();
            this.btnCreateDataForms = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSelectedFile = new System.Windows.Forms.TextBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ImagePanel = new System.Windows.Forms.Panel();
            this.imgCurrentForm = new System.Windows.Forms.PictureBox();
            this.ToolPanel = new System.Windows.Forms.Panel();
            this.labCounter = new System.Windows.Forms.Label();
            this.panelFormToolbar = new System.Windows.Forms.Panel();
            this.btnPrevForm = new System.Windows.Forms.Button();
            this.btnExpandForm = new System.Windows.Forms.Button();
            this.btnPrintForm = new System.Windows.Forms.Button();
            this.btnSaveForm = new System.Windows.Forms.Button();
            this.btnNextForm = new System.Windows.Forms.Button();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnViewConfigFile = new System.Windows.Forms.Button();
            this.btnReloadConfigs = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panelSelectFile.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.ImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCurrentForm)).BeginInit();
            this.ToolPanel.SuspendLayout();
            this.panelFormToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1182, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(12, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(301, 29);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "CHBCR Data Form Creator";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.DimGray;
            this.panelFooter.Controls.Add(this.labelFooter);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.ForeColor = System.Drawing.Color.White;
            this.panelFooter.Location = new System.Drawing.Point(0, 723);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1182, 30);
            this.panelFooter.TabIndex = 1;
            // 
            // labelFooter
            // 
            this.labelFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFooter.AutoSize = true;
            this.labelFooter.Location = new System.Drawing.Point(957, 6);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(212, 17);
            this.labelFooter.TabIndex = 0;
            this.labelFooter.Text = " © 2018, TLABS + CSTE, NSTU ";
            // 
            // panelSelectFile
            // 
            this.panelSelectFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelSelectFile.Controls.Add(this.btnReloadConfigs);
            this.panelSelectFile.Controls.Add(this.btnViewConfigFile);
            this.panelSelectFile.Controls.Add(this.btnCreateDataForms);
            this.panelSelectFile.Controls.Add(this.btnSelectFile);
            this.panelSelectFile.Controls.Add(this.label1);
            this.panelSelectFile.Controls.Add(this.tbSelectedFile);
            this.panelSelectFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelectFile.Location = new System.Drawing.Point(0, 50);
            this.panelSelectFile.Name = "panelSelectFile";
            this.panelSelectFile.Size = new System.Drawing.Size(1182, 72);
            this.panelSelectFile.TabIndex = 2;
            // 
            // btnCreateDataForms
            // 
            this.btnCreateDataForms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateDataForms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(165)))));
            this.btnCreateDataForms.FlatAppearance.BorderSize = 0;
            this.btnCreateDataForms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateDataForms.Location = new System.Drawing.Point(1029, 33);
            this.btnCreateDataForms.Name = "btnCreateDataForms";
            this.btnCreateDataForms.Size = new System.Drawing.Size(140, 30);
            this.btnCreateDataForms.TabIndex = 3;
            this.btnCreateDataForms.Text = "Create data forms";
            this.btnCreateDataForms.UseVisualStyleBackColor = false;
            this.btnCreateDataForms.Click += new System.EventHandler(this.btnCreateDataForms_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(654, 33);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(42, 30);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select input file:";
            // 
            // tbSelectedFile
            // 
            this.tbSelectedFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSelectedFile.Location = new System.Drawing.Point(17, 35);
            this.tbSelectedFile.Name = "tbSelectedFile";
            this.tbSelectedFile.Size = new System.Drawing.Size(631, 24);
            this.tbSelectedFile.TabIndex = 0;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ImagePanel);
            this.MainPanel.Controls.Add(this.ToolPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 122);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1182, 601);
            this.MainPanel.TabIndex = 3;
            // 
            // ImagePanel
            // 
            this.ImagePanel.AutoScroll = true;
            this.ImagePanel.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.ImagePanel.AutoSize = true;
            this.ImagePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ImagePanel.Controls.Add(this.imgCurrentForm);
            this.ImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePanel.Location = new System.Drawing.Point(0, 0);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Padding = new System.Windows.Forms.Padding(10);
            this.ImagePanel.Size = new System.Drawing.Size(1182, 551);
            this.ImagePanel.TabIndex = 1;
            this.ImagePanel.Resize += new System.EventHandler(this.ImagePanel_Resize);
            // 
            // imgCurrentForm
            // 
            this.imgCurrentForm.BackColor = System.Drawing.Color.White;
            this.imgCurrentForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCurrentForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgCurrentForm.Location = new System.Drawing.Point(10, 10);
            this.imgCurrentForm.Name = "imgCurrentForm";
            this.imgCurrentForm.Size = new System.Drawing.Size(1162, 531);
            this.imgCurrentForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCurrentForm.TabIndex = 0;
            this.imgCurrentForm.TabStop = false;
            this.imgCurrentForm.Resize += new System.EventHandler(this.imgCurrentForm_Resize);
            // 
            // ToolPanel
            // 
            this.ToolPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.ToolPanel.Controls.Add(this.labCounter);
            this.ToolPanel.Controls.Add(this.panelFormToolbar);
            this.ToolPanel.Controls.Add(this.btnSaveAll);
            this.ToolPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolPanel.Location = new System.Drawing.Point(0, 551);
            this.ToolPanel.Name = "ToolPanel";
            this.ToolPanel.Size = new System.Drawing.Size(1182, 50);
            this.ToolPanel.TabIndex = 0;
            this.ToolPanel.Resize += new System.EventHandler(this.ToolPanel_Resize);
            // 
            // labCounter
            // 
            this.labCounter.AutoSize = true;
            this.labCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCounter.ForeColor = System.Drawing.Color.DimGray;
            this.labCounter.Location = new System.Drawing.Point(12, 13);
            this.labCounter.Name = "labCounter";
            this.labCounter.Size = new System.Drawing.Size(40, 25);
            this.labCounter.TabIndex = 7;
            this.labCounter.Text = "0/0";
            // 
            // panelFormToolbar
            // 
            this.panelFormToolbar.Controls.Add(this.btnPrevForm);
            this.panelFormToolbar.Controls.Add(this.btnExpandForm);
            this.panelFormToolbar.Controls.Add(this.btnPrintForm);
            this.panelFormToolbar.Controls.Add(this.btnSaveForm);
            this.panelFormToolbar.Controls.Add(this.btnNextForm);
            this.panelFormToolbar.Location = new System.Drawing.Point(160, 7);
            this.panelFormToolbar.Name = "panelFormToolbar";
            this.panelFormToolbar.Size = new System.Drawing.Size(463, 35);
            this.panelFormToolbar.TabIndex = 6;
            // 
            // btnPrevForm
            // 
            this.btnPrevForm.Location = new System.Drawing.Point(7, 3);
            this.btnPrevForm.Name = "btnPrevForm";
            this.btnPrevForm.Size = new System.Drawing.Size(75, 29);
            this.btnPrevForm.TabIndex = 0;
            this.btnPrevForm.Text = "<";
            this.btnPrevForm.UseVisualStyleBackColor = true;
            // 
            // btnExpandForm
            // 
            this.btnExpandForm.Location = new System.Drawing.Point(169, 3);
            this.btnExpandForm.Name = "btnExpandForm";
            this.btnExpandForm.Size = new System.Drawing.Size(127, 29);
            this.btnExpandForm.TabIndex = 2;
            this.btnExpandForm.Text = "View larger";
            this.btnExpandForm.UseVisualStyleBackColor = true;
            // 
            // btnPrintForm
            // 
            this.btnPrintForm.Location = new System.Drawing.Point(88, 3);
            this.btnPrintForm.Name = "btnPrintForm";
            this.btnPrintForm.Size = new System.Drawing.Size(75, 29);
            this.btnPrintForm.TabIndex = 1;
            this.btnPrintForm.Text = "Print";
            this.btnPrintForm.UseVisualStyleBackColor = true;
            // 
            // btnSaveForm
            // 
            this.btnSaveForm.Location = new System.Drawing.Point(302, 3);
            this.btnSaveForm.Name = "btnSaveForm";
            this.btnSaveForm.Size = new System.Drawing.Size(75, 29);
            this.btnSaveForm.TabIndex = 3;
            this.btnSaveForm.Text = "Save";
            this.btnSaveForm.UseVisualStyleBackColor = true;
            // 
            // btnNextForm
            // 
            this.btnNextForm.Location = new System.Drawing.Point(383, 3);
            this.btnNextForm.Name = "btnNextForm";
            this.btnNextForm.Size = new System.Drawing.Size(75, 29);
            this.btnNextForm.TabIndex = 4;
            this.btnNextForm.Text = ">";
            this.btnNextForm.UseVisualStyleBackColor = true;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAll.Location = new System.Drawing.Point(1069, 10);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(104, 29);
            this.btnSaveAll.TabIndex = 5;
            this.btnSaveAll.Text = "Save all";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            // 
            // btnViewConfigFile
            // 
            this.btnViewConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewConfigFile.BackColor = System.Drawing.Color.Silver;
            this.btnViewConfigFile.FlatAppearance.BorderSize = 0;
            this.btnViewConfigFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewConfigFile.Location = new System.Drawing.Point(737, 33);
            this.btnViewConfigFile.Name = "btnViewConfigFile";
            this.btnViewConfigFile.Size = new System.Drawing.Size(140, 30);
            this.btnViewConfigFile.TabIndex = 4;
            this.btnViewConfigFile.Text = "View configs";
            this.btnViewConfigFile.UseVisualStyleBackColor = false;
            this.btnViewConfigFile.Click += new System.EventHandler(this.btnViewConfigFile_Click);
            // 
            // btnReloadConfigs
            // 
            this.btnReloadConfigs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadConfigs.BackColor = System.Drawing.Color.Silver;
            this.btnReloadConfigs.FlatAppearance.BorderSize = 0;
            this.btnReloadConfigs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadConfigs.Location = new System.Drawing.Point(883, 33);
            this.btnReloadConfigs.Name = "btnReloadConfigs";
            this.btnReloadConfigs.Size = new System.Drawing.Size(140, 30);
            this.btnReloadConfigs.TabIndex = 5;
            this.btnReloadConfigs.Text = "Reload configs";
            this.btnReloadConfigs.UseVisualStyleBackColor = false;
            this.btnReloadConfigs.Click += new System.EventHandler(this.btnReloadConfigs_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panelSelectFile);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHBCR Data Form Creator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.panelSelectFile.ResumeLayout(false);
            this.panelSelectFile.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ImagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgCurrentForm)).EndInit();
            this.ToolPanel.ResumeLayout(false);
            this.ToolPanel.PerformLayout();
            this.panelFormToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label labelFooter;
        private System.Windows.Forms.Panel panelSelectFile;
        private System.Windows.Forms.Button btnCreateDataForms;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSelectedFile;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel ImagePanel;
        private System.Windows.Forms.PictureBox imgCurrentForm;
        private System.Windows.Forms.Panel ToolPanel;
        private System.Windows.Forms.Button btnPrevForm;
        private System.Windows.Forms.Button btnPrintForm;
        private System.Windows.Forms.Button btnNextForm;
        private System.Windows.Forms.Button btnSaveForm;
        private System.Windows.Forms.Button btnExpandForm;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Panel panelFormToolbar;
        private System.Windows.Forms.Label labCounter;
        private System.Windows.Forms.Button btnReloadConfigs;
        private System.Windows.Forms.Button btnViewConfigFile;
    }
}

