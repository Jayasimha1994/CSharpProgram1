using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOApplication
{
    /// <summary>
    /// it will perform the banking trasactions
    /// </summary>
    class BankingOperation
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// we can create objects and utilize the services for both savings and currnt classes
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            BankAccount savingAccount = new SavingBankAccount("Sarvesh", "S12345");
            BankAccount currentAccount = new CurrentBankAccount("Mark", "C12345");
            savingAccount.Deposit(40000);
            savingAccount.Withdraw(1000);
            // Generate Report
            savingAccount.GenerateAccountReport();
            Console.WriteLine();
            currentAccount.Deposit(190000);
            currentAccount.Withdraw(1000);
            currentAccount.GenerateAccountReport();
            Console.Read();
        }
    }
    /// <summary>
    /// this class defines all the properties and methods required for the inherited classes
    /// </summary>
    public abstract class BankAccount
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string AccountOwnerName { get; set; }
        public string AccountNumber { get; set; }
        public decimal AccountBalance { get; protected set; }
        protected decimal MinAccountBalance { get; set; }
        protected decimal MaxDepositAmount { get; set; }
        protected decimal InteresetRate { get; set; }
        protected string TransactionSummary { get; set; }
        protected BankAccount(string accountOwnerName, string accountNumber)
        {
            AccountOwnerName = accountOwnerName;
            AccountNumber = accountNumber;
            TransactionSummary = string.Empty;
        }
         /// <summary>
         ///  Deposit is an abstract method so that Saving/Current Account must override
         ///  it to give their specific implementation.
         /// </summary>
         /// <param name="amount"></param>
        public abstract void Deposit(decimal amount);
        /// <summary>
        /// withdraw is an abstract method so that Saving/Current Account must override 
        /// it to give their specific implementation.
        /// </summary>
        /// <param name="amount"></param>
        public abstract void Withdraw(decimal amount);
        public decimal CalculateInterest()
        {
            return (this.AccountBalance * this.InteresetRate) / 100;
        }
        public virtual void GenerateAccountReport()
        {
            log.InfoFormat("Account Owner:{0}, Account Number:{1}, AccountBalance:{2}",
                this.AccountOwnerName, this.AccountNumber, this.AccountBalance);

            log.InfoFormat("Interest Amount:{0}", CalculateInterest());
            log.InfoFormat("{0}", this.TransactionSummary);
        }
    }
    public class SavingBankAccount : BankAccount
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected int withdrawCount = 0;
        public SavingBankAccount(string accountOwnerName, string accountNumber)
            : base(accountOwnerName, accountNumber)
        {
            this.MinAccountBalance = 20000m;
            this.MaxDepositAmount = 50000m;
            InteresetRate = 3.5m;
        }
        public override void Deposit(decimal amount)
        {
            if (amount >= MaxDepositAmount)
            {
                throw new Exception(string.Format("You can not deposit amount greater than { 0 }", MaxDepositAmount.ToString()));
            }
            AccountBalance = AccountBalance + amount;

            TransactionSummary = string.Format("{0}\n Deposit:{1}",TransactionSummary, amount);
        }
        public override void Withdraw(decimal amount)
        {
            // some hard coded logic that withdraw count should not be greater than 3
            if (withdrawCount > 3)
            {
                throw new Exception("You can not withdraw amount more than thrice");
            }
            if (AccountBalance - amount <= MinAccountBalance)
            {
                throw new Exception("You can not withdraw amount from your Savings Account as Minimum Balance limit is reached");
            }
            AccountBalance = AccountBalance - amount;
            withdrawCount++;
            TransactionSummary = string.Format("{0}\n Withdraw:{1}",TransactionSummary, amount);
        }
        // This method adds details to the base class Reporting functionality 
        public override void GenerateAccountReport()
        {
            log.Info("Saving Account Report");
            base.GenerateAccountReport();
            // Send an email to user if Savings account balance is less 
            // than user specified balance this is different than MinAccountBalance
            if (AccountBalance > 15000)
            {
                log.InfoFormat("Sending Email for Account {0}", AccountNumber);
            }
        }
    }
    public class CurrentBankAccount : BankAccount
    {
        public CurrentBankAccount(string accountOwnerName, string accountNumber)
            : base(accountOwnerName, accountNumber)
        {
            this.MinAccountBalance = 0m;
            this.MaxDepositAmount = 100000000m;
            InteresetRate = .25m;
        }
        public override void Deposit(decimal amount)
        {
            AccountBalance = AccountBalance + amount;
            TransactionSummary = string.Format("{0}\n Deposit:{1}",TransactionSummary, amount);
        }
        public override void Withdraw(decimal amount)
        {
            if (AccountBalance - amount <= MinAccountBalance)
            {
                throw new Exception("You can not withdraw amount from your Current Account as Minimum Balance limit is reached");
            }
            AccountBalance = AccountBalance - amount;
            TransactionSummary = string.Format("{0}\n Withdraw:{1}",TransactionSummary, amount);
        }
    }
}
