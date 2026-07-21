using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
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
        public static bool ValidateAccountNumber(string accountNumber)
        {
            if (accountNumber.Length < 10 && accountNumber.Length > 17)
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
