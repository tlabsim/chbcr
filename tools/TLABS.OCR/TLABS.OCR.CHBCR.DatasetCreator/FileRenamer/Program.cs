using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TLABS.Extensions;

namespace FileRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = string.Empty;
            string rename_what = "files";
            string sort_by = "default";
            int start_from = 1;
            int name_length = 4;

            List<string> valid_sort_bys = new List<string>()
            {
                "--default",
                "--datetime",
                "--name"
            };

            if(args.Length > 1)
            {
                path = args[1];
            }

            if (string.IsNullOrEmpty(path))
            {
                Console.Write("Enter path of the directory: ");
                path = Console.ReadLine();
            }

            if(args.Length > 2)
            {
                var rw = args[2];
                if(rw != "--files" && rw != "--folders")
                {
                    Console.WriteLine("Invalid use of arguments. Second argument should be --files or --folders");
                }
                else
                {
                    rename_what = rw.Substring(2);
                }
            }
            else
            {
                Console.Write("What do you want to rename? (files/folders): ");
                rename_what = Console.ReadLine();
            }

            if(args.Length> 3)
            {
                string sb = args[3];
                if( !valid_sort_bys.Contains(sb))
                {
                    Console.WriteLine("Invalid use of arguments");
                }
                else
                {
                    sort_by = sb.Substring(2);
                }
            }
            else
            {
                Console.Write("How do you want to sort the items? (name/datetime/literal): ");
                sort_by = Console.ReadLine();
            }

            if (args.Length > 4)
            {
                start_from = args[4].ToInt(1);
            }
            else
            {
                Console.Write("Enter the number the names will start from: ");
                start_from = Console.ReadLine().ToInt(1);
            }         

            if(args.Length > 5)
            {
                name_length = args[5].ToInt(4);
            }
            else
            {
                Console.Write("How long will be the names?: ");
                name_length = Console.ReadLine().ToInt(4); 
            }            

            RenameSequentially(path, rename_what, sort_by, start_from, name_length);
            Console.ReadLine();
        }

        static void RenameSequentially(string path, string rename_what, string sort_by, int start_from = 1, int name_length = 4)
        {
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("No path is specified");
            }

            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                Console.WriteLine("The specified directory does not exist");
            }

            rename_what = rename_what.ToLower();
            if (string.IsNullOrEmpty(rename_what))
            {
                rename_what = "files";
            }

            Console.WriteLine("Renaming {0} in {1}", rename_what, path);

            sort_by = sort_by.ToLower();
            if (string.IsNullOrEmpty(sort_by))
            {
                sort_by = "default";
            }

            try
            {
                if (rename_what == "files")
                {
                    var files = di.GetFiles().ToList();

                    switch (sort_by)
                    {
                        case "name":
                            files.Sort((f1, f2) => f1.Name.CompareTo(f2.Name));
                            break;
                        case "datetime":
                            files.Sort((f1, f2) => f1.LastWriteTime.CompareTo(f2.LastWriteTime));
                            break;
                        case "literal":
                            files.Sort((f1, f2) => f1.Name.ToInt(0).CompareTo(f2.Name.ToInt(0)));
                            break;
                    }

                    int i = start_from;
                    foreach (var f in files)
                    {
                        f.Rename(i.ToString(name_length));
                    }
                }
                else if (rename_what == "folders")
                {
                    var folders = di.GetDirectories().ToList();

                    switch (sort_by)
                    {
                        case "name":
                            folders.Sort((f1, f2) => f1.Name.CompareTo(f2.Name));
                            break;
                        case "datetime":
                            folders.Sort((f1, f2) => f1.LastWriteTime.CompareTo(f2.LastWriteTime));
                            break;
                        case "literal":
                            folders.Sort((f1, f2) => f1.Name.ToInt(0).CompareTo(f2.Name.ToInt(0)));
                            break;
                    }

                    int i = start_from;
                    foreach (var f in folders)
                    {
                        string new_name = i.ToString(name_length);
                        f.Rename(new_name);
                        i++;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An exception occurred.\r\n" + ex.Message);
            }
        }
    }
}
