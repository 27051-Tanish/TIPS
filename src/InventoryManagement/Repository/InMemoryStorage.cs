using InventoryManagement.Model;

namespace InventoryManagement.Repository
{
    /// <summary>
    /// In-memory repository stores the list of products.
    /// </summary>
    public class InMemoryStorage : IInventoryRepository
    {
        private readonly List<InventoryInfo> _inventories = new ();

        /// <summary>
        /// Add new product to the list.
        /// </summary>
        /// <param name="item">Item that needs to be added to the list.</param>
        public void AddItems(InventoryInfo item)
        {
            this._inventories.Add(item);
        }

        /// <summary>
        /// Remove a product/item from the list.
        /// </summary>
        /// <param name="item">Item that needs to be removed from the list.</param>
        public void RemoveItems(InventoryInfo item)
        {
            this._inventories.Remove(item);
        }

        /// <summary>
        /// Copies the in-memory repository to a duplicate list.
        /// </summary>
        /// <returns>Copy of original list.</returns>
        public List<InventoryInfo> GetAllItems()
        {
            List<InventoryInfo> copyList = new ();
            foreach (InventoryInfo item in this._inventories)
            {
                copyList.Add(item);
            }

            return copyList;
        }

        /// <summary>
        /// Edit product details from the list.
        /// </summary>
        /// <param name="item">Item that needs to be updated.</param>
        public void UpdateItems(InventoryInfo item)
        {
            InventoryInfo? oldItem = this.GetItemById(item.Id);
            if (oldItem != null)
            {
                oldItem.Name = item.Name;
                oldItem.Price = item.Price;
                oldItem.Quantity = item.Quantity;
            }
        }

        /// <summary>
        /// Get item information by product id.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <returns>Product information of given id.</returns>
        public InventoryInfo? GetItemById(string? id)
        {
            return this._inventories.Find(item => item.Id == id);
        }
    }
}
