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
        /// Represents the display of total financial summary.
        /// </summary>
        Summary,

        /// <summary>
        /// Represents the exit operation in the application.
        /// </summary>
        Exit,
    }

    /// <summary>
    /// Defines the edit menu for performing edit operation.
    /// </summary>
    public enum EditMenu
    {
        /// <summary>
        /// Represents the update of category section.
        /// </summary>
        Category = 1,

        /// <summary>
        /// Represents the update of amount section.
        /// </summary>
        Amount,

        /// <summary>
        /// Represents the update of date section.
        /// </summary>
        Date,

        /// <summary>
        /// Represents the exit operation from the edit section.
        /// </summary>
        Exit,
    }
}
