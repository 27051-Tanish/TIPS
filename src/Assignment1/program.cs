using System;
using Assignment1.Services;

namespace Assignment1
{
    /// <summary>
    /// First Assignment
    /// </summary>
    public class Program
    {
        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args">Console-Based Contact Manager</param>
        public static void Main(string[] args)
        {
            ContactManager manager = new ContactManager();
            ConsoleActivity activity = new ConsoleActivity();

            ContactController controller = new ContactController(activity, manager);
            controller.Run();
        }
    }
}