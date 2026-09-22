namespace FileStreamProject.View
{
    /// <summary>
    /// Provides methods to communicate, write messages and read input from user in the UI.
    /// </summary>
    public class ConsoleView
    {
        /// <summary>
        /// Writes a message to the UI.
        /// </summary>
        /// <param name="message">The message to be written.</param>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays a prompt and reads console input, repeatedly showing an error message until a valid integer is entered.
        /// </summary>
        /// <param name="prompt">The prompt to be displayed.</param>
        /// <returns>A valid integer number.</returns>
        public int GetIntInput(string prompt)
        {
            this.ShowMessage(prompt);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    return number;
                }

                this.ShowMessage("Please enter valid integer number.");
            }
        }

        /// <summary>
        /// Displays the title of the task in the UI.
        /// </summary>
        /// <param name="title">The title of the task.</param>
        public void ShowTitle(string title)
        {
            this.ShowMessage(new string('=', 25));
            this.ShowMessage($"       {title}");
            this.ShowMessage(new string('=', 25));
        }

        /// <summary>
        /// Clears the console after executing a method.
        /// </summary>
        public void ConsoleClear()
        {
            this.ShowMessage("Press any key to close...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
