using System;
using InventoryManagement.Model;
using InventoryManagement.Repository;

namespace InventoryManagement.Service
{
    /// <summary>
    /// Performs basic CRUD operations.
    /// </summary>
    public class InventoryManager
    {
        private InMemoryStorage _storage = new InMemoryStorage();

        /// <summary>
        /// Add new product details to the inventory log.
        /// </summary>
        /// <param name="item">object of inventory class with values of all the properties</param>
        public void AddNewItems(InventoryInfo item)
        {
            this._storage.AddItems(item);
        }

        /// <summary>
        /// Delete product details from inventory log by id.
        /// </summary>
        /// <param name="id">Product Id for deleting a item from lis</param>
        /// <returns>bool value representing deletion of product</returns>
        public bool DeleteItems(string? id)
        {
            InventoryInfo? item = this._storage.GetItem(id);
            this._storage.RemoveItems(item);
            return true;
        }

        /// <summary>
        /// Gets all the product details from the inventory management.
        /// </summary>
        /// <returns>list of product details</returns>
        public List<InventoryInfo> GetItems()
        {
            List<InventoryInfo> items = (List<InventoryInfo>)this.GetItems();
            items.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            return items;
        }

        /// <summary>
        /// Updates the product information of given item.
        /// </summary>
        /// <param name="id">string id of the product</param>
        /// <param name="newItem">object of the inventory class with new value for the properties</param>
        public void EditItems(string? id, InventoryInfo? newItem)
        {

        }
    }
}
