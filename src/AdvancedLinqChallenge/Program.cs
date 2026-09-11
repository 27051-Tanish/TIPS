using AdvancedLinqChallenge.Controller;
using AdvancedLinqChallenge.Service;
using AdvancedLinqChallenge.View;

namespace AdvancedLinqChallenge
{
    /// <summary>
    /// Contains the main execution logic.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Serves as the primary entry point of the application.
        /// </summary>
        public static void Main()
        {
            ProductView view = new ProductView();
            ProductManager manager = new ProductManager();
            TaskController controller = new TaskController(manager, view);
            controller.RunApplication();
        }
    }
}
