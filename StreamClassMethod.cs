﻿using System;
using System.IO;

namespace FileIOApplication
{
    class StreamClassMethod
    {
        static void Main(string[] args)
        {
            ReadAndWrite();
        }
        static void ReadAndWrite()
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(StreamClassMethod));
            try
            {
            // Create a file called abc.txt in the current directory:
            using (Stream s = new FileStream("abc.txt", FileMode.Create))
            {
                Console.WriteLine(s.CanRead); // True
                Console.WriteLine(s.CanWrite); // True
                Console.WriteLine(s.CanSeek); // True
                s.WriteByte(101);
                s.WriteByte(102);
                byte[] block = { 1, 2, 3, 4, 5 };
                s.Write(block, 0, block.Length); // Write block of 5 bytes
                Console.WriteLine(s.Length); // 7
                Console.WriteLine(s.Position); // 7
                s.Position = 0; // Move back to the start
                Console.WriteLine(s.ReadByte()); // 101
                Console.WriteLine(s.ReadByte()); // 102
                                                 // Read from the stream back into the block array:
                Console.WriteLine(s.Read(block, 0, block.Length)); // 5
                                                                   // Assuming the last Read returned 5, we'll be at
                                                                   // the end of the file, so Read will now return 0:
                Console.WriteLine(s.Read(block, 0, block.Length)); // 0
            }
            Console.Read();
        }
    }
}
