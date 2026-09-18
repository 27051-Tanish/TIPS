namespace AdvancedCSharpConcepts.AdvancedTasks.AdvancedDelegates
{
    /// <summary>
    /// Provide mechanisms for sorting the products by name, category, and price.
    /// </summary>
    public static class SortProducts
    {
        /// <summary>
        /// Defines a contract for comparing two product instances to determine their relative sort order.
        /// </summary>
        /// <param name="product1">The first product to compare.</param>
        /// <param name="product2">The second product to compare.</param>
        /// <returns>A negative value if product1 comes first, zero if equal, or a positive value if product2 comes first.</returns>
        public delegate int SortDelegate(Product product1, Product product2);

        /// <summary>
        /// Sorts the product by comparing two products by name.
        /// </summary>
        /// <param name="product1">The first product to compare.</param>
        /// <param name="product2">The second product to compare.</param>
        /// <returns>A negative value if product1 comes first, zero if equal, or a positive value if product2 comes first.</returns>
        public static int SortByName(Product product1, Product product2)
        {
            return product1.Name.CompareTo(product2.Name);
        }

        /// <summary>
        /// Sorts the product by comparing two products by category.
        /// </summary>
        /// <param name="product1">The first product to compare.</param>
        /// <param name="product2">The second product to compare.</param>
        /// <returns>A negative value if product1 comes first, zero if equal, or a positive value if product2 comes first.</returns>
        public static int SortByCategory(Product product1, Product product2)
        {
            return product1.Category.CompareTo(product2.Category);
        }

        /// <summary>
        /// Sorts the product by comparing two products by price.
        /// </summary>
        /// <param name="product1">The first product to compare.</param>
        /// <param name="product2">The second product to compare.</param>
        /// <returns>A negative value if product1 comes first, zero if equal, or a positive value if product2 comes first.</returns>
        public static int SortByPrice(Product product1, Product product2)
        {
            return product1.Price.CompareTo(product2.Price);
        }

        /// <summary>
        /// Sorts the product list based on the provided delegate.
        /// </summary>
        /// <param name="sort">The delegate type.</param>
        /// <param name="products">The product list.</param>
        /// <returns>The sorted list</returns>
        public static List<Product> SortAndDisplay(SortDelegate sort, List<Product> products)
        {
            products.Sort((product1, product2) => sort(product1, product2));
            return products;
        }
    }
}
