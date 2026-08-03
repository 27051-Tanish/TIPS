using InventoryManagement.Helper;
using InventoryManagement.Model;
using InventoryManagement.Model.Enum;
using InventoryManagement.Service;

namespace InventoryManagement
{
    /// <summary>
    /// Coordinates application flow by invoking the appropriate methods.
    /// </summary>
    public class ProjectController
    {
        private readonly ProjectConsoleView _consoleView;
        private readonly InventoryManager _projectManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectController"/> class.
        /// </summary>
        /// <param name="consoleView">The console view instance used for user interaction.</param>
        /// <param name="projectManager">The project manager instance used for managing inventory data.</param>
        public ProjectController(ProjectConsoleView consoleView, InventoryManager projectManager)
        {
            this._consoleView = consoleView;
            this._projectManager = projectManager;
        }

        /// <summary>
        /// Starts the execution of the inventory management application.
        /// </summary>
        public void RunInventoryManagement()
        {
            this._consoleView.ShowMessage("Welcome to console-based Inventory management");
            int choiceValue;
            MenuEnum menu;
            do
            {
                this._consoleView.ShowMenu();
                this._consoleView.ShowMessage("Please select the option to perform :");
                choiceValue = this.GetChoice();
                menu = (MenuEnum)choiceValue;
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
                        this._consoleView.ShowMessage("Please enter valid choice from the menu [1 to 6]");
                        break;
                }
            }
            while (menu != MenuEnum.Exit);
        }

        private void AddProduct()
        {
            InventoryInfo product = new InventoryInfo();
            try
            {
                while (true)
                {
                    this._consoleView.ShowMessage("Enter product id (example: 'AB123'): ");
                    product.Id = this._consoleView.ReadInput();

                    if (InputValidator.ValidateId(product.Id))
                    {
                        break;
                    }

                    this._consoleView.ShowMessage("Invalid Id! enter 2 capital letters followed by 3 digits.");
                }

                while (true)
                {
                    this._consoleView.ShowMessage("Enter product name: ");
                    product.Name = this._consoleView.ReadInput();

                    if (InputValidator.ValidateName(product.Name))
                    {
                        break;
                    }

                    this._consoleView.ShowMessage("Invalid product name! Name cannot be empty and name length should be between 2 to 50 characters.");
                }

                while (true)
                {
                    this._consoleView.ShowMessage("Enter product price: ");
                    product.Price = this.GetPrice();

                    if (InputValidator.ValidPrice(product.Price))
                    {
                        break;
                    }

                    this._consoleView.ShowMessage("Invalid price! Price cannot be empty or negative.\nPrice should be positive and within the limit.\n" +
                        $"Price Limit : {ConstantVariables.MaximumPriceValue} ");
                }

                while (true)
                {
                    this._consoleView.ShowMessage("Enter product quantity: ");
                    product.Quantity = this.GetQuantity();

                    if (InputValidator.ValidateQuantity(product.Quantity))
                    {
                        break;
                    }

                    this._consoleView.ShowMessage("Invalid input for quantity! Quantity should be positive and within the limit." +
                        $"Quantity limit : {ConstantVariables.MaximumQuantity}");
                }

                this._projectManager.AddNewItems(product);
                this._consoleView.ShowMessage("Product added successfully");
            }
            catch (DuplicateWaitObjectException ex)
            {
                this._consoleView.ShowMessage(ex.Message);
            }
            catch (Exception ex)
            {
                this._consoleView.ShowMessage($"Error: {ex.Message}");
            }
        }

        private void ViewProducts()
        {
            this._consoleView.DisplayAll(this._projectManager.GetItems());
        }

