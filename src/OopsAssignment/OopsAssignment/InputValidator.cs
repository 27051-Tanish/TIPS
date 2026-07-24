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
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
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
            if (accountNumber.Length < minimumAccountNumberLength || accountNumber.Length > maximumAccountNumberLength)
            {
                return false;
            }

            if (string.IsNullOrEmpty(accountNumber) || string.IsNullOrWhiteSpace(accountNumber))
            {
                return false;
            }

            if (!accountNumber.All(c => char.IsDigit(c)))
            {
                return false;
            }

            return true;
        }
    }
}
