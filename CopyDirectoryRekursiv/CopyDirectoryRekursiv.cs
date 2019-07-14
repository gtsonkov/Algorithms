
namespace CopyDirectoryRekursiv
{
    using System;
    using System.IO;

    class Copy_Directory_Recursiv
    {
        static void Main(string[] args)
        {
            //Using Recursion
            string sorce = string.Empty;
            string destination = string.Empty;
            while (true)
            {
                Console.Write("Please enter a source directory: ");
                sorce = Console.ReadLine();
                if (!Directory.Exists(sorce))
                {
                    Console.WriteLine($"The directory phat '{sorce}' does not exist or is invalid. Please enter valid directory");
                }
                else
                {
                    Console.WriteLine();
                    break;
                }
            }
            while (true)
            {
                Console.Write("Please enter a destination directory: ");
                destination = Console.ReadLine();
                if (!Directory.Exists(destination))
                {
                    Console.WriteLine($"The directory phat '{destination}' does not exist or is invalid. Please enter valid directory");
                }
                else
                {
                    Console.WriteLine();
                    break;
                }
            }
            CopyFolder(sorce, destination);
        }

        private static void CopyFolder(string sorce, string destination)
        {
            string[] files = Directory.GetFiles(sorce);
            string[] folders = Directory.GetDirectories(sorce);
            Console.WriteLine("Getting files...");
            if (!(Directory.Exists(destination)))
            {
                Console.WriteLine("Creating Directory");
                Directory.CreateDirectory(destination);
            }
            foreach (var file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destination, name);
                Console.WriteLine($"Copying file {name}");
                if (File.Exists(dest))
                {
                    while (true)
                    {
                        Console.Write($"File {name} already exist. Do you want rewrite the file? y/n:");
                        var aktion = Console.ReadKey();
                        if (aktion.Key == ConsoleKey.Y)
                        {
                            File.Copy(file, dest, true);
                            Console.WriteLine();
                            break;
                        }
                        else if (aktion.Key == ConsoleKey.N)
                        {
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine();
                    }
                }
            }
            foreach (var folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destination, name);
                Console.WriteLine($"Copying Directory {name}");
                CopyFolder(folder, dest);
            }
        }
    }
}
