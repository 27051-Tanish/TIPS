using System.ComponentModel;
using AdvancedLinqChallenge.DataInitializer;
using AdvancedLinqChallenge.Models;
using ConsoleTables;

namespace AdvancedLinqChallenge.View
{
    /// <summary>
    /// Provides console-based UI methods for displaying menus, messages,
    /// and reading user input for various application modules.
    /// </summary>
    public class ProductView
    {
        /// <summary>
        /// Displays the details of products in table format.
        /// </summary>
        /// <param name="products">Products in the list.</param>
        public void DisplayProducts(List<ProductInfo> products)
        {
            ConsoleTable table = new ConsoleTable("Product name", "Price");
            foreach (ProductInfo product in products)
            {
                table.AddRow(product.ProductName, product.Price);
            }

            table.Write();
        }

        /// <summary>
        /// Writes a message to the UI.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Reads an user input from UI.
        /// </summary>
        /// <returns>The value read from the UI.</returns>
        public string? ReadInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Displays the menu in the UI.
        /// </summary>
        public void ShowMenu()
        {
            this.ShowMessage("[1]. Basic LINQ\n[2]. Complex LINQ\n[3]. LINQ to Objects\n[4]. Performance Considerations with LINQ\n" +
                "[5]. Query builder\n[6]. Exit");
        }

        /// <summary>
        /// Gets the numerical choice from the user.
        /// </summary>
        /// <returns>The numerical value as choice.</returns>
        public int GetChoice()
        {
            while (true)
            {
                if (int.TryParse(this.ReadInput(), out int value))
                {
                    return value;
                }

                this.ShowMessage("Please enter valid choice :");
            }
        }
    }
}