        private void EditProduct()
        {
            List<InventoryInfo> items = this._projectManager.GetItems();
            if (items.Count == 0)
            {
                this._consoleView.ShowMessage("The inventory log is empty");
                return;
            }

            this._consoleView.ShowMessage("Enter id of the product :");
            string? id;
            while (true)
            {
                this._consoleView.ShowMessage("Enter product id (example: 'AB123'): ");
                id = this._consoleView.ReadInput();

                if (!InputValidator.ValidateId(id))
                {
                    this._consoleView.ShowMessage("Invalid Id! Enter 2 letters followed by 3 digits.");
                    continue;
                }

                bool exists = items.Exists(item =>
                    string.Equals(item.Id, id, StringComparison.OrdinalIgnoreCase));

                if (!exists)
                {
                    this._consoleView.ShowMessage($"No product found with ID: {id}");
                    continue;
                }

                break;
            }

            InventoryInfo? product = this._projectManager.GetProduct(id);
            int choice;
            EditMenu editMenu;
            do
            {
                this._consoleView.ShowMessage("Choose fields to edit :");
                this._consoleView.ShowMessage("[1]. Name\n[2]. Price\n[3]. Quantity\n[4]. Exit");
                choice = this.GetChoice();
                editMenu = (EditMenu)choice;
                switch (editMenu)
                {
                    case EditMenu.Name:
                        while (true)
                        {
                            this._consoleView.ShowMessage("Enter product name: ");
                            product.Name = this._consoleView.ReadInput();

                            if (InputValidator.ValidateName(product.Name))
                            {
                                break;
                            }

                            this._consoleView.ShowMessage("Invalid product name! Name cannot be empty and name length should be between 2 to 50 characters.");
                        }

                        break;
                    case EditMenu.Price:
                        while (true)
                        {
                            this._consoleView.ShowMessage("Enter new product price: ");
                            product.Price = this.GetPrice();

                            if (InputValidator.ValidPrice(product.Price))
                            {
                                break;
                            }

                            this._consoleView.ShowMessage("Invalid price! Price cannot be empty or negative.");
                        }

                        break;
                    case EditMenu.Quantity:
                        while (true)
                        {
                            this._consoleView.ShowMessage("Enter new product quantity: ");
                            product.Quantity = this.GetQuantity();

                            if (InputValidator.ValidateQuantity(product.Quantity))
                            {
                                break;
                            }

                            this._consoleView.ShowMessage("Invalid input for quantity! Quantity cannot be empty, negative or greater than 1000.");
                        }

                        break;
                    case EditMenu.Exit:
                        break;
                    default:
                        this._consoleView.ShowMessage("Invalid choice\nPlease select from menu [1 to 4].");
                        break;
                }
            }
            while (editMenu != EditMenu.Exit);

            this._projectManager.EditItems(product);
            this._consoleView.ShowMessage("Updated successfully");
        }

        private void DeleteProduct()
        {
            List<InventoryInfo> items = this._projectManager.GetItems();
            if (items.Count == 0)
            {
                this._consoleView.ShowMessage("The inventory log is empty");
                return;
            }

            this._consoleView.ShowMessage("Enter id to delete :");
            string? id;
            while (true)
            {
                this._consoleView.ShowMessage("Enter product id to delete : ");
                id = this._consoleView.ReadInput();

                if (!InputValidator.ValidateId(id))
                {
                    this._consoleView.ShowMessage("Invalid Id! enter 2 letters followed by 3 digits.");
                    continue;
                }

                bool isExists = items.Exists(item =>
                    string.Equals(item.Id, id, StringComparison.OrdinalIgnoreCase));

                if (!isExists)
                {
                    this._consoleView.ShowMessage($"No product found with ID: {id}");
                    continue;
                }

                break;
            }

            bool isItemRemoved = this._projectManager.DeleteItems(id);
            if (isItemRemoved)
            {
                this._consoleView.ShowMessage("Deleted successfully");
            }
            else
            {
                this._consoleView.ShowMessage("Failed to delete product details.");
            }
        }

        private void SearchProduct()
        {
            List<InventoryInfo> items = this._projectManager.GetItems();
            if (items.Count == 0)
            {
                this._consoleView.ShowMessage("The inventory log is empty");
                return;
            }

            this._consoleView.ShowMessage("Enter name of the product :");
            string? name = this._consoleView.ReadInput();
            while (true)
            {
                this._consoleView.ShowMessage("Enter name of the product :");
                name = this._consoleView.ReadInput();

                bool isExists = items.Exists(item =>
                    string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase));

                if (!isExists)
                {
                    this._consoleView.ShowMessage($"No product found with the name: {name}");
                    continue;
                }

                break;
            }

            List<InventoryInfo> product = this._projectManager.SearchItem(name);
            this._consoleView.DisplayAll(product);
        }

        private int GetQuantity()
        {
            while (true)
            {
                if (int.TryParse(this._consoleView.ReadInput(), out int quantity))
                {
                    return quantity;
                }
                else
                {
                    this._consoleView.ShowMessage("Please enter valid input for quantity.\n" +
                        "Quantity should be positive and within the limit." +
                        $"Quantity limit : {ConstantVariables.MaximumQuantity}");
                }
            }
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
                    this._consoleView.ShowMessage("Please enter valid choice from the menu [1 to 6]");
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
                    this._consoleView.ShowMessage("Invalid input for price.\nPrice should be positive and within the limit.\n" +
                        $"Price Limit : {ConstantVariables.MaximumPriceValue} ");
                }
            }
        }
    }
}
