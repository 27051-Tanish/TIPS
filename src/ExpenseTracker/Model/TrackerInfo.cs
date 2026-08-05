using ExpenseTracker.Model.Enum;

namespace ExpenseTracker.Model
{
    /// <summary>
    /// Provides a base contract and shared properties for expense tracker objects.
    /// </summary>
    public class TrackerInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackerInfo"/> class.
        /// </summary>
        /// <param name="type">The type of transaction used in the tracker.</param>
        /// <param name="category">The category in which the transaction takes place.</param>
        /// <param name="amount">The monetary value of the transaction.</param>
        /// <param name="date">The calendar date when the transaction occurred.</param>
        public TrackerInfo(string type, string category, decimal amount, DateOnly date)
        {
            this.Type = type;
            this.Category = category;
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
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the category of the monetary transaction.
        /// </summary>
        /// <value>
        /// The category in which the transaction takes place.
        /// </value>
        public string Category { get; set; }

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