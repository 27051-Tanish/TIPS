using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// helper class
    /// </summary>
    public static class InputValidater
    {
        /// <summary>
        /// Validates name of the contact
        /// </summary>
        /// <param name="name">name of the contact in the contact manager</param>
        /// <returns>bool</returns>
        public static bool IsValidName(string? name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks number entered by the user
        /// </summary>
        /// <param name="number">number</param>
        /// <returns>bool</returns>
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
        /// Checks for valid email
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>bool</returns>
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
