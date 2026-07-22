using System;

namespace OopsAssignment
{
    /// <summary>
    /// Acts as view layer for project controller.
    /// </summary>
    public class ProjectConsoleView
    {
        /// <summary>
        /// Display message in the console.
        /// </summary>
        /// <param name="message">string message</param>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Draws endline for improving console view.
        /// </summary>
        public void EndLine()
        {
            Console.WriteLine("===========================");
        }

        /// <summary>
        /// Reads user input from the console.
        /// </summary>
        /// <returns>console readline to read input</returns>
        public string? ReadInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Waits until user clicks any key
        /// </summary>
        public void ExitKey()
        {
            Console.ReadKey();
        }
    }
}
