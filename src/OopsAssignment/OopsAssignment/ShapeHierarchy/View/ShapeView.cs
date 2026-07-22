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
        /// Draws endline for improving console view.
        /// </summary>
        public void EndLine()
        {
            Console.WriteLine("===========================");
        }

        /// <summary>
        /// Reads user input from console
        /// </summary>
        /// <returns>console readline to read input </returns>
        public string? ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
