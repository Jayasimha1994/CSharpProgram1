using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOApplication
{
    class TextClassOperation
    {
        static void Write()
        {
            string file = @"F:\\jay.txt";
            using (TextWriter writer = File.CreateText(file))
            {
                writer.WriteLine("Hello TextWriter!");
                writer.WriteLine("File Handling Tutorial");
            }
            Console.WriteLine("Entry stored successfull!");
            Console.ReadKey();
        }
        static void Read()
        {
            string filepath = @"F:\jay.txt";
            //Read One Line
            using (TextReader tr = File.OpenText(filepath))
            {
                Console.WriteLine(tr.ReadLine());
            }
            //Read 4 Characters
            using (TextReader tr = File.OpenText(filepath))
            {
                char[] ch = new char[4];
                tr.ReadBlock(ch, 0, 4);
                Console.WriteLine(ch);
            }
            //Read full file
            using (TextReader tr = File.OpenText(filepath))
            {
                Console.WriteLine(tr.ReadToEnd());
            }
        }
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(TextClassOperation));
            //Write();
            Read();
            Console.ReadKey();
        }
    }
}
