using AsynchronousProgramming.Controller;
using AsynchronousProgramming.View;

namespace Assignments
{
    /// <summary>
    /// Provides execution logic of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Provides main entry point of the application.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main()
        {
            ConsoleView view = new ConsoleView();
            TaskController controller = new TaskController(view);
            await controller.RunApplication();
        }
    }
}