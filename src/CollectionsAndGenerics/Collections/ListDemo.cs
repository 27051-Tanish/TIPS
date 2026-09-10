namespace CollectionsAndGenerics.Collections
{
    /// <summary>
    /// Performs different operations in a list.
    /// </summary>
    /// <typeparam name="T">Type of list.</typeparam>
    public class ListDemo<T>
    {
        private List<T> _books = new List<T>();

        /// <summary>
        /// Adds new book to the list.
        /// </summary>
        /// <param name="book">The book name to be added.</param>
        public void AddBooks(T book)
        {
            this._books.Add(book);
        }

        /// <summary>
        /// Displays the list of books after adding.
        /// </summary>
        public void DisplayAfterAdding()
        {
            Console.WriteLine(new string('=', 20));
            this.DisplayBooks();
            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Press any key to continue with removing of list");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Removes a book from the list.
        /// </summary>
        /// <param name="book">The book to be removed.</param>
        public void RemoveBooks(T book)
        {
            this._books.Remove(book);
            Console.WriteLine($"{book} Book removed successfully.\nList of books after removing {book}.");
            Console.WriteLine(new string('=', 20));
            this.DisplayBooks();
            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Press any key to continue with contains");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Checks if a particular book is in the list.
        /// </summary>
        /// <param name="book">The book to searched.</param>
        public void ContainBooks(T book)
        {
            bool availableBooks = this._books.Contains(book);
            Console.WriteLine($"Is there any book named 'GOT' exists : {availableBooks}");
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Displays the books in the list.
        /// </summary>
        public void DisplayBooks()
        {
            foreach (T book in this._books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
