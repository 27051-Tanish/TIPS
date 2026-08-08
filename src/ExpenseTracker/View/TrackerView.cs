using ConsoleTables;
using ExpenseTracker.Core.Model;
using ExpenseTracker.Core.TrackerInterface;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Provides console-based UI methods for displaying menus, messages,
    /// and reading user input for various application modules.
    /// </summary>
    public class TrackerView : ITrackerView
    {
        /// <summary>
        /// Shows menu to the user for selecting a operation.
        /// </summary>
        public void ShowMenu()
        {
            this.DisplayMessage("===Expense Tracker===");
            this.DisplayMessage("[1]. Add income.");
            this.DisplayMessage("[2]. Add expense.");
            this.DisplayMessage("[3]. View tracker.");
            this.DisplayMessage("[4]. Update tracker.");
            this.DisplayMessage("[5]. Delete tracker.");
            this.DisplayMessage("[6]. View summary.");
            this.DisplayMessage("[7]. Exit.");
            this.EndLine();
        }

        /// <summary>
        /// Displays all the transactions record of the tracker.
        /// </summary>
        /// <param name="tracker">List of transaction records.</param>
        public void DisplayTracker(List<TrackerInfo> tracker)
        {
            int serialNumber = 1;

            ConsoleTable table = new ("Serial Number", "Type", "Category/Source", "Amount", "Date");

            foreach (TrackerInfo trackerInfo in tracker)
            {
                table.AddRow(serialNumber, trackerInfo.Type, trackerInfo.Category, trackerInfo.Amount, trackerInfo.Date);
                serialNumber++;
            }

            table.Write();
        }

        /// <summary>
        /// Displays the total financial summary of the tracker.
        /// </summary>
        /// <param name="totalIncome">Total income from the records.</param>
        /// <param name="totalExpense">Total expense from the records.</param>
        /// <param name="netBalance">Net balance of the records.</param>
        public void DisplaySummary(decimal totalIncome, decimal totalExpense, decimal netBalance)
        {
            ConsoleTable table = new ("Total Income", "Total Expense", "Net Balance");
            table.AddRow(totalIncome, totalExpense, netBalance);
            table.Write();
        }

        /// <summary>
        /// Writes a message to the console.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Reads a line of input from the console.
        /// </summary>
        /// <returns>The input entered by the user, or null, if no input is available.</returns>
        public string? ReadInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Draws a visual separator line to improve the console view.
        /// </summary>
        public void EndLine()
        {
            this.DisplayMessage(new string('=', 25));
        }
    }
}
