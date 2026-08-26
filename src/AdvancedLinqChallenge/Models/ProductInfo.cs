namespace AdvancedLinqChallenge.Models
{
    /// <summary>
    /// Defines the properties for the product class.
    /// </summary>
    public class ProductInfo
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        /// <value>
        /// The product name.
        /// </value>
        public string? ProductName { get; set; }

        /// <summary>
        /// Gets or sets the unique product id.
        /// </summary>
        /// <value>
        /// The unique product id.
        /// </value>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        /// <value>
        /// The product price.
        /// </value>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        /// <value>
        /// The category of the product.
        /// </value>
        public string? Category { get; set; }
    }
}
