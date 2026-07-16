using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// helper class
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Checks number
        /// </summary>
        /// <param name="number">number</param>
        /// <returns>bool</returns>
        public static bool IsValidNumber(string number)
        {
            if (number.Length != 10)
            {
                return false;
            }

            foreach (char c in number)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
