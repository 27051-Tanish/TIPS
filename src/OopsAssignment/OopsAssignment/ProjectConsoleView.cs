namespace OopsAssignment
{
    /// <summary>
    /// Provides console-based UI methods for displaying menus, messages,
    /// and reading user input for various application modules.
    /// </summary>
    public class ProjectConsoleView
    {
        /// <summary>
        /// Display different menu information.
        /// </summary>
        /// <param name="message">Menu information to be displayed.</param>
        public void ShowMenu(string message)
        {
            this.EndLine();
            this.ShowMessage(message);
            this.EndLine();
        }

        /// <summary>
        /// Writes a message to the console.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public void ShowMessage(string? message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Writes a visual separator line to the console for improved readability.
        /// </summary>
        public void EndLine()
        {
            Console.WriteLine(new string('=', 25));
        }

        /// <summary>
        /// Reads a line of input from the console.
        /// </summary>
        /// <returns>The input entered by the user, or null, if no input is available.</returns>
        public string? ReadInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Attempts to parse the user input.
        /// </summary>
        /// <param name="message">The message needed to displayed.</param>
        /// <returns>Choice of required type if true, otherwise the error message.</returns>
        public int GetChoice(string message)
        {
            while (true)
            {
                if (int.TryParse(this.ReadInput(), out int choiceValue))
                {
                    return choiceValue;
                }
                else
                {
                    this.ShowMessage(message);
                }
            }
        }

        /// <summary>
        /// Attempts to parse the user input.
        /// </summary>
        /// <returns>Value of required type if true, otherwise the error message.</returns>
        public double GetInput()
        {
            while (true)
            {
                if (double.TryParse(this.ReadInput(), out double value))
                {
                    return value;
                }
                else
                {
                    this.ShowMessage("Invalid input for dimension.\nEnter again :");
                }
            }
        }

        /// <summary>
        /// Attempts to parse the user input.
        /// </summary>
        /// <returns>Value of required type if true, otherwise the error message.</returns>
        public decimal GetSalary()
        {
            while (true)
            {
                if (decimal.TryParse(this.ReadInput(), out decimal salary))
                {
                    return salary;
                }
                else
                {
                    this.ShowMessage($"Salary should not contains characters and should not exceed the limit.\nSalary limit :{decimal.MaxValue}\nPlease enter valid salary :");
                }
            }
        }
    }
}
