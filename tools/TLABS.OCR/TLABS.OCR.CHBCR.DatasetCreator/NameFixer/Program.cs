using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NameFixer
{
    class Program
    {
        static string BaseFolder { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter source folder: ");
            BaseFolder = Console.ReadLine();


            if (Directory.Exists(BaseFolder))
            {
                DirectoryInfo DI = new DirectoryInfo(BaseFolder);

                FixImageFileNames(DI);

                Console.WriteLine("Finished!!!");
            }

            Console.ReadLine();
        }

        static void FixImageFileNames(DirectoryInfo DI)
        {
            if (DI.Name.Length ==  4)
            {
                string folder_name = DI.Name;

                var files = DI.EnumerateFiles().ToList();

                foreach (var file in files)
                {
                    if(!file.Name.StartsWith(folder_name + "_"))
                    {
                        string new_name = string.Empty;
                        if(file.Name[4] == '_')
                        {
                            new_name = folder_name + file.Name.Substring(4);
                        }
                        else
                        {
                            new_name = folder_name + "_" + file.Name;
                        }

                        file.MoveTo(file.DirectoryName.TrimEnd('\\') + "\\" + new_name);
                    }
                }
            }


            var subfolders = DI.EnumerateDirectories().ToList();

            foreach (var subfolder in subfolders)
            {
                FixImageFileNames(subfolder);
            }
        }
    }
}
