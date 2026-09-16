namespace AdvancedCSharpConcepts.View
{
    /// <summary>
    /// Provides console-based UI methods for displaying messages,
    /// and reading user input for various application modules.
    /// </summary>
    public class ConsoleView
    {
        /// <summary>
        /// Writes the content to the UI.
        /// </summary>
        /// <param name="message">The message to be written.</param>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
