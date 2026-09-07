namespace InventoryManagement.Model
{
    /// <summary>
    /// Defines the properties of the inventory management.
    /// </summary>
    public class InventoryInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryInfo"/> class.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <param name="name">Name of the product.</param>
        /// <param name="price">Price of the product.</param>
        /// <param name="quantity">Quantity of the product.</param>
        public InventoryInfo(string? id, string? name, decimal price, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

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
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        /// <value>
        /// Quantity of the product from the inventory.
        /// </value>
        public int Quantity { get; set; }
    }
}
