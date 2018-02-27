using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOApplication
{
    class StringOperations
    {
        static void WriteAndRead()
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(StringOperations));
            string text = "String class \nparent is object \nobject is the base class";
            //Writing string into StringBuilder
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            //Store Data on StringBuilder
            writer.WriteLine(text);
            writer.Flush();
            writer.Close();
            //Read Entry
            StringReader reader = new StringReader(sb.ToString());
            //Check to End of File
            while (reader.Peek() > -1)
            {
                Console.WriteLine(reader.ReadLine());
            }
            Console.Read();
        }
        static void Main(string[] args)
        {
            WriteAndRead();
        }
    }
}
