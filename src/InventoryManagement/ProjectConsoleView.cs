using System;

namespace InventoryManagement
{
    /// <summary>
    /// Acts as view layer for project controller.
    /// </summary>
    internal class ProjectConsoleView
    {
        /// <summary>
        /// Display message in the console.
        /// </summary>
        /// <param name="message">string message that user wants to display</param>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Reads user input from the console.
        /// </summary>
        public void ReadInput()
        {
            Console.ReadLine();
        }

        /// <summary>
        /// Draws endline for improving console view.
        /// </summary>
        public void EndLine()
        {
            Console.WriteLine("=====================");
        }
    }
}
