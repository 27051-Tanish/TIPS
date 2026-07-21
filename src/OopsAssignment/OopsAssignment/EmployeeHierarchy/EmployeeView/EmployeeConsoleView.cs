using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsAssignment.EmployeeHierarchy.EmployeeView
{
    /// <summary>
    /// Provides console operations.
    /// </summary>
    public class EmployeeConsoleView
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
