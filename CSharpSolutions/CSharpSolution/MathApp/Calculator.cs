namespace MathApp
{
    /// <summary>
    /// Provides methods for performing basic mathematical calculations.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Provides the sum of two numbers.
        /// </summary>
        /// <param name="number1">The first number.</param>
        /// <param name="number2">The second number.</param>
        /// <returns>The sum of two numbers.</returns>
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Provides the difference between two numbers.
        /// </summary>
        /// <param name="number1">The first number.</param>
        /// <param name="number2">The second number.</param>
        /// <returns>The difference between two numbers.</returns>
        public int Sub(int number1, int number2)
        {
            return number1 - number2;
        }

        /// <summary>
        /// Provides the product of two numbers.
        /// </summary>
        /// <param name="number1">The first number.</param>
        /// <param name="number2">The second number.</param>
        /// <returns>The product of two numbers.</returns>
        public double Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        /// <summary>
        /// Provides the quotient of two numbers.
        /// </summary>
        /// <param name="dividend">The first number.</param>
        /// <param name="divisor">The second number.</param>
        /// <returns>The quotient of two numbers.</returns>
        public double Divide(int dividend, int divisor)
        {
            return dividend / divisor;
        }
    }
}
