namespace ExpenseTracker.Core.Model
{
    /// <summary>
    /// Represents the income class, inheriting the properties and the methods of the tracker class.
    /// </summary>
    public class Income : TrackerInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Income"/> class.
        /// </summary>
        /// <param name="id">The id of transaction in the tracker.</param>
        /// <param name="amount">The monetary value of the transaction.</param>
        /// <param name="date">The calendar date when the transaction occurred.</param>
        /// <param name="source">The source of the income.</param>
        public Income(Guid id, decimal amount, DateOnly date, string source)
            : base(id, amount, date)
        {
            this.Source = source;
            this.Type = Enum.RecordType.Income;
        }

        /// <summary>
        /// Gets or sets the source of the income.
        /// </summary>
        /// <value>
        /// Source of the income.
        /// </value>
        public string? Source { get; set; }
    }
}
