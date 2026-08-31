using ErrorHandling.Enum;
using ErrorHandling.Exceptions;
using ErrorHandling.Service;

namespace ErrorHandling.View
{
    /// <summary>
    /// Acts as the UI for the console application.
    /// </summary>
    public class ConsoleView
    {
        private readonly ErrorHandlingManager _errorHandlingManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleView"/> class.
        /// </summary>
        /// <param name="errorHandlingManager">The instance of the service layer.</param>
        public ConsoleView(ErrorHandlingManager errorHandlingManager)
        {
            this._errorHandlingManager = errorHandlingManager;
        }

        /// <summary>
        /// Starts the execution of the application.
        /// </summary>
        public void RunApplication()
        {
            int choice;
            MainMenu menu;
            do
            {
                this.ShowMessage("WELCOME TO ERROR HANDLING APPLICATION");
                this.ShowMenu();
                this.ShowMessage("Please select your option: ");
                choice = this.GetIntInput("The value should not be a character, whitespace or null.\n" +
                    "Please enter the choice again from the menu");
                menu = (MainMenu)choice;

                switch (menu)
                {
                    case MainMenu.Task1:
                        this.PerformTask1();
                        break;
                    case MainMenu.Task2:
                        this.PerformTask2();
                        break;
                    case MainMenu.Task3:
                        this.PerformTask3();
                        break;
                    case MainMenu.Task4:
                        this.PerformTask4();
                        break;
                    case MainMenu.Task5:
                        this.PerformTask5();
                        break;
                    case MainMenu.Exit:
                        break;
                    default:
                        this.ErrorMessage("Invalid input for choice.\nPlease select between [1 to 6].");
                        break;
                }
            }
            while (menu != MainMenu.Exit);
        }

        private void ShowMenu()
        {
            this.ShowMessage("[1]. Division");
            this.ShowMessage("[2]. Array Operation");
            this.ShowMessage("[3]. Custom Exception Operation");
            this.ShowMessage("[4]. App Domain");
            this.ShowMessage("[5]. Stack Trace");
            this.ShowMessage("[6]. Exit");
        }

        private void PerformTask1()
        {
            this.ShowMessage("Enter the dividend value :");
            int dividend = this.GetIntInput("The value should not be a character, whitespace or null.");
            this.ShowMessage("Enter the divisor value :");
            int divisor = this.GetIntInput("The value should not be a character, whitespace or null.");
            try
            {
                int result = this._errorHandlingManager.DivideTwoDigits(dividend, divisor);
                this.SuccessMessage($"Division result : {result}");
            }
            catch (DivideByZeroException ex)
            {
                this.ErrorMessage(ex.Message);
            }
            finally
            {
                this.ShowMessage("Division operation executed.");
            }
        }

        private void PerformTask2()
        {
            this.ShowMessage("Enter the size of the array : ");
            int size = this.GetIntInput("The value should not be a character, whitespace or null.");
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                this.ShowMessage($"Enter the {i}th digit : ");
                arr[i] = this.GetIntInput("The value should not be a character, whitespace or null.");
            }

            try
            {
                this.ShowMessage("Enter the index of the array : ");
                int index = this.GetIntInput("The index value should not be a character, whitespace or null.");
                int result = this._errorHandlingManager.FindIndex(arr, index);
                this.SuccessMessage($"Element at {index} : {result}");
            }
            catch (IndexOutOfRangeException ex)
            {
                this.ErrorMessage(ex.Message);
            }
            finally
            {
                this.ShowMessage("Array retrieval operation executed.");
            }
        }

        private void PerformTask3()
        {
            this.ShowMessage("Enter a positive number :");
            int number = this.GetIntInput("The value should not be a character, whitespace or null.");

            try
            {
                int result = this._errorHandlingManager.HandleCustomException(number);
                this.SuccessMessage($"Entered number is {result}");
            }
            catch (InvalidUserInputException ex)
            {
                this.ErrorMessage(ex.Message);
            }
            finally
            {
                this.ShowMessage("Custom exception operation executed.");
            }
        }

        private void PerformTask4()
        {
            AppDomain.CurrentDomain.UnhandledException += this.GlobalExceptionHandler;
            this.ShowMessage("Enter a positive number :");

            try
            {
                int number = int.Parse(this.ReadInput());
                int result = this._errorHandlingManager.HandleCustomException(number);
                this.SuccessMessage($"Entered number is {result}");
            }
            catch (InvalidUserInputException ex)
            {
                this.ErrorMessage(ex.Message);
            }

            // Comment this catch block to view global exception handling message from app domain.
            catch (Exception ex)
            {
                this.ErrorMessage(ex.Message);
            }
            finally
            {
                this.ShowMessage("App domain operation executed.");
            }
        }

        private void PerformTask5()
        {
            AppDomain.CurrentDomain.UnhandledException += this.GlobalExceptionHandler;
            this.ShowMessage("Enter a positive number :");

            try
            {
                int number = int.Parse(this.ReadInput());
                int result = this._errorHandlingManager.HandleCustomException(number);
                this.SuccessMessage($"Entered number is {result}");
            }
            catch (InvalidUserInputException ex)
            {
                this.ErrorMessage(ex.StackTrace);
            }
            catch (Exception ex)
            {
                this.ErrorMessage(ex.StackTrace);
            }
            finally
            {
                this.ShowMessage("Stack trace operation executed.");
            }
        }

        private void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                this.ErrorMessage("\n--- GLOBAL EXCEPTION HANDLER CAUGHT AN ERROR ---");
                this.ErrorMessage($"Fatal Error: {ex.Message}");
            }
        }

        private void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        private void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            this.ShowMessage(message);
            Console.ResetColor();
        }

        private void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            this.ShowMessage(message);
            Console.ResetColor();
        }

        private string? ReadInput()
        {
            return Console.ReadLine();
        }

        private int GetIntInput(string message)
        {
            while (true)
            {
                if (int.TryParse(this.ReadInput(), out int value))
                {
                    return value;
                }

                this.ShowMessage(message);
            }
        }
    }
}
