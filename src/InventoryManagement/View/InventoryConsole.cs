using ConsoleTables;
using InventoryManagement.Model;

namespace InventoryManagement.View
{
    /// <summary>
    /// Provides console-based UI methods for displaying menus, messages,
    /// and reading user input for various application modules.
    /// </summary>
    public class InventoryConsole : IInventoryConsole
    {
        /// <summary>
        /// Shows menu to the user for selecting a operation.
        /// </summary>
        public void ShowMenu()
        {
            this.EndLine();
            this.ShowMessage("[1]. To Add New product");
            this.ShowMessage("[2]. To View product");
            this.ShowMessage("[3]. To Edit product");
            this.ShowMessage("[4]. To Delete product");
            this.ShowMessage("[5]. To Search product");
            this.ShowMessage("[6]. To Exit");
            this.EndLine();
        }

        /// <summary>
        /// Shows a product information in the inventory log.
        /// </summary>
        /// <param name="items">Items that needs to be displayed.</param>
        public void DisplayAll(List<InventoryInfo> items)
        {
            if (items.Count == 0)
            {
                this.ShowMessage("Inventory log is empty");
                return;
            }

            var table = new ConsoleTable("ID", "Product Name", "Price", "Quantity");

            foreach (var item in items)
            {
                table.AddRow(item.Id, item.Name, item.Price, item.Quantity);
            }

            table.Write();
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
            this.ShowMessage(new string('=', 25));
        }
    }
}
