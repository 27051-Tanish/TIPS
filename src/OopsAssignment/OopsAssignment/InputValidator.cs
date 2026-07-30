using System;

namespace OopsAssignment
{
    /// <summary>
    /// Validates the user input.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Validates the name of the user.
        /// </summary>
        /// <param name="name">name to validate</param>
        /// <returns>bool for verifying the correct name</returns>
        public static bool ValidateName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            if (name.All(c => char.IsDigit(c)))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the account number of the user.
        /// </summary>
        /// <param name="accountNumber">account number to validate</param>
        /// <returns>bool for verifying the correctness of the account number</returns>
        public static bool ValidateAccountNumber(string? accountNumber)
        {
            int minimumAccountNumberLength = 9;
            int maximumAccountNumberLength = 18;

            if (string.IsNullOrEmpty(accountNumber) || string.IsNullOrWhiteSpace(accountNumber))
            {
                return false;
            }

            if (accountNumber.Length < minimumAccountNumberLength || accountNumber.Length > maximumAccountNumberLength)
            {
                return false;
            }

            if (!accountNumber.All(c => char.IsDigit(c)))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates whether a deposit amount falls within a permissible range.
        /// </summary>
        /// <param name="amount">The deposit amount to validate.</param>
        /// <returns>True if the amount is greater than or equal to zero; otherwise, false.</returns>
        public static bool ValidateDepositAmount(decimal amount)
        {
            if (amount < 0 || amount > decimal.MaxValue)
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
            if (amount > 0 && balance > decimal.MaxValue - amount)
            {
                return false;
            }

            if (amount < 0 && balance < decimal.MinValue - amount)
            {
                return false;
            }

            return true;
        }
    }
}
