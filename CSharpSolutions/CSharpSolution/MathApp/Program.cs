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
                        double result1 = DisplayApp.Program.DisplayResult(calculator.Add(5, 6));
                        ValidatorApp.Program.IsValidateCalculation(result1, "sum");
                        break;
                    case 2:
                        double result2 = DisplayApp.Program.DisplayResult(calculator.Sub(12, 6));
                        ValidatorApp.Program.IsValidateCalculation(result2, "difference");
                        break;
                    case 3:
                        double result3 = DisplayApp.Program.DisplayResult(calculator.Add(5, 6));
                        ValidatorApp.Program.IsValidateCalculation(result3, "product");
                        break;
                    case 4:
                        double result4 = DisplayApp.Program.DisplayResult(calculator.Add(24, 6));
                        ValidatorApp.Program.IsValidateCalculation(result4, "quotient");
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
