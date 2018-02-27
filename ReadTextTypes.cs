using System;
using System.IO;

namespace FileIOApplication
{
    class ReadTextTypes
    {
        static void ReadData()
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(ReadTextTypes));
            Console.WriteLine("Reading");
            string filePath = @"F:\abc.txt";
            //string testData = File.ReadAllText(filePath);
            //string[] testDataLineByLine = File.ReadAllLines(filePath);
            byte[] testDataRawBytes = File.ReadAllBytes(filePath);
            foreach (byte s in testDataRawBytes)
            {
                Console.WriteLine(s);
            }
        }
        public static void Main(string[] args)
        {
            ReadData();
            Console.Read();
        }
    }
}
