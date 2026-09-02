namespace ExpenseTracker.Core.Model.Enum
{
    /// <summary>
    /// Defines the type of the transaction in the tracker.
    /// </summary>
    public enum TrackerMenu
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
        /// Represents view operation in tracker application.
        /// </summary>
        View,

        /// <summary>
        /// Represents edit operation in tracker application.
        /// </summary>
        Edit,

        /// <summary>
        /// Represents delete operation in tracker application.
        /// </summary>
        Delete,

        /// <summary>
        /// Represents the display of total financial summary.
        /// </summary>
        Summary,

        /// <summary>
        /// Represents the exit operation of the application.
        /// </summary>
        Exit,
    }
}
