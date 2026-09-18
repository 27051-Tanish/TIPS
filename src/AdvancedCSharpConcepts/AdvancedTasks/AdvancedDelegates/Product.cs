namespace AdvancedCSharpConcepts.AdvancedTasks.AdvancedDelegates
{
    /// <summary>
    /// Provides the properties of the products.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        /// <value>
        /// The category of the product.
        /// </value>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        /// <value>
        /// The price of the product.
        /// </value>
        public decimal Price { get; set; }
    }
}
