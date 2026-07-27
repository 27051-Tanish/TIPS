using System;

namespace InventoryManagement.Model
{
    /// <summary>
    /// Defines the properties of the inventory management.
    /// </summary>
    public class InventoryInfo
    {
        /// <summary>
        /// Gets or sets the Id of the product.
        /// </summary>
        /// <value>
        /// Id of the product from the inventory.
        /// </value>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// Name of the product from the inventory.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        /// <value>
        /// Price of the product from the inventory.
        /// </value>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        /// <value>
        /// Quantity of the product from the inventory.
        /// </value>
        public int Quantity { get; set; }
    }
}
