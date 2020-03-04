using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace FolderDifferenceFinder
{
    public partial class Form1 : Form
    {
        string ProgressTextPrefix = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        void SelectSourceFolder()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;
            var dr = FBD.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.Cancel)
            {
                tbSourceFolder.Text = FBD.SelectedPath;
            }
        }

        void SelectTargetFolder()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;
            var dr = FBD.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.Cancel)
            {
                tbTargetFolder.Text = FBD.SelectedPath;
            }
        }
        
        void StartComparing()
        {
            string source_folder = tbSourceFolder.Text.Trim();
            string target_folder = tbTargetFolder.Text.Trim();


            btnStartComparing.Enabled = false;
            tbSourceFolder.Enabled = false;
            btnSetSourceFolder.Enabled = false;
            tbTargetFolder.Enabled = false;
            btnSetTargetFolder.Enabled = false;
            chkFindMissing.Enabled = false;
            chkIsRecursive.Enabled = false;

            CompareFolders(source_folder, target_folder);

            tbSourceFolder.Enabled = true;
            btnSetSourceFolder.Enabled = true;
            tbTargetFolder.Enabled = true;
            btnSetTargetFolder.Enabled = true;
            chkFindMissing.Enabled = true;
            chkIsRecursive.Enabled = true;
            btnStartComparing.Enabled = true;
        }

        void CompareFolders(string source_folder, string target_folder)
        {
            if (string.IsNullOrEmpty(source_folder) || string.IsNullOrEmpty(target_folder))
            {
                MessageBox.Show("Select both source and target folders.");
                return;
            }

            if (!Directory.Exists(source_folder))
            {
                MessageBox.Show("Source folder doesn't exist.");
                return;
            }

            if (!Directory.Exists(target_folder))
            {
                MessageBox.Show("Target folder doesn't exist.");
                return;
            }

            string SourceFolderPath = source_folder;
            string TargetFolderPath = target_folder;
            string ExtraFolderPath = source_folder.TrimEnd('\\') + '\\' + "Extra";
            string LessFolderPath = source_folder.TrimEnd('\\') + '\\' + "Less";

            ProgressTextPrefix = "Comparing " + SourceFolderPath + " with " + TargetFolderPath;
            txtProgesss.Text = ProgressTextPrefix;

            if (chkIsRecursive.Checked)
            {
                List<string> source_folder_subfolders = Directory.EnumerateDirectories(SourceFolderPath).ToList();
                List<string> target_folder_subfolders = Directory.EnumerateDirectories(TargetFolderPath).ToList();

                Dictionary<string, DirectoryInfo> target_folder_subfolder_dict = new Dictionary<string, DirectoryInfo>();
                foreach (var tfsf in target_folder_subfolders)
                {
                    DirectoryInfo tsfdi = new DirectoryInfo(tfsf);

                    if (tsfdi.Exists)
                    {
                        target_folder_subfolder_dict.Add(tsfdi.Name, tsfdi);
                    }
                }

                foreach (var sfsf in source_folder_subfolders)
                {
                    DirectoryInfo ssfdi = new DirectoryInfo(sfsf);

                    if (ssfdi.Exists)
                    {
                        if (target_folder_subfolder_dict.ContainsKey(ssfdi.Name))
                        {
                            CompareFolders(ssfdi.FullName, target_folder_subfolder_dict[ssfdi.Name].FullName);
                            target_folder_subfolder_dict.Remove(ssfdi.Name);
                        }
                    }
                }
            }

            List<string> source_folder_files = Directory.EnumerateFiles(SourceFolderPath).ToList();
            List<string> target_folder_files = Directory.EnumerateFiles(TargetFolderPath).ToList();

            if (source_folder_files.Count > 0 && !Directory.Exists(ExtraFolderPath))
            {
                Directory.CreateDirectory(ExtraFolderPath);
            }

            if (chkFindMissing.Checked && target_folder_files.Count > 0 && !Directory.Exists(LessFolderPath))
            {
                Directory.CreateDirectory(LessFolderPath);
            }

            Dictionary<string, FileInfo> target_folder_file_dict = new Dictionary<string, FileInfo>();
            foreach (var tf in target_folder_files)
            {
                FileInfo tfi = new FileInfo(tf);
                if (tfi.Exists)
                {
                    target_folder_file_dict.Add(tfi.Name, tfi);
                }
            }


            double i = 0, t = source_folder_files.Count;
            foreach (var sf in source_folder_files)
            {
                FileInfo sfi = new FileInfo(sf);

                if (sfi.Exists)
                {
                    if (target_folder_file_dict.ContainsKey(sfi.Name))
                    {
                        target_folder_file_dict.Remove(sfi.Name);
                    }
                    else
                    {
                        try
                        {
                            File.Move(sf, ExtraFolderPath + "\\" + sfi.Name);
                        }
                        catch { }
                    }
                }

                i++;
                txtProgesss.Text = string.Format("({0}%) ", (int)(i * 100.0 / t)) + ProgressTextPrefix;
            }

            if (chkFindMissing.Checked)
            {
                if (target_folder_file_dict.Values.Count > 0)
                {
                    var extra_target_folder_files = target_folder_file_dict.Values;

                    foreach (var f in extra_target_folder_files)
                    {
                        try
                        {
                            File.Copy(f.FullName, LessFolderPath + "\\" + f.Name);
                        }
                        catch { }
                    }
                }
            }
        }

        private void btnSetSourceFolder_Click(object sender, EventArgs e)
        {
            SelectSourceFolder();
        }

        private void btnSetTargetFolder_Click(object sender, EventArgs e)
        {
            SelectTargetFolder();
        }

        private void btnStartComparing_Click(object sender, EventArgs e)
        {
            StartComparing();
        }
    }
}
