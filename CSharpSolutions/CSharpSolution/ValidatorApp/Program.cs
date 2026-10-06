using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ValidatorApp
{
    /// <summary>
    /// Serves as the main execution logic for validation operations.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Provides main entry point for the validation operations.
        /// </summary>
        public static void Main()
        {
            UtilityApp.Program.ShowMessage("This is the helper app.");
        }

        /// <summary>
        /// Checks whether the calculated value is positive or not.
        /// </summary>
        /// <param name="result">The calculated result.</param>
        /// <param name="operation">The type of arithmetic operation</param>
        public static void IsValidateCalculation(double result, string operation)
        {
            if (result > 0)
            {
                UtilityApp.Program.ShowMessage($"The result is positive.\nThe {operation} of two numbers: {result}");
            }
            else
            {
                UtilityApp.Program.ShowMessage("The result is negative.");
            }
        }
    }
}