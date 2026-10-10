using ReflectionsProject.Controller;
using ReflectionsProject.View;

namespace Assignments
{
    /// <summary>
    /// Provides main execution logic for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Provides main entry point to the application.
        /// </summary>
        public static void Main()
        {
            TaskController controller = new TaskController();
            controller.RunApplication();
        }
    }
}