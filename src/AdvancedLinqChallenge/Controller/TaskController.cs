using System.Diagnostics;
using System.Text.RegularExpressions;
using AdvancedLinqChallenge.DataInitializer;
using AdvancedLinqChallenge.DataInitializer.ConstantData;
using AdvancedLinqChallenge.LinqExtensions;
using AdvancedLinqChallenge.Models;
using AdvancedLinqChallenge.Models.Enum;
using AdvancedLinqChallenge.Service;
using AdvancedLinqChallenge.View;

namespace AdvancedLinqChallenge.Controller
{
    /// <summary>
    /// Handles the logic for performing different linq operations.
    /// </summary>
    public class TaskController
    {
        private readonly ProductManager _manager;
        private readonly ProductView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="manager">The instance of the service.</param>
        /// <param name="view">The instance of the view.</param>
        public TaskController(ProductManager manager, ProductView view)
        {
            this._manager = manager;
            this._view = view;
        }

        /// <summary>
        /// Starts the execution of the LINQ challenges application.
        /// </summary>
        public void RunApplication()
        {
            this._view.ShowMessage("---- Welcome to LINQ query challenge application ----");
            int choice;
            MainMenu menu;
            do
            {
                this._view.ShowMenu();
                this._view.ShowMessage("Enter your choice :");
                choice = this._view.GetChoice();
                menu = (MainMenu)choice;
                switch (menu)
                {
                    case MainMenu.Task1:
                        this.PerformBasicLinq();
                        break;
                    case MainMenu.Task2:
                        this.PerformTask2();
                        break;
                    case MainMenu.Task3:
                        this.PerformTask3();
                        break;
                    case MainMenu.Task4:
                        this.PerformTask4();
                        break;
                    case MainMenu.Task5:
                        this.PerformTask5();
                        break;
                    case MainMenu.Exit:
                        break;
                    default:
                        this._view.ShowMessage("Please select from menu [1 to 6]");
                        break;
                }

                this._view.ConsoleClear();
            }
            while (menu != MainMenu.Exit);
        }

        private void PerformBasicLinq()
        {
            this._view.ShowMessage("-- Filter Electronics products above $500\n" +
            "-- Sort filtered products by descending price\n" +
            "-- Calculate the average price\n");
            var (productList, averagePrice) = this._manager.Task1();
            this._view.DisplayProducts(productList);
            this._view.ShowMessage($"Average price : {averagePrice}");
        }

        private void PerformTask2()
        {
            this._view.ShowMessage("-- Group products by category and count them\n" +
            "-- Find the most expensive product in each category\n" +
            "-- Join products with their suppliers\n");
            var result = this._manager.Task2();
            foreach (var item in result)
            {
                this._view.ShowMessage($"Category : {item.Category}\n" +
                    $"Count : {item.Count}\n" +
                    $"Expensive Product's Name : {item.ProductName}\n" +
                    $"Expensive product's Price : {item.ExpensiveProductPrice}\n" +
                    $"Supplier Name : {item.SupplierName}");
                this._view.ShowMessage(new string('=', 45));
            }
        }

        private void PerformTask3()
        {
            this._view.ShowMessage($"Second highest from the array : [{string.Join(", ", ConstantVariable.Array)}] is {this._manager.FindSecondHighest()}");
            this._view.ShowMessage("Enter the target number :");
            int target = this._view.GetChoice();
            var result = this._manager.FindUniquePairs(target);
            foreach (var item in result)
            {
                this._view.ShowMessage($"Pairs : {item.Item1}, {item.Item2}");
            }
        }

        private void PerformTask4()
        {
            Stopwatch watch = Stopwatch.StartNew();
            List<ProductInfo> books = this._manager.GetBooksInUnoptimized();
            watch.Stop();
            this._view.ShowMessage($"Time taken to execute unoptimized version of link query : {watch.Elapsed}");
            this._view.ShowMessage("--- Products with the category books [UNOPTIMIZED] ---");
            this._view.DisplayProductTable(books);

            watch.Restart();
            List<ProductInfo> booksOptimized = this._manager.GetBooksInOptimized();
            watch.Stop();
            this._view.ShowMessage($"Time taken to execute optimized version of link query : {watch.Elapsed}");
            this._view.ShowMessage("--- Products with the category books [OPTIMIZED] ---");
            this._view.DisplayProductTable(booksOptimized);
        }

        private void PerformTask5()
        {
            this._view.ShowMessage("Displays the products that is phone and sorted price.");
            var products = this._manager.GetPhoneProduct();
            this._view.DisplayProductTable(products);

            this._view.ShowMessage("\nDisplays the product that starts with 'Elec' and price that is greater than 500.");
            var electronics = this._manager.GetProductThatStartsWithElec();
            this._view.DisplayProductTable(electronics);
        }
    }
}
