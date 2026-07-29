using System;
using Assignment1.Services;

namespace Assignment1
{
    /// <summary>
    /// A console-based contact management application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the project.
        /// Initializes core components and starts the contact manager.
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