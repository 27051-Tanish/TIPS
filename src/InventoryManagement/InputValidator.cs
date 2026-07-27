using System;

namespace InventoryManagement
{
    /// <summary>
    /// Validates the user input.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Validates the name of the item/product.
        /// </summary>
        /// <param name="name">Name representing the item/product</param>
        /// <returns>bool indicating the correctness of the input</returns>
        public static bool ValidateName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            return true;
        }
    }
}
