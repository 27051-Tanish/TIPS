using System.Text.RegularExpressions;
using InventoryManagement.Helper;

namespace InventoryManagement.Helper
{
    /// <summary>
    /// Validates the user input.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Validates that the name is not null/whitespace and matches the pattern.
        /// </summary>
        /// <param name="name">Name of the item/product.</param>
        /// <returns>True if the name is valid, otherwise false.</returns>
        public static bool ValidateName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            if (name.All(n => char.IsDigit(n)))
            {
                return false;
            }

            if (name.Length < ConstantVariables.MinimumNameLength || name.Length >= ConstantVariables.MaximumNameLength)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the id of the item/product.
        /// </summary>
        /// <param name="id">Id of the item/product.</param>
        /// <returns>True if the ID is valid, otherwise false.</returns>
        public static bool ValidateId(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            string? pattern = @"^[A-Z]{2}\d{3}$";
            return Regex.IsMatch(id, pattern);
        }

        /// <summary>
        /// Validates the price of the item/product
        /// </summary>
        /// <param name="price">Price of the item/product.</param>
        /// <returns>True if the price is valid, otherwise false.</returns>
        public static bool ValidPrice(decimal price)
        {
            return price > ConstantVariables.MinimumPriceValue && price <= ConstantVariables.MaximumPriceValue;
        }

        /// <summary>
        /// Validates the quantity of the item/product.
        /// </summary>
        /// <param name="quantity">Quantity of the item/product.</param>
        /// <returns>True if the quantity is valid, otherwise false.</returns>
        public static bool ValidateQuantity(int quantity)
        {
            return quantity >= ConstantVariables.MinimumQuantity && quantity <= ConstantVariables.MaximumQuantity;
        }

        /// <summary>
        /// Validates the name entered by the user.
        /// </summary>
        /// <param name="searchKey">The search key from the user.</param>
        /// <returns>True if the key is valid, otherwise false.</returns>
        public static bool IsValidSearchKey(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return false;
            }

            return true;
        }
    }
}
