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
        /// <inheritdoc/>
        public void ShowMenu()
        {
            this.EndLine();
            this.ShowMessage("[1]. Add New product");
            this.ShowMessage("[2]. View product");
            this.ShowMessage("[3]. Edit product");
            this.ShowMessage("[4]. Delete product");
            this.ShowMessage("[5]. Search product");
            this.ShowMessage("[6]. Exit");
            this.EndLine();
        }

        /// <inheritdoc/>
        public void DisplayAll(List<InventoryInfo>? items)
        {
            var table = new ConsoleTable("ID", "Product Name", "Price", "Quantity");

            foreach (var item in items)
            {
                table.AddRow(item.Id, item.Name, item.Price, item.Quantity);
            }

            table.Write();
        }

        /// <inheritdoc/>
        public void DisplayItem(InventoryInfo item)
        {
            this.DisplayAll(new List<InventoryInfo> { item });
        }

        /// <inheritdoc/>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <inheritdoc/>
        public string? ReadInput()
        {
            return Console.ReadLine();
        }

        /// <inheritdoc/>
        public void EndLine()
        {
            this.ShowMessage(new string('=', 25));
        }
    }
}
