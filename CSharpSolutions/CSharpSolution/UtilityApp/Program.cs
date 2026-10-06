namespace UtilityApp
{
    /// <summary>
    /// Provides the execution logic for utility class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Provides main entry point of the utility method/methods.
        /// </summary>
        /// <param name="args">An array of command-line arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            ShowMessage("This is the utility method.");
        }

        /// <summary>
        /// Writes a message to the console.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public static void ShowMessage(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
