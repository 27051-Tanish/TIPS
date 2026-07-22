using System;

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
        /// <param name="name">name of the contact in the contact manager</param>
        /// <returns>bool representing the correctness of the name</returns>
        public static bool IsValidName(string? name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks phone number entered by the user.
        /// </summary>
        /// <param name="number">number</param>
        /// <returns>bool representing the correctness of the phone number</returns>
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
        /// Checks for valid email.
        /// </summary>
        /// <param name="email">email</param>
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
    }
}
