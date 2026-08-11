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
        private readonly IInventoryConsole _consoleView;
        private readonly InventoryManager _projectManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryController"/> class.
        /// </summary>
        /// <param name="consoleView">The console view instance used for user interaction.</param>
        /// <param name="projectManager">The project manager instance used for managing inventory data.</param>
        public InventoryController(IInventoryConsole consoleView, InventoryManager projectManager)
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
                id = this.GetProductId();
                name = this.GetProductName();
                price = this.GetProductPrice();
                quantity = this.GetProductQuantity();

                InventoryInfo product = new (id, name, price, quantity);
                this._projectManager.AddNewItems(product);
                this._consoleView.ShowMessage("Product added successfully");
            }
            catch (DuplicateWaitObjectException ex)
            {
                this._consoleView.ShowMessage(ex.Message);
            }
            catch (InvalidOperationException ex)
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
            List<InventoryInfo> items = this._projectManager.GetItems();
            if (items.Count == 0)
            {
                this._consoleView.ShowMessage("Inventory log is empty");
                return;
            }

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
            InventoryInfo? matchedItem = null;
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

                matchedItem = items.FirstOrDefault(item =>
                string.Equals(item.Id, input, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(item.Name, input, StringComparison.OrdinalIgnoreCase));

                if (matchedItem == null)
                {
                    this._consoleView.ShowMessage($"No product found matching: '{input}'");
                    continue;
                }

                break;
            }

            product = this._projectManager.GetProduct(matchedItem.Id);
            this._consoleView.DisplayItem(product);
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
                        product.Name = this.GetProductName();
                        this._consoleView.ShowMessage("Name updated successfully");
                        break;
                    case EditMenu.Price:
                        product.Price = this.GetProductPrice();
                        this._consoleView.ShowMessage("Price updated successfully");
                        break;
                    case EditMenu.Quantity:
                        product.Quantity = this.GetProductQuantity();
                        this._consoleView.ShowMessage("Quantity updated successfully");
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

            string? id;
            try
            {
                while (true)
                {
                    this._consoleView.ShowMessage("Enter product id to delete : ");

                    id = this.GetProductId();

                    if (!InputValidator.ValidateId(id))
                    {
                        this._consoleView.ShowMessage("Invalid Id! enter 2 letters followed by 3 digits.");
                        continue;
                    }

                    InventoryInfo? product = this._projectManager.GetProduct(id);
                    if (product == null)
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
            catch (InvalidOperationException ex)
            {
                this._consoleView.ShowMessage($"Error: {ex.Message}");
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

            string? input;
            InventoryInfo? matchedItem = null;
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

                matchedItem = items.Find(item =>
                item.Id.Contains(input, StringComparison.OrdinalIgnoreCase) ||
                item.Name.Contains(input, StringComparison.OrdinalIgnoreCase));

                if (matchedItem == null)
                {
                    this._consoleView.ShowMessage($"No product found matching: '{input}'");
                    continue;
                }

                break;
            }

            List<InventoryInfo>? products = this._projectManager.SearchItem(input);
            this._consoleView.DisplayAll(products);
        }

        /// <summary>
        /// Attempts to parse a user input.
        /// </summary>
        /// <returns>Quantity of desired type if true, otherwise false.</returns>
        private int GetQuantity()
        {
            int attempts = 0;
            while (attempts < ConstantVariables.MaxAttempts)
            {
                if (int.TryParse(this._consoleView.ReadInput(), out int quantity))
                {
                    return quantity;
                }
                else
                {
                    attempts++;
                    this._consoleView.ShowMessage("Please enter valid input for quantity.\nQuantity should not contain characters, white space, or null.\n" +
                        $"Attempts remaining : {ConstantVariables.MaxAttempts - attempts}");
                }
            }

            throw new InvalidOperationException("Maximum attempts reached.");
        }

        /// <summary>
        /// Attempts to parse a user input.
        /// </summary>
        /// <returns>Value of desired type if true, otherwise false.</returns>
        private int GetChoice()
        {
            while (true)
            {
                if (int.TryParse(this._consoleView.ReadInput(), out int choiceValue) && choiceValue > 0 && choiceValue <= 6)
                {
                    return choiceValue;
                }

                this._consoleView.ShowMessage($"Please enter valid choice from the menu [1 to 6]");
            }
        }

        /// <summary>
        /// Attempts to parse a user input.
        /// </summary>
        /// <returns>Value of desired type if true, otherwise false.</returns>
        private decimal GetPrice()
        {
            int attempts = 0;
            while (attempts < ConstantVariables.MaxAttempts)
            {
                if (decimal.TryParse(this._consoleView.ReadInput(), out decimal priceValue))
                {
                    return priceValue;
                }
                else
                {
                    attempts++;
                    this._consoleView.ShowMessage("Please enter valid input for price.\nPrice should not contain characters, white space, or null.\n" +
                        $"Attempts remaining :{ConstantVariables.MaxAttempts - attempts}");
                }
            }

            throw new InvalidOperationException("Maximum attempts reached.");
        }

        private string? GetProductId()
        {
            int attempts = 0;
            string? id;
            while (attempts < ConstantVariables.MaxAttempts)
            {
                this._consoleView.ShowMessage("Enter product id (example: 'AB123'): ");
                id = this._consoleView.ReadInput();

                if (InputValidator.ValidateId(id))
                {
                    return id;
                }
                else
                {
                    attempts++;
                    this._consoleView.ShowMessage("Invalid Id! enter 2 capital letters followed by 3 digits.\n" +
                       $"Attempts remaining :{ConstantVariables.MaxAttempts - attempts}");
                }
            }

            throw new InvalidOperationException("Maximum attempts reached.");
        }

        private string? GetProductName()
        {
            int attempts = 0;
            string? name;
            while (attempts < ConstantVariables.MaxAttempts)
            {
                this._consoleView.ShowMessage("Enter product name: ");
                name = this._consoleView.ReadInput();

                if (InputValidator.ValidateName(name))
                {
                    return name;
                }
                else
                {
                    attempts++;
                    this._consoleView.ShowMessage("Invalid product name!\nName length should be between 2 to 50 characters.\n" +
                        $"Attempts remaining :{ConstantVariables.MaxAttempts - attempts}");
                }
            }

            throw new InvalidOperationException("Maximum attempts reached.");
        }

        private decimal GetProductPrice()
        {
            int attempts = 0;
            decimal price;
            while (attempts < ConstantVariables.MaxAttempts)
            {
                this._consoleView.ShowMessage("Enter product price: ");
                price = this.GetPrice();

                if (InputValidator.ValidatePrice(price))
                {
                    return price;
                }
                else
                {
                    attempts++;
                    this._consoleView.ShowMessage("Invalid price!\nPrice should be positive and within the limit.\n" +
                        $"Price Limit : {ConstantVariables.MaximumPriceValue}" +
                        $"Attempts remaining :{ConstantVariables.MaxAttempts - attempts}");
                }
            }

            throw new InvalidOperationException("Maximum attempts reached.");
        }

        private int GetProductQuantity()
        {
            int attempts = 0;
            int quantity;
            while (attempts < ConstantVariables.MaxAttempts)
            {
                this._consoleView.ShowMessage("Enter product quantity: ");
                quantity = this.GetQuantity();

                if (InputValidator.ValidateQuantity(quantity))
                {
                    return quantity;
                }
                else
                {
                    attempts++;
                    this._consoleView.ShowMessage("Invalid input for quantity! Quantity should be positive and within the limit.\n" +
                        $"Quantity limit : {ConstantVariables.MaximumQuantity}\n" +
                        $"Attempts remaining :{ConstantVariables.MaxAttempts - attempts}");
                }
            }

            throw new InvalidOperationException("Maximum attempts reached.");
        }
    }
}
