using DisplayApp;

namespace MathApp
{
    /// <summary>
    /// Serves as the primary execution engine for the arithmetic application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Provides main entry point of the program.
        /// </summary>
        public static void Main()
        {
            ExecuteCalculations();
        }

        /// <summary>
        /// Processes user input menu selections and triggers matching Calculator methods.
        /// </summary>
        public static void ExecuteCalculations()
        {
            Calculator calculator = new Calculator();
            DisplayApp.Program.Main();
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        DisplayApp.Program.DisplayResult(calculator.Add(5, 6));
                        break;
                    case 2:
                        DisplayApp.Program.DisplayResult(calculator.Sub(12, 6));
                        break;
                    case 3:
                        DisplayApp.Program.DisplayResult(calculator.Multiply(5, 6));
                        break;
                    case 4:
                        DisplayApp.Program.DisplayResult(calculator.Divide(24, 6));
                        break;
                    default:
                        UtilityApp.Program.ShowMessage("Invalid choice...");
                        break;
                }
            }
            else
            {
                UtilityApp.Program.ShowMessage("Please enter a valid numeric option.");
            }

            DisplayApp.Program.CloseMethod();
        }
    }
}
