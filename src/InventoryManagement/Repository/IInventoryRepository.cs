using InventoryManagement.Model;

namespace InventoryManagement.Repository
{
    /// <summary>
    /// Defines contract for data access operation on inventory records.
    /// </summary>
    public interface IInventoryRepository
    {
        /// <summary>
        /// Add new product details to the inventory log.
        /// </summary>
        /// <param name="item">The item needs to be added.</param>
        void AddItems(InventoryInfo item);

        /// <summary>
        /// Remove existing product details to the inventory log.
        /// </summary>
        /// <param name="item">The item needs to be deleted.</param>
        void RemoveItems(InventoryInfo item);

        /// <summary>
        /// Retrieves the product details from the inventory log.
        /// </summary>
        /// <returns>The product details.</returns>
        List<InventoryInfo> GetAllItems();

        /// <summary>
        /// Update the product details from the inventory log.
        /// </summary>
        /// <param name="item">The product that needs to be updated.</param>
        void UpdateItems(InventoryInfo item);

        /// <summary>
        /// Retrieves particular product details from the inventory log.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <returns>The product details of the given id.</returns>
        InventoryInfo? GetItemById(string? id);
    }
}
