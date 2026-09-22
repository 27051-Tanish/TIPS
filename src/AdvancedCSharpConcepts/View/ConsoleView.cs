using AdvancedCSharpConcepts.AdvancedTasks;
using AdvancedCSharpConcepts.AdvancedTasks.AdvancedDelegates;

namespace AdvancedCSharpConcepts.View
{
    /// <summary>
    /// Provides console-based UI methods for displaying messages,
    /// and reading user input for various application modules.
    /// </summary>
    public class ConsoleView
    {
        /// <summary>
        /// Writes the content to the UI.
        /// </summary>
        /// <param name="message">The message to be written.</param>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays a prompt and reads console input, repeatedly showing an error message until a valid integer is entered.
        /// </summary>
        /// <param name="prompt">The prompt to be displayed.</param>
        /// <returns>A valid integer number.</returns>
        public int GetIntInput(string prompt)
        {
            this.ShowMessage(prompt);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    return number;
                }

                this.ShowMessage("Please enter valid integer number.");
            }
        }

        /// <summary>
        /// Displays the title of the task in the UI.
        /// </summary>
        /// <param name="title">The title of the task.</param>
        public void ShowTitle(string title)
        {
            this.ShowMessage(new string('=', 25));
            this.ShowMessage($"       {title}");
            this.ShowMessage(new string('=', 25));
        }

        /// <summary>
        /// Clears the console after executing a method.
        /// </summary>
        public void ConsoleClear()
        {
            this.ShowMessage("Press any key to close...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Displays the products in table format.
        /// </summary>
        /// <param name="products">The products list to be displayed.</param>
        public void DisplaySortedProducts(List<Product> products)
        {
            if (products.Count == 0)
            {
                this.ShowMessage("The list is empty...");
                return;
            }

            int serialNumber = 1;
            this.ShowMessage(new string('-', 65));
            this.ShowMessage($"{"S.no",-5} | {"Name",-15} | {"Category",-20} | {"Price",-15} |");
            this.ShowMessage(new string('-', 65));

            foreach (Product product in products)
            {
                this.ShowMessage($"{serialNumber,-5} | {product.Name,-15} | {product.Category,-20} | {product.Price,-15} |");
                this.ShowMessage(new string('-', 65));
                serialNumber++;
            }
        }

        /// <summary>
        /// Draws a visual separator line in the UI.
        /// </summary>
        public void DrawSeparatorLine()
        {
            this.ShowMessage(new string('=', 50));
        }

        /// <summary>
        /// Deconstructing the record into individual variables and writing it to the UI.
        /// </summary>
        /// <param name="book">The record that needs to be displayed.</param>
        public void DisplayBook(Book book)
        {
            var (title, author, isbn) = book;

            this.ShowMessage($"Title: {title}, Author: {author}, ISBN: {isbn}");
        }
    }
}
