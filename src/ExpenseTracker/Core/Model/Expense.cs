namespace ExpenseTracker.Core.Model
{
    /// <summary>
    /// Represents the expense class, inheriting the properties and the methods of the tracker class.
    /// </summary>
    public class Expense : TrackerInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="id">The id of transaction in the tracker.</param>
        /// <param name="amount">The monetary value of the transaction.</param>
        /// <param name="date">The calendar date when the transaction occurred.</param>
        /// <param name="category">The category of the income.</param>
        public Expense(Guid id, decimal amount, DateOnly date, string category)
            : base(id, amount, date)
        {
            this.Category = category;
            this.Type = Enum.RecordType.Expense;
        }

        /// <summary>
        /// Gets or sets the category of the expense.
        /// </summary>
        /// <value>
        /// The category of the expense.
        /// </value>
        public string? Category { get; set; }
    }
}
