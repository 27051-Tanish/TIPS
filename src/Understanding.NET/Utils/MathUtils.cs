namespace Understanding.NET.Utils
{
    /// <summary>
    /// Utility class which handles different mathematical operations in different methods.
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// Performs addition operation between two numbers.
        /// </summary>
        /// <param name="number1">The first number.</param>
        /// <param name="number2">The second number.</param>
        /// <exception cref="OverflowException">Thrown if the result exceeds integer limits.</exception>
        /// <returns>The sum of two numbers.</returns>
        public static int Add(int number1, int number2)
        {
            return checked(number1 + number2);
        }

        /// <summary>
        /// Performs subtraction operation between two numbers.
        /// </summary>
        /// <param name="number1">The first number.</param>
        /// <param name="number2">The second number.</param>
        /// <exception cref="OverflowException">Thrown if the result exceeds integer limits.</exception>
        /// <returns>The difference of two numbers.</returns>
        public static int Subtract(int number1, int number2)
        {
            return checked(number1 - number2);
        }

        /// <summary>
        /// Performs multiplication operation between two numbers.
        /// </summary>
        /// <param name="number1">The first number.</param>
        /// <param name="number2">The second number.</param>
        /// <exception cref="OverflowException">Thrown if the result exceeds integer limits.</exception>
        /// <returns>The product of two numbers.</returns>
        public static int Multiply(int number1, int number2)
        {
            return checked(number1 * number2);
        }

        /// <summary>
        /// Performs division operation between two numbers.
        /// </summary>
        /// <param name="number1">The first number.</param>
        /// <param name="number2">The second number.</param>
        /// <exception cref="DivideByZeroException">Thrown if number2 is 0.</exception>
        /// <returns>The quotient after the division of two numbers.</returns>
        public static decimal Divide(int number1, int number2)
        {
            return (decimal)number1 / number2;
        }
    }
}
