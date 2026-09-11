using System.Collections;

namespace CollectionsAndGenerics.Collections
{
    /// <summary>
    /// Performs different operations in the dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of key of the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of value of the dictionary.</typeparam>
    public class DictionaryDemo<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
        where TKey : notnull
    {
        private readonly Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();

        /// <summary>
        /// Adds new student and their grades.
        /// </summary>
        /// <param name="key">The key to add to the dictionary.</param>
        /// <param name="value">The value to add to the dictionary</param>
        public void Add(TKey key, TValue value)
        {
            this._dictionary.Add(key, value);
        }

        /// <summary>
        /// Removes student from the dictionary.
        /// </summary>
        /// <param name="key">The key to remove from the dictionary.</param>
        /// <returns>True if key removed, otherwise false.</returns>
        public bool Remove(TKey key)
        {
            return this._dictionary.Remove(key);
        }

        /// <summary>
        /// Checks if there is element present for the given key.
        /// </summary>
        /// <param name="key">The key of the pair.</param>
        /// <returns>True if the value is present, otherwise false.</returns>
        public bool ContainsKey(TKey key)
        {
            return this._dictionary.ContainsKey(key);
        }

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this._dictionary.GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._dictionary.GetEnumerator();
        }
    }
}
