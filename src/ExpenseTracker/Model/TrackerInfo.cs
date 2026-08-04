namespace ExpenseTracker.Model
{
    /// <summary>
    /// Provides a base contract and shared properties for expense tracker objects.
    /// </summary>
    internal class TrackerInfo
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        /// <value>
        /// Id of the particular tracker detail.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount of the 
        /// </value>
        public decimal Amount { get; set; }

        public string Category { get; set; }

        public DateTime Date { get; set; }