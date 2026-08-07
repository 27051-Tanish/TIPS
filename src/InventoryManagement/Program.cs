using InventoryManagement.Service;
using InventoryManagement.View;

namespace InventoryManagement
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
            InventoryConsole consoleView = new ();
            InventoryManager inventoryManager = new ();
            try
            {
                InventoryController controller = new (consoleView, inventoryManager);
                controller.RunInventoryManagement();
            }
            catch (Exception ex)
            {
                consoleView.ShowMessage($"Exception occurred :{ex.Message}");
            }
        }
    }
}