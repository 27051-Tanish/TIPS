using InventoryManagement.Exceptions;
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
        /// <param name="item">Item that should be added to the list.</param>
        public void AddNewItems(InventoryInfo item)
        {
            if (this._storage.GetItemById(item.Id) != null)
            {
                throw new DuplicateIdException(item.Id);
            }

            this._storage.AddItems(item);
        }

        /// <summary>
        /// Delete product details from inventory log by id.
        /// </summary>
        /// <param name="id">Id of the product that needs to be deleted from the list.</param>
        /// <returns>True if the item is deleted from the list.</returns>
        public bool DeleteItems(string? id)
        {
            InventoryInfo? item = this._storage.GetItemById(id);
            this._storage.RemoveItems(item);
            return true;
        }

        /// <summary>
        /// Gets all the product details from the inventory management.
        /// </summary>
        /// <returns>List of sorted product details.</returns>
        public List<InventoryInfo> GetItems()
        {
            List<InventoryInfo> items = (List<InventoryInfo>)this._storage.GetAllItems();
            items.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            return items;
        }

        /// <summary>
        /// Updates the product information of given item.
        /// </summary>
        /// <param name="newItem">Item that needs its properties to be updated.</param>
        public void EditItems(InventoryInfo? newItem)
        {
            this._storage.UpdateItems(newItem);
        }

        /// <summary>
        /// Search for product details from log by name.
        /// </summary>
        /// <param name="name">Name of the product.</param>
        /// <returns>List of product details of the given name.</returns>
        public List<InventoryInfo> SearchItem(string? name)
        {
            return this._storage.GetAllItems().Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Gets the item with the given id.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <returns>Product information with the values of given id.</returns>
        public InventoryInfo GetProduct(string id)
        {
            InventoryInfo? item = this._storage.GetItemById(id);
            return item;
        }
    }
}
