using System;
using System.IO;

namespace FileIOApplication
{
    //reading and writing operations of a file using stream reader and writer.
    class StreamOperation
    {
        static void WriteRead()
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(StreamOperation));
            string path = @"F:\abc.txt";
            if (!File.Exists(path))
            {
                StreamWriter sw = File.CreateText(path);
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
                sw.Flush();
                sw.Close();
            }
            StreamReader sr = File.OpenText(path);
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }
        public static void Main(string[] args)
        {
            WriteRead();
            Console.Read();
        }
    }
}
