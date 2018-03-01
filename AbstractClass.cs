using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOApplication
{
    //Creating an Abstract Class
    public abstract class absClass
    {
        //A Non abstract method
        public int AddTwoNumbers(int Num1, int Num2)
        {
            return Num1 + Num2;
        }

        //An abstract method, to be
        //overridden in derived class
        public abstract int MultiplyTwoNumbers(int Num1, int Num2);
    }
    class AbstractClass: absClass
    {
        static void Main(string[] args)
        {
            //You can create an
            //instance of the derived class
            AbstractClass calculate = new AbstractClass();
            int added = calculate.AddTwoNumbers(10, 20);
            int multiplied = calculate.MultiplyTwoNumbers(10, 20);
            Console.WriteLine("Added : {0}, Multiplied: {1}", added, multiplied);
            Console.Read();
        }
        /// <summary>
        /// using override keyword,
        /// implementing the abstract method
        /// MultiplyTwoNumbers
        /// </summary>
        /// <param name="Num1"></param>
        /// <param name="Num2"></param>
        /// <returns></returns>
        public override int MultiplyTwoNumbers(int Num1, int Num2)
        {
            return Num1 * Num2;
        }
    }
}
