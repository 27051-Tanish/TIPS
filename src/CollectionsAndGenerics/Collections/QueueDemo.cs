using System.Collections;

namespace CollectionsAndGenerics.Collections
{
    /// <summary>
    /// Performs different operations in the queue.
    /// </summary>
    /// <typeparam name="T">Type of the queue.</typeparam>
    public class QueueDemo<T> : IEnumerable<T>
    {
        private Queue<T> _items = new Queue<T>();

        /// <summary>
        /// Adds the name of a person to the queue.
        /// </summary>
        /// <param name="person">The name of the person</param>
        public void Add(T person)
        {
            this._items.Enqueue(person);
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return this._items.GetEnumerator();
        }

        /// <summary>
        /// Removes the first person from the queue.
        /// </summary>
        public void Remove()
        {
            this._items.Dequeue();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._items.GetEnumerator();
        }
    }
}
