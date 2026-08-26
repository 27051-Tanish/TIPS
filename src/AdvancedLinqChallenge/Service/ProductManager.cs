using AdvancedLinqChallenge.DataInitializer;
using AdvancedLinqChallenge.Models;

namespace AdvancedLinqChallenge.Service
{
    /// <summary>
    /// Contains methods for performing LINQ queries.
    /// </summary>
    public class ProductManager
    {
        /// <summary>
        /// Performs basic LINQ query that filters and sorts products, and calculates an average.
        /// </summary>
        /// <returns>The product list with the applied filters.</returns>
        public (List<ProductInfo> Products, decimal? AveragePrice) Task1()
        {
            List<ProductInfo> list = ProductInitializer.Products
                .Where(p => p.Category == "Electronics" && p.Price > 500m)
                .Select(p => new ProductInfo
                {
                    ProductName = p.ProductName,
                    Price = p.Price,
                })
                .OrderByDescending(p => p.Price).ToList();
            decimal? averagePrice = list.Any() ? list.Average(p => p.Price) : 0m;

            return (list, averagePrice);
        }
    }
}
