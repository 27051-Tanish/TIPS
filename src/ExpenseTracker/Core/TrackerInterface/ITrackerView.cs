using ExpenseTracker.Core.Model;
using static ExpenseTracker.TrackerController;

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
        /// Displays only the income records from the tracker.
        /// </summary>
        /// <param name="tracker">The tracker records.</param>
        void DisplayIncome(List<TrackerInfo> tracker);

        /// <summary>
        /// Displays only the expense records from the tracker.
        /// </summary>
        /// <param name="tracker">The tracker records.</param>
        void DisplayExpense(List<TrackerInfo> tracker);

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

        /// <summary>
        /// Gets user input for performing various functions.
        /// </summary>
        /// <returns>The value of choice from menu if valid, otherwise error message.</returns>
        int GetChoice();

        /// <summary>
        /// Gets user input for amount.
        /// </summary>
        /// <returns>The amount if valid, otherwise the error message.</returns>
        decimal GetAmount();

        /// <summary>
        /// Gets user input for date.
        /// </summary>
        /// <returns>The date if valid, otherwise the error message.</returns>
        DateOnly GetDate();

        /// <summary>
        /// Attempts to parse the user input.
        /// </summary>
        /// <typeparam name="T">The object type required.</typeparam>
        /// <param name="tryParse">The delegate implementation wrapping matching types.</param>
        /// <param name="errorMessage">The error message to be displayed.</param>
        /// <returns>The parsed value if true, otherwise error message.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the looping threshold is exceeded without processing success.</exception>
        T GetValue<T>(TryParseHandler<T> tryParse, string errorMessage);
    }
}
