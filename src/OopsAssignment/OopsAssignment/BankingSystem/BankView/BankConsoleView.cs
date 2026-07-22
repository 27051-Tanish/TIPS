using System;

namespace OopsAssignment.BankingSystem.BankView
{
    /// <summary>
    /// Provides console operations.
    /// </summary>
    public class BankConsoleView
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
        /// Reads user input from the console.
        /// </summary>
        /// <returns>console readline to read input</returns>
        public string? ReadInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Draws endline for improving console view.
        /// </summary>
        public void EndLine()
        {
            Console.WriteLine("===========================");
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
