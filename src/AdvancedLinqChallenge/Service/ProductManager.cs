using System.Collections.Generic;
using System.Diagnostics;
using AdvancedLinqChallenge.DataInitializer;
using AdvancedLinqChallenge.DataInitializer.ConstantData;
using AdvancedLinqChallenge.LinqExtensions;
using AdvancedLinqChallenge.Models;
using AdvancedLinqChallenge.Models.Enum;

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
        /// <param name="category">The category to filter.</param>
        /// <returns>The product list with the applied filters.</returns>
        public (List<ProductInfo>, decimal?) Task1(string? category)
        {
            List<ProductInfo> list = ProductInitializer.Products
                .Where(p => p.Category == category && p.Price > 500m)
                .Select(p => new ProductInfo
                {
                    ProductName = p.ProductName,
                    Price = p.Price,
                })
                .OrderByDescending(p => p.Price).ToList();
            decimal? averagePrice = list.Any() ? list.Average(p => p.Price) : 0m;

            return (list, averagePrice);
        }

        /// <summary>
        /// Performs complex LINQ queries to group products by category and count the products in each category and expensive
        /// product of the category.
        /// </summary>
        /// <returns>List of joined details of product and supplier.</returns>
        public List<(string? Category, int Count, decimal ExpensiveProductPrice, string? ProductName, string SupplierName)> Task2()
        {
            var list = ProductInitializer.Products.GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Count = g.Count(),
                    ExpensiveProduct = g.MaxBy(p => p.Price) !,
                })
                .Join(
                SupplierInitializer.SupplierInfos,
                product => product.ExpensiveProduct.ProductId,
                supplier => supplier.ProductId,
                (product, supplier) => (Category: product.Category,
                Count: product.Count,
                ExpensiveProductprice: product.ExpensiveProduct.Price,
                ProductName: product.ExpensiveProduct.ProductName,
                SupplierName: supplier.SupplierName)).OrderBy(c => c.Category).ToList();

            return list;
        }

        /// <summary>
        /// Performs LINQ operations on in-memory objects such as arrays.
        /// </summary>
        /// <returns>Second highest number in the array and
        /// All unique pairs of numbers in the array that add up to a specified target</returns>
        public int FindSecondHighest()
        {
            int secondHighestNumber = ConstantVariable.Array.OrderByDescending(s => s).Skip(1).FirstOrDefault();
            return secondHighestNumber;
        }

        /// <summary>
        /// Finds all unique pair of numbers in the array that add up to a specified target.
        /// </summary>
        /// <param name="target">The target number.</param>
        /// <returns>All the unique pairs.</returns>
        public List<(int, int)> FindUniquePairs(int target)
        {
            return ConstantVariable.Array.SelectMany((num1, index1) => ConstantVariable.Array
            .Where((num2, index2) => index2 > index1 && num1 + num2 == target)
            .Select(num2 => (num1, num2))).Distinct().ToList();
        }

        /// <summary>
        /// LINQ query that selects all products under the category "Books" and sorts them by price unoptimized version.
        /// </summary>
        /// <param name="category">The category to filter.</param>
        /// <returns>The sorted version of products with category books.</returns>
        public List<ProductInfo> GetBooksInUnoptimized(string? category)
        {
            return ProductInitializer.Products.ToList().OrderBy(p => p.Price).Where(p => p.Category == category).ToList();
        }

        /// <summary>
        /// LINQ query that selects all products under the category "Books" and sorts them by price optimized version.
        /// </summary>
        /// <param name="category">The category to filter.</param>
        /// <returns>The sorted version of products with category books.</returns>
        public List<ProductInfo> GetBooksInOptimized(string? category)
        {
            return ProductInitializer.Products.Where(p => p.Category == category).OrderBy(p => p.Price).ToList();
        }

        /// <summary>
        /// Retrieves products that are phones using the first overload filter method..
        /// </summary>
        /// <param name="productName">The category to filter.</param>
        /// <returns>The filtered and sorted version of the list.</returns>
        public List<ProductInfo> GetPhoneProduct(string? productName)
        {
            QueryBuilder<ProductInfo> query = new QueryBuilder<ProductInfo>(ProductInitializer.Products);
            var result = query.Filter(p => p.ProductName == productName).Sort(p => p.Price).Execute(); // Uses Overload 1.
            return result;
        }

        /// <summary>
        /// Retrieves products that starts with 'Elec' in the category using the second overload method.
        /// </summary>
        /// <returns>The filtered and sorted version of the list.</returns>
        public List<ProductInfo> GetProductThatStartsWithElec()
        {
            var query = new QueryBuilder<ProductInfo>(ProductInitializer.Products)
                .Filter("Category", FilterConditions.StartsWith, "Elec") // Uses Overload 2 (Expression Tree)
                .Filter(p => p.Price > 500m).Execute();
            return query;
        }
    }
}
