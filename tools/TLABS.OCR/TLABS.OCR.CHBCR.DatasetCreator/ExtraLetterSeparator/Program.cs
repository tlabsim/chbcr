using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExtraLetterSeparator
{
    class Program
    {
        static string SourceFolder { get; set; }
        static string TargetFolder { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter source folder: ");
            SourceFolder = Console.ReadLine();

            Console.WriteLine("Enter target folder: ");
            TargetFolder = Console.ReadLine();

            if (Directory.Exists(SourceFolder) && Directory.Exists(TargetFolder))
            {
                DirectoryInfo DI = new DirectoryInfo(SourceFolder);

                SeparateExtraFolderLetters(DI);
            }
            else
            {
                Console.WriteLine("Source or target folder is missing.");
            }

            Console.ReadLine();
        }

        static string GetRelativePath(string path, string root)
        {
            if(path.StartsWith(root))
            {
                return path.Replace(root, "").TrimEnd('\\') + '\\';
            }

            return string.Empty;
        }

        static void SeparateExtraFolderLetters(DirectoryInfo DI)
        {   
            string rel_path = GetRelativePath(DI.FullName, SourceFolder);
            string target_path = TargetFolder.TrimEnd('\\') + "\\" + rel_path;            

            var subfolders = DI.EnumerateDirectories().ToList();

            foreach (var sf in subfolders)
            {
                if (sf.Name == "Extra")
                {
                    var files = sf.EnumerateFiles().ToList();

                    if (files.Count > 0)
                    {
                        if (!Directory.Exists(target_path))
                        {
                            Directory.CreateDirectory(target_path);
                        }
                    }

                    foreach (var file in files)
                    {
                        file.MoveTo(target_path + file.Name);
                    }

                    sf.Delete(true);
                }
                else
                {
                    SeparateExtraFolderLetters(sf);
                }
            }
        }

        static void DeleteAllExtraFolders(DirectoryInfo DI)
        {            
            var subfolders = DI.EnumerateDirectories().ToList();

            foreach (var sf in subfolders)
            {
                if (sf.Name == "Extra")
                {
                    var files = sf.EnumerateFiles().ToList();

                    foreach (var file in files)
                    {
                        file.Delete();
                    }

                    sf.Delete(true);
                }
                else
                {
                    SeparateExtraFolderLetters(sf);
                }
            }
        }
    }
}
