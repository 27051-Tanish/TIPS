using ErrorHandling.Service;
using ErrorHandling.View;

namespace Assignments
{
    /// <summary>
    /// Contains the main execution logic for the error handling application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Serves as the primary entry point of the application.
        /// </summary>
        public static void Main()
        {
            ErrorHandlingManager manager = new ();
            ConsoleView view = new (manager);
            view.RunApplication();
        }
    }
}
