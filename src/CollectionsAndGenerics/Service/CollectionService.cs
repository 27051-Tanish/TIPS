using CollectionsAndGenerics.Collections;

namespace CollectionsAndGenerics.Service
{
    /// <summary>
    /// Handles data management, filtering, and business logic for object collections.
    /// </summary>
    public class CollectionService
    {
        /// <summary>
        /// Adds new item to the list.
        /// </summary>
        /// <param name="items">The list in which it needs to be added.</param>
        /// <param name="item">The item which needs to be added.</param>
        /// <typeparam name="T">The type of collection.</typeparam>
        public void Add<T>(ListDemo<T> items, T item)
        {
            items.Add(item);
        }

        /// <summary>
        /// Removes an item from the list.
        /// </summary>
        /// <typeparam name="T">The type of collection.</typeparam>
        /// <param name="items">The list in which it needs to be removed.</param>
        /// <param name="item">The item which needs to be removed.</param>
        /// <returns>True if removed, otherwise false.</returns>
        public bool Remove<T>(ListDemo<T> items, T item)
        {
            return items.Remove(item);
        }

        /// <summary>
        /// Determines whether the specified custom list contains a specific element.
        /// </summary>
        /// <typeparam name="T">The type of elements stored in the collection.</typeparam>
        /// <param name="books">The custom list demo collection to search.</param>
        /// <param name="item">The object to locate in the collection.</param>
        /// <returns>True if the item is found in the collection; otherwise, false.</returns>
        public bool Contains<T>(ListDemo<T> books, T item)
        {
            return books.Contains(item);
        }

        /// <summary>
        /// Converts a custom ListDemo collection into a standard List.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="items">The custom ListDemo collection to convert.</param>
        /// <returns>A standard List containing all elements from the original collection.</returns>
        public List<T> GetItems<T>(ListDemo<T> items)
        {
            List<T> list = new List<T>();
            foreach (T item in items)
            {
                list.Add(item);
            }

            return list;
        }

        /// <summary>
        /// Reverse the string using stack operations.
        /// </summary>
        /// <param name="value">The value to be reversed.</param>
        /// <returns>The reversed string.</returns>
        public string ReverseString(string value)
        {
            StackDemo<char> stack = new StackDemo<char>();
            foreach (char c in value)
            {
                stack.PushName(c);
            }

            string reverse = " ";
            while (!stack.IsEmpty())
            {
                reverse += stack.PopName();
            }

            return reverse;
        }

        /// <summary>
        /// Adds new item to the queue.
        /// </summary>
        /// <typeparam name="T">The type of collection.</typeparam>
        /// <param name="queue">The queue in which the item needs to be added.</param>
        /// <param name="item">The item that needs to be added.</param>
        public void Enqueue<T>(QueueDemo<T> queue, T item)
        {
            queue.Add(item);
        }

        /// <summary>
        /// Removes first element to the queue.
        /// </summary>
        /// <typeparam name="T">The type of collection.</typeparam>
        /// <param name="queue">The queue in which the dequeue operation needs to be performed.</param>
        public void Dequeue<T>(QueueDemo<T> queue)
        {
            queue.Remove();
        }

        /// <summary>
        /// Adds new key value pair to the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of key.</typeparam>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="dictionary">The dictionary in which the values needs to be added.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void AddKeyValuePair<TKey, TValue>(DictionaryDemo<TKey, TValue> dictionary, TKey key, TValue value)
        {
            dictionary.Add(key, value);
        }

        /// <summary>
        /// Adds new key value pair to the collection.
        /// </summary>
        /// <typeparam name="TKey">The type of key.</typeparam>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="dictionary">The dictionary in which the values needs to be added.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>True if key removed, otherwise false.</returns>
        public bool RemoveKey<TKey, TValue>(DictionaryDemo<TKey, TValue> dictionary, TKey key, TValue value)
        {
            return dictionary.Remove(key);
        }

        /// <summary>
        /// Check whether the dictionary has the key.
        /// </summary>
        /// <typeparam name="TKey">Type of the key.</typeparam>
        /// <typeparam name="TValue">Type of the value.</typeparam>
        /// <param name="dictionary">The dictionary in which the search happens.</param>
        /// <param name="key">The search key.</param>
        /// <returns>True if the dictionary has the key, otherwise false.</returns>
        public bool ContainsKey<TKey, TValue>(DictionaryDemo<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Calculates the total sum of a collection of numbers.
        /// </summary>
        /// <param name="numbers">The collection of integer elements to sum.</param>
        /// <returns>The total sum of all elements in the collection; returns 0 if the collection is null or empty.</returns>
        public int SumOfElements(IEnumerable<int> numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }

            return sum;
        }

        /// <summary>
        /// Creates a dictionary object and add new items to it.
        /// </summary>
        /// <returns>The dictionary as IReadOnlyDictionary type which is immutable.</returns>
        public IReadOnlyDictionary<string, int> GenerateDictionary()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("Tanish", 99);
            dictionary.Add("Bomb", 90);
            dictionary.Add("Cat", 89);
            dictionary.Add("Eran", 80);

            return dictionary;
        }
    }
}
