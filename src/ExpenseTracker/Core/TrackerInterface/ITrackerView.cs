using ExpenseTracker.Core.Model;

namespace ExpenseTracker.Core.TrackerInterface
{
    /// <summary>
    /// Defines a contract for providing console based UI methods.
    /// </summary>
    public interface ITrackerView
    {
        /// <summary>
        /// Displays the main menu.
        /// </summary>
        void ShowMenu();

        /// <summary>
        /// Displays the tracker information of the records.
        /// </summary>
        /// <param name="tracker">The tracker record.</param>
        void DisplayTracker(List<TrackerInfo> tracker);

        /// <summary>
        /// Displays the final finance summary of the tracker record.
        /// </summary>
        /// <param name="totalIncome">The total income from the record.</param>
        /// <param name="totalExpense">The total expense from the record.</param>
        /// <param name="netBalance">The net balance of the record.</param>
        void DisplaySummary(decimal totalIncome, decimal totalExpense, decimal netBalance);

        /// <summary>
        /// Writes the message to the UI.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        void DisplayMessage(string message);

        /// <summary>
        /// Reads an user input from the UI.
        /// </summary>
        /// <returns>The input entered by the user, or null, if no input is available.</returns>
        string? ReadInput();

        /// <summary>
        /// Draws a visual separator line to improve the UI.
        /// </summary>
        void EndLine();
    }
}
