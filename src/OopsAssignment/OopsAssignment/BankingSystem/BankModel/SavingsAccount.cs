using System;

namespace OopsAssignment.BankingSystem.BankModel
{
    /// <summary>
    /// Inherits the BankAccount class to access its methods.
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Stores the minimum balance value.
        /// </summary>
        public const decimal MinimumBalance = 1000m;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">string represent account number</param>
        /// <param name="balance">decimal represent balance</param>
        public SavingsAccount(string? accountNumber, decimal balance)
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
                return $"Withdraw operation failed";
            }

            return $"Withdraw operation successful\nBalance: {this.Balance}";
        }
    }
}
