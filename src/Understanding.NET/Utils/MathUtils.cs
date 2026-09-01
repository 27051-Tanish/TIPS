namespace Understanding.NET.Utils
{
    /// <summary>
    /// Utility class which handles different mathematical operations in different methods.
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// Performs addition operation between two numbers.
        /// </summary>
        /// <param name="number1">The first number.</param>
        /// <param name="number2">The second number.</param>
        /// <returns>The sum of two numbers.</returns>
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Performs subtraction operation between two numbers.
        /// </summary>
        /// <param name="number1">The first number.</param>
        /// <param name="number2">The second number.</param>
        /// <returns>The difference of two numbers.</returns>
        public int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }

        /// <summary>
        /// Performs multiplication operation between two numbers.
        /// </summary>
        /// <param name="number1">The first number.</param>
        /// <param name="number2">The second number.</param>
        /// <returns>The product of two numbers.</returns>
        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        /// <summary>
        /// Performs division operation between two numbers.
        /// </summary>
        /// <param name="number1">The first number.</param>
        /// <param name="number2">The second number.</param>
        /// <returns>The quotient after the division of two numbers.</returns>
        public int Divide(int number1, int number2)
        {
            return number1 / number2;
        }
    }
}
