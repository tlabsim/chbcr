using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveRename
{
    class Program
    {
        static string MasterForlderPath = string.Empty;
        static List<string> ValidExtrensions = new List<string>(){".jpg", ".jpeg"};
        static int CursorPositionY;
        static int RenamedFileCount = 0;

        static void Main(string[] args)
        {
            RecursiveRenameEntry();
        }

        static void RecursiveRenameEntry()
        {
            Console.WriteLine("This program renames all JPG files by using their parent folder name as the prefix.");
            Console.Write("Enter the folder path: ");
            string path = Console.ReadLine();

            CursorPositionY = Console.CursorTop + 1;
            //Console.WriteLine(CursorPositionY.ToString());

            if(Directory.Exists(path))
            {
                MasterForlderPath = path;

                RecursiveRename(path);
            }    
        }

        static void RecursiveRename(string path)
        {
            if (!Directory.Exists(path)) return;

            DirectoryInfo DI = new DirectoryInfo(path);
            string folder_name = DI.Name;

            List<string> folders = Directory.EnumerateDirectories(path).ToList();
            foreach(var folder in folders)
            {
                RecursiveRename(folder);
            }

            List<string> files = Directory.EnumerateFiles(path).ToList();
            foreach(var file in files)
            {
                RenameFile(file, DI);
            }
        }

        static void RenameFile(string file, DirectoryInfo parent_directory)
        {
            if (!File.Exists(file)) return;

            FileInfo FI = new FileInfo(file);            
            string extension = FI.Extension.ToLower();

            if (!ValidExtrensions.Contains(extension)) return;
            string old_name = FI.Name;
            string new_name_prefix = parent_directory.Name + "_";

            if (!old_name.StartsWith(new_name_prefix))
            {
                string new_name = new_name_prefix + old_name;
                File.Move(file, parent_directory.FullName.TrimEnd('\\') + '\\' + new_name);
            }

            RenamedFileCount++;
            Console.SetCursorPosition(0, CursorPositionY);
            Console.WriteLine("File renamed: {0}", RenamedFileCount);
        }
    }
}
