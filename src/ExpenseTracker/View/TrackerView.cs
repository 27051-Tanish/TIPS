using ConsoleTables;
using ExpenseTracker.Core.Model;
using ExpenseTracker.Core.TrackerInterface;
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
            this.DisplayMessage("[7]. Exit.");
            this.EndLine();
        }

        /// <inheritdoc/>
        public void DisplayTracker(List<TrackerInfo> tracker)
        {
            int serialNumber = 1;

            ConsoleTable table = new ("Serial Number", "Type", "Category/Source", "Amount", "Date");

            foreach (TrackerInfo trackerInfo in tracker)
            {
                if (trackerInfo is Income income)
                {
                    table.AddRow(serialNumber, nameof(Income), income.Source, trackerInfo.Amount, trackerInfo.Date);
                    serialNumber++;
                }
                else if (trackerInfo is Expense expense)
                {
                    table.AddRow(serialNumber, nameof(Expense), expense.Category, trackerInfo.Amount, trackerInfo.Date);
                    serialNumber++;
                }
            }

            table.Write();
        }

        /// <inheritdoc/>
        public void DisplayIncome(List<TrackerInfo> tracker)
        {
            this.DisplayRecords<Income>(tracker, "Income");
        }

        /// <inheritdoc/>
        public void DisplayExpense(List<TrackerInfo> tracker)
        {
            this.DisplayRecords<Expense>(tracker, "Expense");
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

        /// <inheritdoc/>
        public void DisplayRecords<T>(List<TrackerInfo> tracker, string recordType)
            where T : TrackerInfo
        {
            var filteredRecords = tracker.OfType<T>().ToList();
            if (!filteredRecords.Any())
            {
                this.DisplayMessage($"No {recordType} records found.");
                return;
            }

            ConsoleTable table = new ("Serial Number", "Type", "Category/Source", "Amount", "Date");
            int serialNumber = 1;

            foreach (TrackerInfo trackerInfo in filteredRecords)
            {
                if (trackerInfo is Income income && recordType == "Income")
                {
                    table.AddRow(serialNumber, recordType, income.Source, trackerInfo.Amount, trackerInfo.Date);
                    serialNumber++;
                }
                else if (trackerInfo is Expense expense && recordType == "Expense")
                {
                    table.AddRow(serialNumber, recordType, expense.Category, trackerInfo.Amount, trackerInfo.Date);
                    serialNumber++;
                }
            }

            table.Write();
        }
    }
}
