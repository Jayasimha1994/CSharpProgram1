using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileIOApplication
{
    /// <summary>
    /// Serialization and deserialization using the binaryformatter
    /// </summary>
    class BinarySerialization
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string fileName = "F:\\jay.txt";
        static void Serialize()
        {
            Tutorial1 t = new Tutorial1();
            t.title = "Commander";
            t.pageCount = 5;
            t.author = "Murugan";

            FileStream stream = File.Create(fileName);
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(stream, t);
            stream.Close();

            stream = File.OpenRead(fileName);
            Tutorial1 t1 = (Tutorial1)format.Deserialize(stream);
            log.Info(t1.title + "--" + t1.pageCount + "--" + t1.author);
        }
        static void Main(string[] args)
        {
            Serialize();
            Console.Read();
        }
    }
    [Serializable]
    public class Tutorial1
    {
        public string title;
        public int pageCount;
        public string author;
    }
}
