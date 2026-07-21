using System;

namespace OopsAssignment.ShapeHierarchy.View
{
    /// <summary>
    /// Provides console view to the user
    /// </summary>
    public class ShapeView
    {
        /// <summary>
        /// Show Console messages to the user
        /// </summary>
        /// <param name="message">message that user wants to view in console</param>
        public void ShowMessage(string message)
        {
             Console.WriteLine(message);
        }

        /// <summary>
        /// Reads user input from console
        /// </summary>
        /// <returns>string that reads from user</returns>
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
