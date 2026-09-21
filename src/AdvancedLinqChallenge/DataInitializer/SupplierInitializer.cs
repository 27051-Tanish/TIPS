using AdvancedLinqChallenge.Models;

namespace AdvancedLinqChallenge.DataInitializer
{
    /// <summary>
    /// Defines the values for the properties of the supplier class.
    /// </summary>
    public static class SupplierInitializer
    {
        /// <summary>
        /// List of supplier details.
        /// </summary>
        public static readonly List<SupplierInfo> SupplierInfos = new List<SupplierInfo>()
        {
            new SupplierInfo() { SupplierId = Guid.NewGuid(), SupplierName = "Sukil", ProductId = ProductInitializer.Products[0].ProductId },
            new SupplierInfo() { SupplierId = Guid.NewGuid(), SupplierName = "Tanish", ProductId = ProductInitializer.Products[1].ProductId },
            new SupplierInfo() { SupplierId = Guid.NewGuid(), SupplierName = "Kavya", ProductId = ProductInitializer.Products[2].ProductId },
            new SupplierInfo() { SupplierId = Guid.NewGuid(), SupplierName = "Umayal", ProductId = ProductInitializer.Products[3].ProductId },
            new SupplierInfo() { SupplierId = Guid.NewGuid(), SupplierName = "Dharanish", ProductId = ProductInitializer.Products[4].ProductId },
            new SupplierInfo() { SupplierId = Guid.NewGuid(), SupplierName = "Sukil", ProductId = ProductInitializer.Products[5].ProductId },
            new SupplierInfo() { SupplierId = Guid.NewGuid(), SupplierName = "Tanish", ProductId = ProductInitializer.Products[6].ProductId },
            new SupplierInfo() { SupplierId = Guid.NewGuid(), SupplierName = "Kavya", ProductId = ProductInitializer.Products[7].ProductId },
            new SupplierInfo() { SupplierId = Guid.NewGuid(), SupplierName = "Umayal", ProductId = ProductInitializer.Products[8].ProductId },
            new SupplierInfo() { SupplierId = Guid.NewGuid(), SupplierName = "Dharanish", ProductId = ProductInitializer.Products[9].ProductId },
        };
    }
}
