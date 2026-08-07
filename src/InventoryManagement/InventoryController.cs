using System.Text.RegularExpressions;
using InventoryManagement.Helper;
using InventoryManagement.Model;
using InventoryManagement.Model.Enum;
using InventoryManagement.Service;
using InventoryManagement.View;

namespace InventoryManagement
{
    /// <summary>
    /// Coordinates application flow by invoking the appropriate methods.
    /// </summary>
    public class InventoryController
    {
        private readonly InventoryConsole _consoleView;
        private readonly InventoryManager _projectManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryController"/> class.
        /// </summary>
        /// <param name="consoleView">The console view instance used for user interaction.</param>
        /// <param name="projectManager">The project manager instance used for managing inventory data.</param>
        public InventoryController(InventoryConsole consoleView, InventoryManager projectManager)
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

        /// <summary>
        /// Adds a new product details to the inventory record.
        /// </summary>
        private void AddProduct()
        {
            string? id;
            string? name;
            decimal price;
            int quantity;
            try
            {
                while (true)
                {
                    this._consoleView.ShowMessage("Enter product id (example: 'AB123'): ");
                    id = this._consoleView.ReadInput();

                    if (InputValidator.ValidateId(id))
                    {
                        break;
                    }

                    this._consoleView.ShowMessage("Invalid Id! enter 2 capital letters followed by 3 digits.");
                }

                while (true)
                {
                    this._consoleView.ShowMessage("Enter product name: ");
                    name = this._consoleView.ReadInput();

                    if (InputValidator.ValidateName(name))
                    {
                        break;
                    }

                    this._consoleView.ShowMessage("Invalid product name!\nName length should be between 2 to 50 characters.");
                }

                while (true)
                {
                    this._consoleView.ShowMessage("Enter product price: ");
                    price = this.GetPrice();

                    if (InputValidator.ValidPrice(price))
                    {
                        break;
                    }

                    this._consoleView.ShowMessage("Invalid price!\nPrice should be positive and within the limit.\n" +
                        $"Price Limit : {ConstantVariables.MaximumPriceValue} ");
                }

                while (true)
                {
                    this._consoleView.ShowMessage("Enter product quantity: ");
                    quantity = this.GetQuantity();

                    if (InputValidator.ValidateQuantity(quantity))
                    {
                        break;
                    }

                    this._consoleView.ShowMessage("Invalid input for quantity! Quantity should be positive and within the limit.\n" +
                        $"Quantity limit : {ConstantVariables.MaximumQuantity}");
                }

                InventoryInfo product = new (id, name, price, quantity);
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

        /// <summary>
        /// Displays the product details from the inventory record.
        /// </summary>
        private void ViewProducts()
        {
            this._consoleView.DisplayAll(this._projectManager.GetItems());
        }

        /// <summary>
        /// Update the existing product detail from the inventory record.
        /// </summary>
        private void EditProduct()
        {
            List<InventoryInfo> items = this._projectManager.GetItems();
            if (items.Count == 0)
            {
                this._consoleView.ShowMessage("The inventory log is empty");
                return;
            }

            string? input;
            InventoryInfo? product = null;
            while (true)
            {
                this._consoleView.ShowMessage("Enter product ID or Name: ");
                this._consoleView.ShowMessage("ID:(eg. AB123)");
                input = this._consoleView.ReadInput();

                if (!InputValidator.ValidateName(input) && !InputValidator.ValidateId(input))
                {
                    this._consoleView.ShowMessage("Input cannot be null or white space.");
                    continue;
                }

                InventoryInfo? matchedItem = items.Find(item =>
                string.Equals(item.Id, input, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(item.Name, input, StringComparison.OrdinalIgnoreCase));

                if (matchedItem == null)
                {
                    this._consoleView.ShowMessage($"No product found matching: '{input}'");
                    continue;
                }

                product = this._projectManager.GetProduct(matchedItem.Id);
                break;
            }

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
                                this._consoleView.ShowMessage("Name updated successfully.");
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
                                this._consoleView.ShowMessage("Price updated successfully.");
                                break;
                            }

                            this._consoleView.ShowMessage("Invalid price!\nPrice should be positive and within the limit.\n" +
                        $"Price Limit : {ConstantVariables.MaximumPriceValue} ");
                        }

                        break;
                    case EditMenu.Quantity:
                        while (true)
                        {
                            this._consoleView.ShowMessage("Enter new product quantity: ");
                            product.Quantity = this.GetQuantity();

                            if (InputValidator.ValidateQuantity(product.Quantity))
                            {
                                this._consoleView.ShowMessage("Quantity updated successfully.");
                                break;
                            }

                            this._consoleView.ShowMessage("Invalid input for quantity! Quantity should be positive and within the limit.\n" +
                            $"Quantity limit : {ConstantVariables.MaximumQuantity}");
                        }

                        break;
                    case EditMenu.Exit:
                        this._consoleView.ShowMessage("Exiting edit menu.");
                        break;
                    default:
                        this._consoleView.ShowMessage("Invalid choice\nPlease select from menu [1 to 4].");
                        break;
                }
            }
            while (editMenu != EditMenu.Exit);

            this._projectManager.EditItems(product);
        }

        /// <summary>
        /// Deletes a existing product information from the inventory record.
        /// </summary>
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

        /// <summary>
        /// Fetches a specific product details.
        /// </summary>
        private void SearchProduct()
        {
            List<InventoryInfo> items = this._projectManager.GetItems();
            if (items.Count == 0)
            {
                this._consoleView.ShowMessage("The inventory log is empty");
                return;
            }

            string? name;
            while (true)
            {
                this._consoleView.ShowMessage("Enter name of the product :");
                name = this._consoleView.ReadInput();

                if (!InputValidator.IsValidSearchKey(name))
                {
                    this._consoleView.ShowMessage("Name cannot be null or white space.");
                    continue;
                }

                if (!items.Exists(item => item.Name.Contains(name)))
                {
                    this._consoleView.ShowMessage($"No product found with the name: {name}");
                    continue;
                }

                break;
            }

            List<InventoryInfo> product = this._projectManager.SearchItem(name);
            this._consoleView.DisplayAll(product);
        }

        /// <summary>
        /// Attempts to parse a user input.
        /// </summary>
        /// <returns>Quantity of desired type if true, otherwise false.</returns>
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
                    this._consoleView.ShowMessage("Please enter valid input for quantity.\nQuantity should not contain characters, white space, or null.");
                }
            }
        }

        /// <summary>
        /// Attempts to parse a user input.
        /// </summary>
        /// <returns>Value of desired type if true, otherwise false.</returns>
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

        /// <summary>
        /// Attempts to parse a user input.
        /// </summary>
        /// <returns>Value of desired type if true, otherwise false.</returns>
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
                    this._consoleView.ShowMessage("Please enter valid input for price.\nPrice should not contain characters, white space, or null.");
                }
            }
        }
    }
}
