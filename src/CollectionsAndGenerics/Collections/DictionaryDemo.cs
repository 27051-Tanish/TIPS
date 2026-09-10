namespace CollectionsAndGenerics.Collections
{
    /// <summary>
    /// Performs different operations in the dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of key of the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of value of the dictionary.</typeparam>
    public class DictionaryDemo<TKey, TValue>
        where TKey : notnull
    {
        private Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();

        /// <summary>
        /// Adds new student and their grades.
        /// </summary>
        /// <param name="key">The key to add to the dictionary.</param>
        /// <param name="value">The value to add to the dictionary</param>
        public void AddStudents(TKey key, TValue value)
        {
            this._dictionary.Add(key, value);
        }

        /// <summary>
        /// Displays the student details after adding.
        /// </summary>
        public void DisplayAfterAdding()
        {
            Console.WriteLine(new string('=', 20));
            this.DisplayStudents();
            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Press any key to continue with removing a student from dictionary...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Removes student from the dictionary.
        /// </summary>
        /// <param name="key">The key to remove from the dictionary.</param>
        public void RemoveStudents(TKey key)
        {
            this._dictionary.Remove(key);
            Console.WriteLine($"Student removed successfully.\nList of Students and their grades after removing a {key}: ");
            Console.WriteLine(new string('=', 20));
            this.DisplayStudents();
            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Displays the students name and their marks.
        /// </summary>
        public void DisplayStudents()
        {
            foreach (var student in this._dictionary)
            {
                Console.WriteLine($"{student.Key}: {student.Value}");
            }
        }
    }
}
