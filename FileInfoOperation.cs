using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOApplication
{
    class FileInfoOperation
    {
        static void Main(string[] args)
        {
            FileMethod();
        }
        static void FileMethod()
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(FileInfoOperation));
            string path = @"F:\jay.txt";
            FileInfo file = new FileInfo(path);
            //Create File
            using (StreamWriter sw = file.CreateText())
            {
                sw.WriteLine("Hello FileInfo");
            }
            //Display File Info            
            Console.WriteLine("File Create on : " + file.CreationTime);
            Console.WriteLine("Directory Name : " + file.DirectoryName);
            Console.WriteLine("Full Name of File : " + file.FullName);
            Console.WriteLine("File is Last Accessed on : " + file.LastAccessTime);
            //Deleting File
            Console.WriteLine("Press small y for delete this file");
            try
            {
                char ch = Convert.ToChar(Console.ReadLine());
                if (ch == 'y')
                {
                    if (file.Exists)
                    {
                        file.Delete();
                        Console.WriteLine(path + " Deleted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Press Enter to Exit");
            }
            Console.ReadKey();
        }
    }
}
