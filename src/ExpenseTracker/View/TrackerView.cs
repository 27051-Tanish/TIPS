using ConsoleTables;
using ExpenseTracker.Core.Model;
using ExpenseTracker.Core.TrackerInterface;
using ExpenseTracker.Helper;
using static ExpenseTracker.TrackerController;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Provides console-based UI methods for displaying menus, messages,
    /// and reading user input for various application modules.
    /// </summary>
    public class TrackerView : ITrackerView
    {
        /// <inheritdoc/>
        public void ShowMenu()
        {
            this.DisplayMessage("===Expense Tracker===");
            this.DisplayMessage("[1]. Add income.");
            this.DisplayMessage("[2]. Add expense.");
            this.DisplayMessage("[3]. View tracker.");
            this.DisplayMessage("[4]. Update tracker.");
            this.DisplayMessage("[5]. Delete tracker.");
            this.DisplayMessage("[6]. View summary.");
            this.DisplayMessage("[7]. Back up.");
            this.DisplayMessage("[8]. Exit.");
            this.EndLine();
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void DisplaySummary(decimal totalIncome, decimal totalExpense, decimal netBalance)
        {
            ConsoleTable table = new ("Total Income", "Total Expense", "Net Balance");
            table.AddRow(totalIncome, totalExpense, netBalance);
            table.Write();
        }

        /// <inheritdoc/>
        public void DisplayMessage(string message) => Console.WriteLine(message);

        /// <inheritdoc/>
        public string? ReadInput()
        {
            return Console.ReadLine();
        }

        /// <inheritdoc/>
        public void EndLine()
        {
            this.DisplayMessage(new string('=', 25));
        }

        /// <inheritdoc/>
        public int GetChoice()
        {
            return this.GetValue<int>(int.TryParse, "Invalid choice\nPlease enter valid choice from the menu.");
        }

        /// <inheritdoc/>
        public decimal GetAmount()
        {
            return this.GetValue<decimal>(decimal.TryParse, "Invalid entry for amount.\nPlease enter again :");
        }

        /// <inheritdoc/>
        public DateOnly GetDate()
        {
            return this.GetValue<DateOnly>(DateOnly.TryParse, "Invalid entry for date.\nDate should be in (dd/mm/yyyy) format.\nPlease enter again :");
        }

        /// <inheritdoc/>
        public T GetValue<T>(TryParseHandler<T> tryParse, string errorMessage)
        {
            while (true)
            {
                if (tryParse(this.ReadInput(), out T value))
                {
                    return value;
                }

                this.DisplayMessage(errorMessage);
            }
        }
    }
}
