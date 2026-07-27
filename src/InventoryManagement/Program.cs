using InventoryManagement;
using InventoryManagement.Service;

namespace Assignments
{
    /// <summary>
    /// Serves as the entry point to inventory management.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Calling the controller with view and service.
        /// </summary>
        public static void Main()
        {
            ProjectConsoleView consoleView = new ProjectConsoleView();
            InventoryManager inventoryManager = new InventoryManager();

            ProjectController controller = new ProjectController(consoleView, inventoryManager);
            controller.Start();
        }
    }
}