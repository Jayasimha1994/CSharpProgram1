using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOApplication
{
    /// <summary>
    /// Company Interface is having several departments and employees can implement the 
    /// method Department to provide their job information
    /// </summary>
    interface Company
    {
        /// <summary>
        /// classes can make use of the department method by providing their own implementation.
        /// </summary>
        void Department();
    }
    /// <summary>
    /// Employee1 implements the Company interface to provide professional details
    /// </summary>
    class Employee1 : Company
    {
        private static readonly log4net.ILog log
      = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void Department()
        {
            log.Info("Dept-IT Software Engineer");
        }
    }
    /// <summary>
    /// Employee2 implements the Company interface to provide professional details
    /// </summary>
    class Employee2 : Company
    {
        private static readonly log4net.ILog log
      = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void Department()
        {
            log.Info("Dept-Accounts Accountant");
        }
    }
    public class EmployeeInfo
    {
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            Employee1 employee1 = new Employee1();
            employee1.Department();
            Employee2 employee2 = new Employee2();
            employee2.Department();
        }
    }
}
