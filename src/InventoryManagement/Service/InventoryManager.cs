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
        private readonly IInventoryRepository _storage = new InMemoryStorage();

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
            if (item != null)
            {
                this._storage.RemoveItems(item);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets all the product details from the inventory management.
        /// </summary>
        /// <returns>List of sorted product details.</returns>
        public List<InventoryInfo> GetItems()
        {
            List<InventoryInfo> items = this._storage.GetAllItems();
            items.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            return items;
        }

        /// <summary>
        /// Updates the product information of given item.
        /// </summary>
        /// <param name="newItem">Item that needs its properties to be updated.</param>
        public void EditItems(InventoryInfo? newItem)
        {
            if (newItem != null)
            {
                this._storage.UpdateItems(newItem);
            }
        }

        /// <summary>
        /// Fetch the inventory records by the given name and id.
        /// </summary>
        /// <param name="items">The list of inventory records.</param>
        /// <param name="input">Name or Id of the product detail.</param>
        /// <returns>Null if invalid input, otherwise the inventory details of the product.</returns>
        public InventoryInfo? FindItemByIdOrName(IEnumerable<InventoryInfo> items, string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return items.FirstOrDefault(item =>
                string.Equals(item.Id, input, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(item.Name, input, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Search for product details from log by name or id.
        /// </summary>
        /// <param name="searchKey">Name or id of the product.</param>
        /// <returns>List of product details of the given name.</returns>
        public List<InventoryInfo>? SearchItem(string? searchKey)
        {
            return this._storage.GetAllItems().Where(s => s.Id.Contains(searchKey, StringComparison.OrdinalIgnoreCase) ||
            s.Name.Contains(searchKey, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Gets the item with the given id.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <returns>Product information with the values of given id.</returns>
        public InventoryInfo? GetProduct(string? id)
        {
            InventoryInfo? item = this._storage.GetItemById(id);
            return item;
        }
    }
}
