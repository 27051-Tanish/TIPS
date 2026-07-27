using System;
using InventoryManagement.Model;
using InventoryManagement.Service;

namespace InventoryManagement
{
    /// <summary>
    /// Handles operations between different tasks.
    /// </summary>
    internal class ProjectController
    {
        private readonly ProjectConsoleView _consoleView;
        private readonly InventoryManager _projectManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectController"/> class.
        /// </summary>
        /// <param name="consoleView">object of the console view class</param>
        /// <param name="projectManager">object of the inventory manager class</param>
        public ProjectController(ProjectConsoleView consoleView, InventoryManager projectManager)
        {
            this._consoleView = consoleView;
            this._projectManager = projectManager;
        }

        /// <summary>
        /// Starts the execution of the program.
        /// </summary>
        public void Start()
        {
            this._consoleView.ShowMessage("Welcome to console-based Inventory management");
            int choiceValue;
            do
            {
                this._consoleView.ShowMenu();
                this._consoleView.ShowMessage("Enter your choice :");
                choiceValue = this.GetChoice();
                MenuEnum menu = (MenuEnum)choiceValue;
                switch (menu)
                {
                    case MenuEnum.Insert:
                        this.AddProduct();
                        break;
                    case MenuEnum.View:
                        this.ViewProducts();
                        break;
                    case MenuEnum.Edit:
                        this.EditProduct();
                        break;
                    case MenuEnum.Remove:
                        this.DeleteProduct();
                        break;
                    case MenuEnum.Search:
                        this.SearchProduct();
                        break;
                    case MenuEnum.Exit:
                        break;
                    default:
                        this._consoleView.ShowMessage("Invalid choice");
                        break;
                }
            }
            while (choiceValue != 6);
        }

        private void AddProduct()
        {
            InventoryInfo product = new InventoryInfo();
            this._consoleView.ShowMessage("Enter product id: ");
            product.Id = this._consoleView.ReadInput();
            this._consoleView.ShowMessage("Enter product name: ");
            product.Name = this._consoleView.ReadInput();
            this._consoleView.ShowMessage("Enter product price: ");
            product.Price = this.GetPrice();
            this._consoleView.ShowMessage("Enter product quantity: ");
            product.Quantity = this.GetChoice();
            this._projectManager.AddNewItems(product);
        }

        private void ViewProducts()
        {
            this._consoleView.DisplayAll(this._projectManager.GetItems());
        }

        private void EditProduct()
        {
            this._consoleView.ShowMessage("Enter id of the product :");
            string? id = this._consoleView.ReadInput();
            InventoryInfo? product = this._projectManager.GetProduct(id);
            int choice;
            do
            {
                this._consoleView.ShowMessage("Choose fields to edit :");
                this._consoleView.ShowMessage("[1]. Name\n[2]. Price\n[3]. Quantity\n[4]. Exit");
                choice = this.GetChoice();

                switch (choice)
                {
                    case 1:
                        this._consoleView.ShowMessage("Enter new name :");
                        product.Name = this._consoleView.ReadInput();
                        break;
                    case 2:
                        this._consoleView.ShowMessage("Enter new price :");
                        product.Price = this.GetPrice();
                        break;
                    case 3:
                        this._consoleView.ShowMessage("Enter new quantity :");
                        product.Quantity = this.GetChoice();
                        break;
                    case 4:
                        break;
                    default:
                        this._consoleView.ShowMessage("Invalid choice");
                        break;
                }
            }
            while (choice != 4);

            this._projectManager.EditItems(product);
            this._consoleView.ShowMessage("Updated successfully");
        }

        private void DeleteProduct()
        {
            this._consoleView.ShowMessage("Enter id to delete :");
            string? id = this._consoleView.ReadInput();
            this._projectManager.DeleteItems(id);
            this._consoleView.ShowMessage("Deleted successfully");
        }

        private void SearchProduct()
        {
            this._consoleView.ShowMessage("Enter name of the product :");
            string? name = this._consoleView.ReadInput();
            List<InventoryInfo> product = this._projectManager.SearchItem(name);
            this._consoleView.DisplayAll(product);
        }

        private int GetChoice()
        {
            while (true)
            {
                if (int.TryParse(this._consoleView.ReadInput(), out int choiceValue))
                {
                    return choiceValue;
                }
                else
                {
                    this._consoleView.ShowMessage("Please enter valid choice");
                }
            }
        }

        private decimal GetPrice()
        {
            while (true)
            {
                if (decimal.TryParse(this._consoleView.ReadInput(), out decimal priceValue))
                {
                    return priceValue;
                }
                else
                {
                    this._consoleView.ShowMessage("Invalid input for price.");
                }
            }
        }
    }
}
