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
        public static void Main()
        {
            ContactManager manager = new ContactManager();
            ConsoleActivity activity = new ConsoleActivity();

            ContactController controller = new ContactController(activity, manager);
            controller.Run();
        }
    }
}