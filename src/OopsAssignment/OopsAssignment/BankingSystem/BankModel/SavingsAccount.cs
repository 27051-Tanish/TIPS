using OopsAssignment.Helper.ConstantVariables;

namespace OopsAssignment.BankingSystem.BankModel
{
    /// <summary>
    /// Inherits the BankAccount class to access its methods.
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">Account number to be stored.</param>
        /// <param name="balance">Bank balance to be stored.</param>
        public SavingsAccount(string? accountNumber, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        /// <summary>
        /// Performs withdraw operation, deduct amount from the account.
        /// </summary>
        /// <param name="amount">The amount to be debited from the account balance.</param>
        /// <returns>Message regarding withdrawal operation.</returns>
        public override string Withdraw(decimal amount)
        {
            if (this.Balance - amount < AccountConstants.MinimumBalance)
            {
                return $"Transaction Failed: A minimum balance of {AccountConstants.MinimumBalance} must be maintained.";
            }

            this.Balance -= amount;
            return TransactionResponse.GetSuccessMessage(this.Balance);
        }
    }
}
