using AdvancedLinqChallenge.Models;

namespace AdvancedLinqChallenge.DataInitializer
{
    /// <summary>
    /// Defines the values for the properties of the product class.
    /// </summary>
    public static class ProductInitializer
    {
        /// <summary>
        /// List of products details.
        /// </summary>
        public static readonly List<ProductInfo> Products = new List<ProductInfo>()
        {
            new ProductInfo() { ProductId = Guid.NewGuid(), ProductName = "Phone", Price = 12000m, Category = "Electronics" },
            new ProductInfo() { ProductId = Guid.NewGuid(), ProductName = "Harry Potter", Price = 200m, Category = "Books" },
            new ProductInfo() { ProductId = Guid.NewGuid(), ProductName = "iPhone", Price = 50000m, Category = "Electronics" },
            new ProductInfo() { ProductId = Guid.NewGuid(), ProductName = "Soap", Price = 50m, Category = "Grocery" },
            new ProductInfo() { ProductId = Guid.NewGuid(), ProductName = "Watch", Price = 1500m, Category = "Accessories" },
            new ProductInfo() { ProductId = Guid.NewGuid(), ProductName = "laptop", Price = 102000m, Category = "Electronics" },
            new ProductInfo() { ProductId = Guid.NewGuid(), ProductName = "The 48 Laws of Power", Price = 500m, Category = "Books" },
            new ProductInfo() { ProductId = Guid.NewGuid(), ProductName = "Apple", Price = 50000m, Category = "Fruits" },
            new ProductInfo() { ProductId = Guid.NewGuid(), ProductName = "Ikigai", Price = 50m, Category = "Books" },
            new ProductInfo() { ProductId = Guid.NewGuid(), ProductName = "Fan", Price = 1500m, Category = "Accessories" },
        };
    }
}
