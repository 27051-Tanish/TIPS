using InventoryManagement.Model;

namespace InventoryManagement.Repository
{
    /// <summary>
    /// In-memory repository stores the list of products.
    /// </summary>
    public class InMemoryStorage : IInventoryRepository
    {
        private readonly List<InventoryInfo> _inventories = new ();

        /// <inheritdoc/>
        public void AddItems(InventoryInfo item)
        {
            this._inventories.Add(item);
        }

        /// <inheritdoc/>
        public void RemoveItems(InventoryInfo item)
        {
            this._inventories.Remove(item);
        }

        /// <inheritdoc/>
        public List<InventoryInfo> GetAllItems()
        {
            return this._inventories;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public InventoryInfo? GetItemById(string? id)
        {
            return this._inventories.Find(item => item.Id == id);
        }
    }
}
