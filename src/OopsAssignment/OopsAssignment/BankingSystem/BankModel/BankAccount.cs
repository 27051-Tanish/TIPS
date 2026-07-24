using System;

namespace OopsAssignment.BankingSystem.BankModel
{
    /// <summary>
    /// Base class for project.
    /// </summary>
    public abstract class BankAccount
    {
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// Account number of the user.
        /// </value>
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// Bank balance of the user.
        /// </value>
        public decimal Balance { get; set; }

        /// <summary>
        /// Deposit given amount into the account and update balance.
        /// </summary>
        /// <param name="amount">decimal amount representing deposit operation</param>
        /// <returns>decimal representing balance</returns>
        public string Deposit(decimal amount)
        {
            this.Balance += amount;
            return $"Balance :{this.Balance}";
        }

        /// <summary>
        /// Withdraw given amount from the account and update balance.
        /// </summary>
        /// <param name="amount">decimal amount representing withdraw operation</param>
        /// <returns>decimal representing balance</returns>
        public abstract string Withdraw(decimal amount);

        /// <summary>
        /// Prints the details of the bank account.
        /// </summary>
        /// <returns>string of bank details</returns>
        public virtual string? PrintDetails()
        {
            return $"Account Number : {this.AccountNumber}\nBalance : {this.Balance}";
        }
    }
}
