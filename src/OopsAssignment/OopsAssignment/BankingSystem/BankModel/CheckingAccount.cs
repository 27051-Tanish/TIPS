using OopsAssignment.Helper.ConstantVariables;

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
        /// <param name="accountNumber">Account number to be stored.</param>
        /// <param name="balance">Balance to be stored.</param>
        public CheckingAccount(string? accountNumber, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        /// <summary>
        /// Performs withdraw operation, deduct amount from the account.
        /// </summary>
        /// <param name="amount">The amount to debit from the balance.</param>
        /// <returns>string message indicating withdraw operation outcome</returns>
        public override string Withdraw(decimal amount)
        {
            if (this.Balance - amount < 0)
            {
                return TransactionResponse.GetFailureMessage();
            }

            this.Balance -= amount;
            return TransactionResponse.GetSuccessMessage(this.Balance);
        }
    }
}
