using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileIOApplication
{
    class SerializeClass
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Deserialing the tutorial class and reading the params.
        /// </summary>
        static void ReadXml()
        {
            XmlSerializer reader = new XmlSerializer(typeof(Tutorial));
            using (StreamReader s = new StreamReader("F:\\abc.xml"))
            {
                Tutorial t = (Tutorial)reader.Deserialize(s);
                log.Info(t.title + "---" + t.pagecount + "--" + t.author);
            }
        }
        /// <summary>
        /// Serializing the tutorial class to xmlfile
        /// </summary>
        static void XmlWrite()
        {
            Tutorial t = new Tutorial();
            t.title = "Something";
            t.pagecount = 5;
            t.author = "Jayasimha";

            XmlSerializer writer = new XmlSerializer(typeof(Tutorial));
            using (FileStream file = File.Create("F:\\abc.xml"))
            {
                writer.Serialize(file, t);
            }
        }
        /// <summary>
        /// this method is to call methods required for serialization and deserialization.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            XmlWrite();
            ReadXml();
            Console.Read();
        }
    }
    public class Tutorial
    {
        public string title;
        public int pagecount;
        public string author;
    }
}
