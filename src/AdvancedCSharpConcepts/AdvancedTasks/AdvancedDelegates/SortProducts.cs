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
            return string.Compare(product1.Name, product2.Name, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Sorts the product by comparing two products by category.
        /// </summary>
        /// <param name="product1">The first product to compare.</param>
        /// <param name="product2">The second product to compare.</param>
        /// <returns>A negative value if product1 comes first, zero if equal, or a positive value if product2 comes first.</returns>
        public static int SortByCategory(Product product1, Product product2)
        {
            return string.Compare(product1.Category, product2.Category, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Sorts the product by comparing two products by price.
        /// </summary>
        /// <param name="product1">The first product to compare.</param>
        /// <param name="product2">The second product to compare.</param>
        /// <returns>A negative value if product1 comes first, zero if equal, or a positive value if product2 comes first.</returns>
        public static int SortByPrice(Product product1, Product product2)
        {
            // Numbers do not require language localization rules
            return product1.Price.CompareTo(product2.Price);
        }

        /// <summary>
        /// Sorts the product list based on the provided delegate.
        /// </summary>
        /// <param name="sort">The delegate type.</param>
        /// <param name="products">The product list.</param>
        /// <returns>The sorted list</returns>
        public static List<Product> GetSortedProducts(SortDelegate sort, List<Product> products)
        {
            List<Product> sortedCopy = new List<Product>(products);
            sortedCopy.Sort(sort.Invoke);
            return sortedCopy;
        }
    }
}
