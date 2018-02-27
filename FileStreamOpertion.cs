using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileIOApplication
{
    //writing and reading the content to the file using the filestream class
    class FileStreamOpertion
    {
        static void WriteFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Write);
            if(fs.CanWrite)
            {
                byte[] buffer = Encoding.ASCII.GetBytes("File streams");
                fs.Write(buffer, 0, buffer.Length);
            }
            fs.Flush();
            fs.Close();
        }
        static void ReadFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            if(fs.CanRead)
            {
                byte[] buffer = new byte[fs.Length];
                int bytesread = fs.Read(buffer, 0, buffer.Length);
                Console.WriteLine(Encoding.ASCII.GetString(buffer,0,bytesread));
            }
            fs.Close();
        }
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(FileStreamOpertion));
            String path = "F:\\abc.txt";
            WriteFile(path);
            ReadFile(path);
        }
    }
}
