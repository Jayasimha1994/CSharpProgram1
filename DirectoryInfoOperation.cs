using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOApplication
{
    class DirectoryInfoOperation
    {
        static void Main(string[] args)
        {
            DirectortyMethod();
        }
        static void DirectortyMethod()
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(DirectoryInfoOperation));
            string path = @"F:\delete";
            DirectoryInfo dir = new DirectoryInfo(path);
            try
            {
                if (dir.Exists)
                {
                    Console.WriteLine("{0} Directory is already exists", path);
                    Console.WriteLine("Directory Name : " + dir.Name);
                    Console.WriteLine("Path : " + dir.FullName);
                    Console.WriteLine("Directory is created on : " + dir.CreationTime);
                    Console.WriteLine("Directory is Last Accessed on " + dir.LastAccessTime);
                }
                else
                {
                    dir.Create();
                    Console.WriteLine(path + "Directory is created successfully");
                }
                //Delete this directory
                Console.WriteLine("If you want to delete this directory press small y. Press any key to exit.");
                try
                {
                    char ch = Convert.ToChar(Console.ReadLine());
                    if (ch == 'y')
                    {
                        if (dir.Exists)
                        {
                            dir.Delete();
                            Console.WriteLine(path + "Directory Deleted");
                        }
                        else
                        {
                            Console.WriteLine(path + "Directory Not Exists");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Press Enter to Exit");
                }
                Console.ReadKey();
            }
            catch (DirectoryNotFoundException d)
            {
                Console.WriteLine("Exception raised : " + d.Message);
            }
        }
    }
}
