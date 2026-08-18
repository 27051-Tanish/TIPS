using OopsAssignment.Helper.ConstantVariables;

namespace OopsAssignment.Helper
{
    /// <summary>
    /// Validates the user input.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Validates the name of the user.
        /// </summary>
<<<<<<< HEAD
        /// <param name="name">Name to validate.</param>
=======
        /// <param name="name">name to validate</param>
>>>>>>> 17d2e2e3cefcb344d9ed2f92709ef00e9eddc480
        /// <returns>True, if the name is valid otherwise false.</returns>
        public static bool ValidateName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Any(c => char.IsDigit(c)))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the dimensions of the shape.
        /// </summary>
        /// <param name="dimension">The dimension of the shape to validate.</param>
        /// <returns>True if the dimensions are valid, otherwise false.</returns>
        public static bool ValidateDimension(double dimension)
        {
            if (dimension < 0 || dimension > double.MaxValue || double.IsNaN(dimension))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the amount read from the console.
        /// </summary>
        /// <param name="amount">Amount to be validated.</param>
        /// <returns>True if the amount is valid, otherwise false.</returns>
        public static bool ValidateAmount(decimal amount)
        {
            if (amount < 0 || amount > decimal.MaxValue)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the account number of the user.
        /// </summary>
        /// <param name="accountNumber">Account number to validate</param>
        /// <returns>True if the account number is valid otherwise false.</returns>
        public static bool ValidateAccountNumber(string? accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber) ||
               (accountNumber.Length < AccountConstants.MinimumAccountNumberLength || accountNumber.Length > AccountConstants.MaximumAccountNumberLength) ||
               (!accountNumber.All(c => char.IsDigit(c))))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if adding a transaction amount to the balance causes an overflow.
        /// </summary>
        /// <param name="amount">The transaction amount to add.</param>
        /// <param name="balance">The current bank balance.</param>
        /// <returns>True if the total stays within valid decimal limits; otherwise, false.</returns>
        public static bool CheckBankBalance(decimal amount, decimal balance)
        {
            if ((amount > 0 && balance > decimal.MaxValue - amount) || (amount < 0 && balance < decimal.MinValue - amount))
            {
                return false;
            }

            return true;
        }
    }
}
