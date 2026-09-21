using System.Collections;
using CollectionsAndGenerics.ConsoleView;

namespace CollectionsAndGenerics.Collections
{
    /// <summary>
    /// Performs different operations in a list.
    /// </summary>
    /// <typeparam name="T">Type of list.</typeparam>
    public class ListDemo<T> : IEnumerable<T>
    {
        private readonly List<T> _items = new List<T>();

        /// <summary>
        /// Adds new book to the list.
        /// </summary>
        /// <param name="item">The book name to be added.</param>
        public void Add(T item)
        {
            this._items.Add(item);
        }

        /// <summary>
        /// Removes a book from the list.
        /// </summary>
        /// <param name="item">The book to be removed.</param>
        /// <returns>True if removed, otherwise false.</returns>
        public bool Remove(T item)
        {
            return this._items.Remove(item);
        }

        /// <summary>
        /// Checks if a particular book is in the list.
        /// </summary>
        /// <param name="item">The book to searched.</param>
        /// <returns>True if the value found, otherwise false.</returns>
        public bool Contains(T item)
        {
            return this._items.Contains(item);
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return this._items.GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._items.GetEnumerator();
        }
    }
}
