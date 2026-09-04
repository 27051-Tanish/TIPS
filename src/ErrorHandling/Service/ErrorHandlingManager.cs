using ErrorHandling.Exceptions;

namespace ErrorHandling.Service
{
    /// <summary>
    /// Performs different task operations.
    /// </summary>
    public class ErrorHandlingManager
    {
        /// <summary>
        /// Performs division operation between two numbers.
        /// </summary>
        /// <param name="dividend">The number that want to divide up.</param>
        /// <param name="divisor">The number that used to divide by.</param>
        /// <returns>Divided value if valid inputs, otherwise throws an exception.</returns>
        /// <exception cref="DivideByZeroException">Throws an exception when the divisor is zero.</exception>
        public int DivideTwoDigits(int dividend, int divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("Cannot divide a number by zero.");
            }

            return dividend / divisor;
        }

        /// <summary>
        /// Retrieves the number present in the array of given index.
        /// </summary>
        /// <param name="array">The array of numbers.</param>
        /// <param name="index">The index of the number in the array.</param>
        /// <returns>The number present in the index of the array.</returns>
        public int FindIndex(int[] array, int index)
        {
            return array[index];
        }

        /// <summary>
        /// Returns the number passed to the parameter.
        /// </summary>
        /// <param name="number">The number to be returned.</param>
        /// <returns>The number passes as parameter.</returns>
        public int HandleCustomException(int number)
        {
            if (number < 0)
            {
                throw new InvalidUserInputException("The value should not be a negative number.");
            }

            return number;
        }
    }
}
