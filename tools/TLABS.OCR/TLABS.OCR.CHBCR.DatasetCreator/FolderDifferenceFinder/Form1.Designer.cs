namespace FolderDifferenceFinder
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSourceFolder = new System.Windows.Forms.TextBox();
            this.tbTargetFolder = new System.Windows.Forms.TextBox();
            this.btnSetSourceFolder = new System.Windows.Forms.Button();
            this.btnSetTargetFolder = new System.Windows.Forms.Button();
            this.btnStartComparing = new System.Windows.Forms.Button();
            this.chkIsRecursive = new System.Windows.Forms.CheckBox();
            this.chkFindMissing = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProgesss = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Folder to compare with";
            // 
            // tbSourceFolder
            // 
            this.tbSourceFolder.Location = new System.Drawing.Point(50, 55);
            this.tbSourceFolder.Name = "tbSourceFolder";
            this.tbSourceFolder.Size = new System.Drawing.Size(558, 22);
            this.tbSourceFolder.TabIndex = 2;
            // 
            // tbTargetFolder
            // 
            this.tbTargetFolder.Location = new System.Drawing.Point(50, 113);
            this.tbTargetFolder.Name = "tbTargetFolder";
            this.tbTargetFolder.Size = new System.Drawing.Size(558, 22);
            this.tbTargetFolder.TabIndex = 3;
            // 
            // btnSetSourceFolder
            // 
            this.btnSetSourceFolder.Location = new System.Drawing.Point(617, 55);
            this.btnSetSourceFolder.Name = "btnSetSourceFolder";
            this.btnSetSourceFolder.Size = new System.Drawing.Size(36, 23);
            this.btnSetSourceFolder.TabIndex = 4;
            this.btnSetSourceFolder.Text = "...";
            this.btnSetSourceFolder.UseVisualStyleBackColor = true;
            this.btnSetSourceFolder.Click += new System.EventHandler(this.btnSetSourceFolder_Click);
            // 
            // btnSetTargetFolder
            // 
            this.btnSetTargetFolder.Location = new System.Drawing.Point(614, 113);
            this.btnSetTargetFolder.Name = "btnSetTargetFolder";
            this.btnSetTargetFolder.Size = new System.Drawing.Size(36, 23);
            this.btnSetTargetFolder.TabIndex = 5;
            this.btnSetTargetFolder.Text = "...";
            this.btnSetTargetFolder.UseVisualStyleBackColor = true;
            this.btnSetTargetFolder.Click += new System.EventHandler(this.btnSetTargetFolder_Click);
            // 
            // btnStartComparing
            // 
            this.btnStartComparing.Location = new System.Drawing.Point(47, 178);
            this.btnStartComparing.Name = "btnStartComparing";
            this.btnStartComparing.Size = new System.Drawing.Size(183, 37);
            this.btnStartComparing.TabIndex = 6;
            this.btnStartComparing.Text = "Start";
            this.btnStartComparing.UseVisualStyleBackColor = true;
            this.btnStartComparing.Click += new System.EventHandler(this.btnStartComparing_Click);
            // 
            // chkIsRecursive
            // 
            this.chkIsRecursive.AutoSize = true;
            this.chkIsRecursive.Location = new System.Drawing.Point(50, 187);
            this.chkIsRecursive.Name = "chkIsRecursive";
            this.chkIsRecursive.Size = new System.Drawing.Size(193, 21);
            this.chkIsRecursive.TabIndex = 7;
            this.chkIsRecursive.Text = "Recursively try subfolders";
            this.chkIsRecursive.UseVisualStyleBackColor = true;
            // 
            // chkFindMissing
            // 
            this.chkFindMissing.AutoSize = true;
            this.chkFindMissing.Location = new System.Drawing.Point(50, 214);
            this.chkFindMissing.Name = "chkFindMissing";
            this.chkFindMissing.Size = new System.Drawing.Size(263, 21);
            this.chkFindMissing.TabIndex = 8;
            this.chkFindMissing.Text = "Find the missing files in source folder";
            this.chkFindMissing.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Options";
            // 
            // txtProgesss
            // 
            this.txtProgesss.AutoEllipsis = true;
            this.txtProgesss.AutoSize = true;
            this.txtProgesss.Location = new System.Drawing.Point(44, 30);
            this.txtProgesss.MaximumSize = new System.Drawing.Size(500, 50);
            this.txtProgesss.Name = "txtProgesss";
            this.txtProgesss.Size = new System.Drawing.Size(0, 17);
            this.txtProgesss.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.txtProgesss);
            this.panel1.Controls.Add(this.btnStartComparing);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 258);
            this.panel1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkFindMissing);
            this.Controls.Add(this.chkIsRecursive);
            this.Controls.Add(this.btnSetTargetFolder);
            this.Controls.Add(this.btnSetSourceFolder);
            this.Controls.Add(this.tbTargetFolder);
            this.Controls.Add(this.tbSourceFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folder comparer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSourceFolder;
        private System.Windows.Forms.TextBox tbTargetFolder;
        private System.Windows.Forms.Button btnSetSourceFolder;
        private System.Windows.Forms.Button btnSetTargetFolder;
        private System.Windows.Forms.Button btnStartComparing;
        private System.Windows.Forms.CheckBox chkIsRecursive;
        private System.Windows.Forms.CheckBox chkFindMissing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtProgesss;
        private System.Windows.Forms.Panel panel1;
    }
}

