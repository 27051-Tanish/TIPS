using System.Runtime.CompilerServices;
using Understanding.NET.Utils;
using Understanding.NET.View;

namespace Understanding.NET
{
    /// <summary>
    /// Contains the main execution logic for performing basic mathematical operations.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Serves as the primary entry point of the application.
        /// </summary>
        public static void Main()
        {
            MathUtils math = new MathUtils();
            try
            {
                ConsoleView.ShowMessage("Enter number 1 :");
                int number1 = ConsoleView.GetIntInput();
                ConsoleView.ShowMessage("Enter number 2 :");
                int number2 = ConsoleView.GetIntInput();

                ConsoleView.ShowMessage("\n=== RESULTS ===\n");
                ConsoleView.ShowMessage($"Addition : {math.Add(number1, number2)}");
                ConsoleView.ShowMessage($"Subtraction : {math.Subtract(number1, number2)}");
                ConsoleView.ShowMessage($"Multiplication : {math.Multiply(number1, number2)}");
                ConsoleView.ShowMessage($"Division : {math.Divide(number1, number2)}\n");
            }
            catch (DivideByZeroException ex)
            {
                ConsoleView.ShowMessage($"Error : {ex.Message}");
            }
            finally
            {
                ConsoleView.ShowMessage("Enter any key to close...");
                Console.ReadKey();
            }
        }
    }
}