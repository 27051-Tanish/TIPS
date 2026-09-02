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
            try
            {
                ConsoleView.ShowMessage("\n=== Calculator application ===\n");
                ConsoleView.ShowMessage("Enter number 1 :");
                int number1 = ConsoleView.GetIntInput();
                ConsoleView.ShowMessage("Enter number 2 :");
                int number2 = ConsoleView.GetIntInput();

                ConsoleView.ShowMessage("\n=== RESULTS ===\n");
                ConsoleView.ShowMessage($"Addition : {MathUtils.Add(number1, number2)}");
                ConsoleView.ShowMessage($"Subtraction : {MathUtils.Subtract(number1, number2)}");
                ConsoleView.ShowMessage($"Multiplication : {MathUtils.Multiply(number1, number2)}");
                ConsoleView.ShowMessage($"Division : {MathUtils.Divide(number1, number2):f2}\n");
            }
            catch (OverflowException ex)
            {
                ConsoleView.ShowMessage($"Error: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                ConsoleView.ShowMessage($"Error: {ex.Message}");
            }
            finally
            {
                ConsoleView.ShowMessage("Press any key to close...");
                Console.ReadKey();
            }
        }
    }
}
