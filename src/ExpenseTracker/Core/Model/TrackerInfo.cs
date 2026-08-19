using ExpenseTracker.Core.Model.Enum;

namespace ExpenseTracker.Core.Model
{
    /// <summary>
    /// Provides a base contract and shared properties for expense tracker objects.
    /// </summary>
    public abstract class TrackerInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackerInfo"/> class.
        /// </summary>
        /// <param name="id">The id of transaction in the tracker.</param>
        /// <param name="amount">The monetary value of the transaction.</param>
        /// <param name="date">The calendar date when the transaction occurred.</param>
        public TrackerInfo(Guid id, decimal amount, DateOnly date)
        {
            this.Id = id;
            this.Amount = amount;
            this.Date = date;
        }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier for the tracker record.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        /// <value>
        /// The type of transaction.
        /// </value>
        public RecordType Type { get; set; }

        /// <summary>
        /// Gets or sets the monetary amount.
        /// </summary>
        /// <value>
        /// The monetary value of the transaction.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date of the transaction.
        /// </summary>
        /// <value>
        /// The specific calendar date when the transaction occurred.
        /// </value>
        public DateOnly Date { get; set; }
    }
}
