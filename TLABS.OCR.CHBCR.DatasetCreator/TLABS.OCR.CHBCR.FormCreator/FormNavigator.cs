using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TLABS.Extensions;
using System.Drawing.Printing;
using System.Diagnostics;

namespace TLABS.OCR.CHBCR.FormCreator
{
    public class FormNavigator
    {
        public List<Bitmap> FormImages = new List<Bitmap>();

        public PictureBox FormPictureBox;
        public Button PreviousButton, NextButton, ExpandButton, PrintButton, SaveButton, SaveAllButton;
        public Label CounterLabel;

        int CurrentIndex = -1;

        public FormNavigator(PictureBox pb_form, Button btn_prev, Button btn_next, Button btn_expand, Button btn_print, Button btn_save, Button btn_save_all, Label lbl_counter)
        {
            this.FormPictureBox = pb_form;
            this.FormPictureBox.Visible = false;

            this.PreviousButton = btn_prev;
            this.NextButton = btn_next;
            this.ExpandButton = btn_expand;
            this.PrintButton = btn_print;
            this.SaveButton = btn_save;
            this.SaveAllButton = btn_save_all;

            this.CounterLabel = lbl_counter;
            this.CounterLabel.Visible = false;

            this.PreviousButton.Click += new EventHandler(PreviousButton_Click);
            this.NextButton.Click += new EventHandler(NextButton_Click);
            this.ExpandButton.Click += new EventHandler(ExpandButton_Click);
            this.PrintButton.Click += new EventHandler(PrintButton_Click);
            this.SaveButton.Click += new EventHandler(SaveButton_Click);
            this.SaveAllButton.Click += new EventHandler(SaveAllButton_Click);

            DisableButtons();
        }
        
        public void Init()
        {
            DisableButtons();

            if (this.FormImages.Count > 0)
            {
                this.CurrentIndex = 0;

                this.FormPictureBox.Visible = true;
                this.CounterLabel.Visible = true;

                ShowCurrentForm();

                if (this.FormImages.Count > 1)
                {
                    NextButton.Enabled = true;
                }
            }
            else
            {
                this.CurrentIndex = -1;
                this.FormPictureBox.Visible = false;
                this.CounterLabel.Visible = false;
            }
        }

        void ShowCurrentForm()
        {
            this.FormPictureBox.Image = this.FormImages[CurrentIndex];

            this.ExpandButton.Enabled = true;
            this.PrintButton.Enabled = true;
            this.SaveButton.Enabled = true;

            this.CounterLabel.Text = string.Format("{0}/{1}", this.CurrentIndex + 1, this.FormImages.Count);
        }

        void ShowPreviousForm()
        {
            if (CurrentIndex > 0)
            {
                CurrentIndex--;

                ShowCurrentForm();
            }

            if (CurrentIndex == 0)
            {
                this.PreviousButton.Enabled = false;
            }

            if (CurrentIndex < this.FormImages.Count - 1)
            {
                this.NextButton.Enabled = true;
            }
        }

        void ShowNextForm()
        {
            if (CurrentIndex < this.FormImages.Count - 1)
            {
                CurrentIndex++;

                ShowCurrentForm();
            }

            if (CurrentIndex == this.FormImages.Count - 1)
            {
                this.NextButton.Enabled = false;
            }

            if (CurrentIndex > 0)
            {
                this.PreviousButton.Enabled = true;
            }
        }

        void ExpandCurrentForm()
        {
            this.FormImages[CurrentIndex].Show();
        }

        void PrintCurrentForm()
        {
            MessageBox.Show("This option may not work properly");

            try
            {
                string file_to_print = @"current.jpg";
                //if (File.Exists(file_to_print))
                //{
                //    File.Delete(file_to_print);
                //}

                this.FormImages[CurrentIndex].Save(file_to_print, System.Drawing.Imaging.ImageFormat.Jpeg);

                System.Threading.Thread.Sleep(100);
                var p = new Process();
                p.StartInfo.FileName = file_to_print;
                p.StartInfo.Verb = "Print";
                p.Start();

                File.Delete(file_to_print);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");            
            }

            //return;

            //PrintDialog PD = new PrintDialog();
            //PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            //doc.DocumentName = string.Format("Form {0}", CurrentIndex + 1);
            //doc.PrintPage += new PrintPageEventHandler(PrintPage);

            //PD.Document = doc;
            //PD.ShowDialog();
        }

        void SaveCurrentForm()
        {
            if (CurrentIndex >= 0 && this.FormImages.Count > CurrentIndex && this.FormImages[CurrentIndex] != null)
            {
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Title = "Save form";
                SFD.DefaultExt = "jpg";
                SFD.Filter = "JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png";

                var dr = SFD.ShowDialog();
                if (dr != DialogResult.Cancel)
                {
                    string save_file = SFD.FileName;

                    Bitmap bmp = this.FormImages[CurrentIndex];
                    try
                    {
                        bmp.Save(save_file);

                        MessageBox.Show("Form image saved successfully", "File saved", MessageBoxButtons.OK,  MessageBoxIcon.Information);
                    }
                    catch 
                    {
                        MessageBox.Show("An error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        void SaveAllForms()
        {
            if (this.FormImages.Count > 0)
            {
                FolderBrowserDialog FBD = new FolderBrowserDialog();

                FBD.Description = "Select the dirctory to save all forms";
                FBD.RootFolder = Environment.SpecialFolder.Desktop;

                var dr = FBD.ShowDialog();
                if (dr != DialogResult.Cancel)
                {
                    string save_folder = FBD.SelectedPath;

                    for (int i = 0; i < this.FormImages.Count; i++)
                    {
                        string save_file = save_folder.TrimEnd('\\') + "\\" + string.Format("Form{0}.jpg", i + 1);

                        Bitmap bmp = this.FormImages[i];
                        try
                        {
                            bmp.Save(save_file);
                        }
                        catch 
                        {                            
                        }
                    }

                    MessageBox.Show("All form images were saved successfully", "Files saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
          
        public void Reset()
        {
            FormImages.Clear();
            DisableButtons();
        }

        void DisableButtons()
        {
            this.PreviousButton.Enabled = false;
            this.NextButton.Enabled = false;
            this.ExpandButton.Enabled = false;
            this.PrintButton.Enabled = false;
            this.SaveButton.Enabled = false;
        }

        void PreviousButton_Click(object sender, EventArgs e)
        {
            ShowPreviousForm();
        }

        void NextButton_Click(object sender, EventArgs e)
        {
            ShowNextForm();
        }

        void ExpandButton_Click(object sender, EventArgs e)
        {
            if (this.ExpandButton.Text == "View larger")
            {
                this.FormPictureBox.Dock = DockStyle.None;
                this.FormPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

                this.ExpandButton.Text = "View smaller";
            }
            else
            {
                this.FormPictureBox.Dock = DockStyle.Fill;
                this.FormPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                this.ExpandButton.Text = "View larger";
            }            
        }

        void PrintButton_Click(object sender, EventArgs e)
        {
            PrintCurrentForm();
        }

        void SaveButton_Click(object sender, EventArgs e)
        {
            SaveCurrentForm();
        }

        void SaveAllButton_Click(object sender, EventArgs e)
        {
            SaveAllForms();
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            if (CurrentIndex >= 0 && this.FormImages.Count > CurrentIndex && this.FormImages[CurrentIndex] != null)
            {
                Point loc = new Point(0, 0);
                e.Graphics.PageUnit = GraphicsUnit.Document;
                e.Graphics.DrawImage(this.FormImages[CurrentIndex], loc);
            }
        }
    }
}
