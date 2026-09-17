using AdvancedCSharpConcepts.AdvancedTasks;
using AdvancedCSharpConcepts.Controller;
using AdvancedCSharpConcepts.View;

namespace AdvancedCSharpConcepts
{
    /// <summary>
    /// Provides the main execution logic for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Provides the main entry point to the application.
        /// </summary>
        public static void Main()
        {
            ConsoleView view = new ConsoleView();
            Notifier notifier = new Notifier();
            TaskController controller = new TaskController(view, notifier);
            controller.RunApplication();
        }
    }
}