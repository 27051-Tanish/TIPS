using System;
using System.Text.RegularExpressions;

namespace InventoryManagement.Helper
{
    /// <summary>
    /// Validates the user input.
    /// </summary>
    public static class InputValidator
    {
        private const decimal MinimumPriceValue = 0m;
        private const decimal MaximumPriceValue = 10000000m;
        private const int MinimumQuantity = 0;
        private const int MaximumQuantity = 1000;

        /// <summary>
        /// Validates that the name is not null/whitespace and matches the pattern.
        /// </summary>
        /// <param name="name">Name representing the item/product</param>
        /// <returns>bool indicating the correctness of the input</returns>
        public static bool ValidateName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            if (name.Length < 2 || name.Length >= 50)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the id of the item/product.
        /// </summary>
        /// <param name="id">Id of the item/product</param>
        /// <returns>True if the ID is valid, otherwise false</returns>
        public static bool ValidateId(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            string? pattern = @"^[A-Za-z]{2}\d{3}$";
            return Regex.IsMatch(id, pattern);
        }

        /// <summary>
        /// Validates the price of the item/product
        /// </summary>
        /// <param name="price">Price of the item/product</param>
        /// <returns>True if the price is valid, otherwise false</returns>
        public static bool ValidPrice(decimal price)
        {
            return price > MinimumPriceValue && price <= MaximumPriceValue;
        }

        /// <summary>
        /// Validates the quantity of the item/product.
        /// </summary>
        /// <param name="quantity">Quantity of the item/product</param>
        /// <returns>True if the quantity is valid, otherwise false</returns>
        public static bool ValidateQuantity(int quantity)
        {
            return quantity > MinimumQuantity && quantity <= MaximumQuantity;
        }
    }
}
