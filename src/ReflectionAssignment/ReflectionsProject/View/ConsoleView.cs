namespace ReflectionsProject.View
{
    /// <summary>
    /// Provides methods for writing messages, reading inputs and showing menu in the UI.
    /// </summary>
    public static class ConsoleView
    {
        /// <summary>
        /// Writes a message to the UI.
        /// </summary>
        /// <param name="message">The message to be written.</param>
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Reads user input from the UI.
        /// </summary>
        /// <returns>The input read from the UI.</returns>
        public static string? ReadInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Displays a prompt and reads console input, repeatedly showing an error message until a valid integer is entered.
        /// </summary>
        /// <param name="prompt">The prompt to be displayed.</param>
        /// <param name="errorMessage">The error message to be displayed.</param>
        /// <returns>A valid integer number.</returns>
        public static int GetIntInput(string prompt, string errorMessage)
        {
            ShowMessage(prompt);
            while (true)
            {
                if (int.TryParse(ReadInput(), out int value))
                {
                    return value;
                }

                ShowMessage(errorMessage);
            }
        }

        /// <summary>
        /// Displays the title of the task in the UI.
        /// </summary>
        /// <param name="title">The title of the task.</param>
        public static void ShowTitle(string title)
        {
            ShowMessage(new string('=', 25));
            ShowMessage($"       {title}");
            ShowMessage(new string('=', 25));
        }

        /// <summary>
        /// Clears the console after executing a method.
        /// </summary>
        public static void ConsoleClear()
        {
            ShowMessage("Press any key to close...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
