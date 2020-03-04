using System;
using System.IO;
using System.Management;
using System.Security.AccessControl;

namespace TLABS.Extensions
{
    public static class IOExtensions
    {
        /// <summary>
        /// Opens the directory path in explorer
        /// </summary>
        /// <param name="Location"></param>
        public static void OpenInExplorer(this string Location)
        {
            if (Location != "")
            {                
                if (Directory.Exists(Location))
                {
                    System.Diagnostics.Process.Start(Location);
                }
            }
        }

        public static void OpenInBrowser(this string Location)
        {
            if (Location != "")
            {
                try
                {
                    System.Diagnostics.Process.Start(Location);
                }
                catch { }
            }
        }

        /// <summary>
        /// Opens the directory in explorer
        /// </summary>
        /// <param name="DI"></param>
        public static void OpenInExplorer(this DirectoryInfo DI)
        {
            if (DI.Exists)
            {
                System.Diagnostics.Process.Start(DI.FullName);
            }
        }

        /// <summary>
        /// Renames the directory
        /// </summary>
        /// <param name="DI"></param>
        /// <param name="NewFolderName"></param>
        public static void Rename(this DirectoryInfo DI, string NewFolderName)
        {
            
        }

        /// <summary>
        /// Renames the file
        /// </summary>
        /// <param name="FI"></param>
        /// <param name="NewFileName"></param>
        public static void Rename(this FileInfo FI, string NewFileName)
        {
            File.Move(FI.FullName, NewFileName);
        }

        /// <summary>
        /// Copy the content of the directory to the specified directory
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Destination"></param>
        public static void CopyContents(this DirectoryInfo Source, DirectoryInfo Destination)
        {
            foreach (string dirPath in Directory.GetDirectories(Source.FullName, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(Source.FullName, Destination.FullName));

            foreach (string newPath in Directory.GetFiles(Source.FullName, "*.*", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(Source.FullName, Destination.FullName), true);
        }       

        /// <summary>
        /// Copy the content of the directory to the specified location
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Destination"></param>
        public static void CopyContents(this DirectoryInfo Source, string Destination)
        {
            foreach (string dirPath in Directory.GetDirectories(Source.FullName, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(Source.FullName, Destination));

            foreach (string newPath in Directory.GetFiles(Source.FullName, "*.*", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(Source.FullName, Destination), true);
        }

        /// <summary>
        /// Deletes the contents of the direcotry
        /// </summary>
        /// <param name="directory"></param>
        public static void DeleteContents(this System.IO.DirectoryInfo directory)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
        }

        public static bool SetFullPermissions(this DirectoryInfo DI)
        {
            bool success = true;
            
            if (!DI.Exists)
            {
                DI.Create();
            }
            
            //set permissions 
            SelectQuery sQuery = new SelectQuery("Win32_Group", "Domain='" + System.Environment.UserDomainName.ToString() + "'");
            try
            {               
                DirectorySecurity myDirectorySecurity = DI.GetAccessControl();
                using (ManagementObjectSearcher mSearcher = new ManagementObjectSearcher(sQuery))
                {
                    foreach (ManagementObject mObject in mSearcher.Get())
                    {
                        string User = System.Environment.UserDomainName + "\\" + mObject["Name"];
                        //if (User.StartsWith(Environment.MachineName + "\\SQL"))                     
                        //{
                        //    myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(User, FileSystemRights.FullControl, AccessControlType.Allow));
                        //}
                        myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(User, FileSystemRights.FullControl, AccessControlType.Allow));
                    }
            
                    DI.SetAccessControl(myDirectorySecurity);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
            }
            return success;
        }
    }
}
