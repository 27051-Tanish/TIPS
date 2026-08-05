using ConsoleTables;
using ExpenseTracker.Model;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Provides console-based UI methods for displaying menus, messages,
    /// and reading user input for various application modules.
    /// </summary>
    public class TrackerView
    {
        /// <summary>
        /// Shows menu to the user for selecting a operation.
        /// </summary>
        public void ShowMenu()
        {
            this.ShowMessage("===Expense Tracker===");
            this.ShowMessage("[1]. Add income.");
            this.ShowMessage("[2]. Add expense.");
            this.ShowMessage("[3]. View tracker.");
            this.ShowMessage("[4]. Update tracker.");
            this.ShowMessage("[5]. Delete tracker.");
            this.ShowMessage("[6]. View summary.");
            this.ShowMessage("[7]. Exit.");
            this.EndLine();
        }

        /// <summary>
        /// Displays all the transactions record of the tracker.
        /// </summary>
        /// <param name="tracker">List of transaction records.</param>
        public void DisplayTracker(List<TrackerInfo> tracker)
        {
            if (tracker.Count == 0)
            {
                this.ShowMessage("Tracker is empty.");
                return;
            }

            int serialNumber = 1;

            ConsoleTable table = new ConsoleTable("Serial Number", "Type", "Category/Source", "Amount", "Date");

            foreach (TrackerInfo trackerInfo in tracker)
            {
                table.AddRow(serialNumber, trackerInfo.Type, trackerInfo.Category, trackerInfo.Amount, trackerInfo.Date);
                serialNumber++;
            }

            table.Write();
        }

        /// <summary>
        /// Writes a message to the console.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public void ShowMessage(string message)
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
            this.ShowMessage(new string('=', 25));
        }
    }
}
