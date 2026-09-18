namespace AdvancedCSharpConcepts.AdvancedTasks
{
    public record Book
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="title">Title of the book.</param>
        /// <param name="authorName">The author name of the book.</param>
        /// <param name="isbn">ISBN of the book.</param>
        public Book(string title, string authorName, string isbn)
        {
            this.Title = title;
            this.AuthorName = authorName;
            this.ISBN = isbn;
        }

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        /// <value>
        /// The title of the book.
        /// </value>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the author name of the book.
        /// </summary>
        /// <value>
        /// The author name of the book.
        /// </value>
        public string AuthorName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets ISBN of the book.
        /// </summary>
        /// <value>
        /// ISBN of the book.
        /// </value>
        public string ISBN { get; set; } = string.Empty;

        /// <summary>
        /// Deconstructs the book record into its individual components.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="authorName">The author name of the book.</param>
        /// <param name="isbn">ISBN of the book.</param>
        public void Deconstruct(out string title, out string authorName, out string isbn)
        {
            title = this.Title;
            authorName = this.AuthorName;
            isbn = this.ISBN;
        }
    }
}
