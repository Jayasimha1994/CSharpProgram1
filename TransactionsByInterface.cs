using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOApplication
{
    class TransactionsByInterface
    {
        /// <summary>
        /// it provides the methods for any implemented classes
        /// so that all methods can be implemented according to their need.
        /// </summary>
        public interface ITransactions
        {
            /// <summary>
            /// methods to get the transaction information.
            /// </summary>
            void showTransaction();
            double getAmount();
        }
        public class Transaction : ITransactions
        {
                private static readonly log4net.ILog log
                = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            /// <summary>
            /// fields required for every transaction.
            /// </summary>
            private string tCode;
            private string date;
            private double amount;
            public Transaction(string c, string d, double a)
            {
                tCode = c;
                date = d;
                amount = a;
            }
            /// <summary>
            /// This method is implemented to return the amount.
            /// </summary>
            /// <returns></returns>
            public double getAmount()
            {
                return amount;
            }
            /// <summary>
            /// This method is implemented to know the transaction information.
            /// </summary>
            public void showTransaction()
            {
                log.InfoFormat("Transaction: {0}", tCode);
                log.InfoFormat("Date: {0}", date);
                log.InfoFormat("Amount: {0}", getAmount());
            }
        }
        /// <summary>
        /// This class is used for instantiating and utilizing the implemented
        /// methods of the Transaction class
        /// </summary>
        class TransactionByInterface
        {
            /// <summary>
            /// Entry point for the project.
            /// </summary>
            /// <param name="args"></param>
            static void Main(string[] args)
            {
                Transaction t1 = new Transaction("001", "8/10/2012", 78900.00);
                Transaction t2 = new Transaction("002", "9/10/2012", 451900.00);
                t1.showTransaction();
                t2.showTransaction();
                Console.ReadKey();
            }
        }
    }
}
