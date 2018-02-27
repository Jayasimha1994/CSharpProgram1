using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace FileIOApplication
{
    class BinaryWriterOperations
    {
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(BinaryWriterOperations));
            WriteBinaryFile();
            ReadBinaryFile();
            Console.ReadKey();
        }
        static void WriteBinaryFile()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open("F:\\jay.txt", FileMode.Create)))
            {
                //Writting Error Log
                writer.Write("0x80234400");
                writer.Write("Windows Explorer Has Stopped Working");
                writer.Write(true);
            }
        }
        static void ReadBinaryFile()
        {
            using (BinaryReader reader = new BinaryReader(File.Open("F:\\jay.txt", FileMode.Open)))
            {
                Console.WriteLine("Error Code : " + reader.ReadString());
                Console.WriteLine("Message : " + reader.ReadString());
                Console.WriteLine("Restart Explorer : " + reader.ReadBoolean());
            }
        }
    }
}
