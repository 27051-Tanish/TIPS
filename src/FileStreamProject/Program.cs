using FileStreamProject.Controller;
using FileStreamProject.View;

namespace FileStreamProject
{
    /// <summary>
    /// Provides the execution logic for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Provides the main entry point of the application.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main()
        {
            ConsoleView view = new ConsoleView();
            TaskController controller = new TaskController(view);
            await controller.RunTasks();
        }
    }
}