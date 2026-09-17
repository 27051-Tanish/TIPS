namespace Understanding.NET.View
{
    /// <summary>
    /// Acts as UI for handling the reading and writing operations.
    /// </summary>
    public static class ConsoleView
    {
        /// <summary>
        /// Displays a prompt and reads console input, repeatedly showing an error message until a valid integer is entered.
        /// </summary>
        /// <param name="prompt">The prompt to be displayed.</param>
        /// <returns>A valid integer number.</returns>
        public static int GetIntInput(string prompt)
        {
            ShowMessage(prompt);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    return number;
                }

                ShowMessage("Please enter valid integer number.");
            }
        }

        /// <summary>
        /// Writes the message to the UI.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
