namespace Understanding.NET.View
{
    /// <summary>
    /// Acts as UI for handling the reading and writing operations. 
    /// </summary>
    public static class ConsoleView
    {
        /// <summary>
        /// Gets an integer number and returns if valid.
        /// </summary>
        /// <returns>The integer number if valid, otherwise error message.</returns>
        public static int GetIntInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    return number;
                }

                Console.WriteLine("Please enter valid integer number.");
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
