using AdvancedLinqChallenge.Models.Enum;
using AdvancedLinqChallenge.Service;
using AdvancedLinqChallenge.View;

namespace AdvancedLinqChallenge.Controller
{
    /// <summary>
    /// Handles the data flow between the service and view.
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
                choice = this._view.GetChoice();
                menu = (MainMenu)choice;
                switch (menu)
                {
                    case MainMenu.Task1:
                        this.PerformBasicLinq();
                        break;
                    case MainMenu.Task2:
                        break;
                    case MainMenu.Task3:
                        break;
                    case MainMenu.Task4:
                        break;
                    case MainMenu.Task5:
                        break;
                    case MainMenu.Exit:
                        break;
                    default:
                        this._view.ShowMessage("Please select from menu [1 to 6]");
                        break;
                }
            }
            while (menu != MainMenu.Exit);
        }

        private void PerformBasicLinq()
        {
            var (productList, averagePrice) = this._manager.Task1();
            this._view.DisplayProducts(productList);
            this._view.ShowMessage($"Average price : {averagePrice}");
        }
    }
}
