using InventoryManagement.Model;

namespace InventoryManagement
{
    /// <summary>
    /// Provides console-based UI methods for displaying menus, messages,
    /// and reading user input for various application modules.
    /// </summary>
    public class ProjectConsoleView
    {
        /// <summary>
        /// Shows menu to the user for selecting a operation.
        /// </summary>
        public void ShowMenu()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("[1]. To Add New product");
            Console.WriteLine("[2]. To View product");
            Console.WriteLine("[3]. To Edit product");
            Console.WriteLine("[4]. To Delete product");
            Console.WriteLine("[5]. To Search product");
            Console.WriteLine("[6]. To Exit");
            Console.WriteLine("===========================================");
        }

        /// <summary>
        /// Shows a product information in the inventory log.
        /// </summary>
        /// <param name="item">Item that needs to be displayed.</param>
        public void DisplayProduct(InventoryInfo item)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"ID : {item.Id}");
            Console.WriteLine($"Product Name : {item.Name}");
            Console.WriteLine($"Product Price : {item.Price}");
            Console.WriteLine($"Quantity : {item.Quantity}");
            Console.WriteLine("---------------------------------------");
        }

        /// <summary>
        /// Displays all the product details from the list.
        /// </summary>
        /// <param name="items">List of items to display.</param>
        public void DisplayAll(List<InventoryInfo> items)
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Inventory log is empty");
            }
            else
            {
                foreach (var item in items)
                {
                    this.DisplayProduct(item);
                }
            }
        }

        /// <summary>
        /// Display message in the console.
        /// </summary>
        /// <param name="message">Message that user wants to display.</param>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Reads user input from the console.
        /// </summary>
        /// <returns>The string of characters typed by the user, or null if no more lines are available.</returns>
        public string? ReadInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Writes a visual separator line to the console to improve console readability.
        /// </summary>
        public void EndLine()
        {
            Console.WriteLine("=====================");
        }
    }
}
