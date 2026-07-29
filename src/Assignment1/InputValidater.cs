using System.Text.RegularExpressions;

namespace Assignment1
{
    /// <summary>
    /// Validates user input name, email, phone number.
    /// </summary>
    public static class InputValidater
    {
        /// <summary>
        /// Validates name of the contact.
        /// </summary>
        /// <param name="name">The contact name to validate.</param>
        /// <returns>True, if the name is valid, otherwise false.</returns>
        public static bool IsValidName(string? name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// validates the phone number of the contact information.
        /// </summary>
        /// <param name="number">The contact number to validate.</param>
        /// <returns>True, if the number is valid otherwise false.</returns>
        public static bool IsValidNumber(string? number)
        {
            if (number == null)
            {
                return false;
            }

            string pattern = @"^[0-9]{10}$";
            return Regex.IsMatch(number, pattern);
        }

        /// <summary>
        /// Validates the email of the contact information.
        /// </summary>
        /// <param name="email">The email to validate.</param>
        /// <returns>bool representing the correctness of the email</returns>
        public static bool IsValidEmail(string? email)
        {
            if (email == null)
            {
                return false;
            }

            string pattern = @"^[a-zA-Z0-9.]+@[a-zA-Z]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        /// <summary>
        /// Checks if the search value is null or not.
        /// </summary>
        /// <param name="searchKey">Search value provided by user.</param>
        /// <returns>True if search value is not null, otherwise false.</returns>
        public static bool IsValidSearchKey(string? searchKey)
        {
            if (searchKey == null)
            {
                return false;
            }

            return true;
        }
    }
}
