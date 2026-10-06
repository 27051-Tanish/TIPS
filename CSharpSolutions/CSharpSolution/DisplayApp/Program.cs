using UtilityApp;

namespace DisplayApp
{
    /// <summary>
    /// Provides the main entry point and presentation logic for the application,
    /// handling user interaction and formatting test outputs.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Displays the operational menu to the user in the console interface
        /// and hands off control to MathApp to process choices.
        /// </summary>
        public static void Main()
        {
            UtilityApp.Program.ShowMessage("=== MAIN MENU ===");
            UtilityApp.Program.ShowMessage("1. Add\n2. Sub\n3. Mul\n4. Div");
            UtilityApp.Program.ShowMessage("Enter your choice: ");
        }

        /// <summary>
        /// Outputs a formatted string representation of a generic calculation result to the console window.
        /// </summary>
        /// <param name="result">The specific value to be printed to the screen.</param>
        /// <returns>The resultant value.</returns>
        public static double DisplayResult(double result)
        {
            return result;
        }

        /// <summary>
        /// Halts execution and prompts the user to press a key before closing the console application window.
        /// </summary>
        public static void CloseMethod()
        {
            UtilityApp.Program.ShowMessage("Press any key to close.");
            Console.ReadKey();
        }
    }
}
