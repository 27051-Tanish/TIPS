namespace ExpenseTracker.Model.Enum
{
    /// <summary>
    /// Defines the type of the transaction in the tracker.
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Represents the income tracking in the application.
        /// </summary>
        Income = 1,

        /// <summary>
        /// Represents the expense tracking in the application.
        /// </summary>
        Expense,

        /// <summary>
        /// Represents view operation in expense tracking application.
        /// </summary>
        View,

        /// <summary>
        /// Represents edit operation in expense tracking application.
        /// </summary>
        Edit,

        /// <summary>
        /// Represents delete operation in expense tracking application.
        /// </summary>
        Delete,

        /// <summary>
        /// Represents the exit operation in the application.
        /// </summary>
        Exit,
    }
}
