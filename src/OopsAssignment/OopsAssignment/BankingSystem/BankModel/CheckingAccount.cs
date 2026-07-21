using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsAssignment.BankingSystem.BankModel
{
    /// <summary>
    /// Inherits the BankAccount class and its methods and properties.
    /// </summary>
    public class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">string represent account number</param>
        /// <param name="balance">decimal represent balance</param>
        public CheckingAccount(string accountNumber, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        /// <summary>
        /// Performs withdraw operation, deduct amount from the account.
        /// </summary>
        /// <param name="amount">decimal amount representing the withdraw amount</param>
        /// <returns>string message indicating withdraw operation outcome</returns>
        public override string Withdraw(decimal amount)
        {
            if (this.Balance - amount < 0)
            {
                return $"Withdraw unsuccessful";
            }

            return $"Withdraw operation successfully completed\nBalance :{this.Balance}";
        }
    }
}
