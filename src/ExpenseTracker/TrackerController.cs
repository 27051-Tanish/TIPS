using ExpenseTracker.Core.Model;
using ExpenseTracker.Core.Model.Enum;
using ExpenseTracker.Core.TrackerInterface;
using ExpenseTracker.Helper;
using ExpenseTracker.Service;

namespace ExpenseTracker
{
    /// <summary>
    /// Controls the data flow between the service logic and view components.
    /// </summary>
    public class TrackerController
    {
        private readonly ITrackerView _trackerView;
        private readonly TrackerManager _trackerManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackerController"/> class.
        /// </summary>
        /// <param name="trackerView">The console view instance used for user interaction.</param>
        /// <param name="trackerManager">The project manager instance used for managing inventory data.</param>
        public TrackerController(ITrackerView trackerView, TrackerManager trackerManager)
        {
            this._trackerView = trackerView;
            this._trackerManager = trackerManager;
        }

        /// <summary>
        /// Represents a delegate that attempts to convert the specified input.
        /// </summary>
        /// <typeparam name="T">The target type to which the input string is parsed.</typeparam>
        /// <param name="input">The string value to parse.</param>
        /// <param name="value">When this method returns, contains the parsed value if the conversion
        /// succeeded; otherwise, contains the default value</param>
        /// <returns>True if the input was successfully parsed; otherwise,false.</returns>
        public delegate bool TryParseHandler<T>(string input, out T value);

        /// <summary>
        /// Starts the execution of expense tracker application.
        /// </summary>
        public void RunExpenseTrackerApp()
        {
            int choiceValue;
            TrackerMenu menu;
            do
            {
                this._trackerView.ShowMenu();
                this._trackerView.DisplayMessage("Please enter your choice :");
                choiceValue = this.GetChoice();
                menu = (TrackerMenu)choiceValue;

                switch (menu)
                {
                    case TrackerMenu.Income:
                        this.AddIncome();
                        break;
                    case TrackerMenu.Expense:
                        this.AddExpense();
                        break;
                    case TrackerMenu.View:
                        this.ViewTracker();
                        break;
                    case TrackerMenu.Edit:
                        this.EditTracker();
                        break;
                    case TrackerMenu.Delete:
                        this.DeleteRecord();
                        break;
                    case TrackerMenu.Summary:
                        this.RetrieveSummary();
                        break;
                    case TrackerMenu.Exit:
                        break;
                    default:
                        this._trackerView.DisplayMessage("Please enter valid choice from [1 to 7].\nEnter your choice again :");
                        break;
                }
            }
            while (menu != TrackerMenu.Exit);
        }

        private void AddIncome()
        {
            this.AddRecord(RecordType.Income, "source", "income", "(Eg: salary, freelance, etc.)");
        }

        private void AddExpense()
        {
            this.AddRecord(RecordType.Expense, "category", "expense", "(Eg: food, transport, etc.)");
        }

        private void ViewTracker()
        {
            List<TrackerInfo> tracker = this._trackerManager.GetAllTransactions();
            if (tracker.Count == 0)
            {
                this._trackerView.DisplayMessage("Tracker is empty.");
                return;
            }

            this._trackerView.DisplayTracker(tracker);
        }

        private void EditTracker()
        {
            List<TrackerInfo> records = (List<TrackerInfo>)this._trackerManager.GetAllTransactions();
            if (records.Count == 0)
            {
                this._trackerView.DisplayMessage("Tracker is empty.");
                return;
            }

            this._trackerView.DisplayTracker(records);
            this._trackerView.DisplayMessage("Enter the serial number of the record to edit :");
            int serialNumber = this.GetChoice();

            if (serialNumber < 0 || serialNumber > records.Count)
            {
                this._trackerView.DisplayMessage($"There is no record with the serial number :{serialNumber}");
            }
            else
            {
                Guid selectedId = (Guid)records[serialNumber - 1].Id;
                TrackerInfo? tracker = this._trackerManager.GetByGuid(selectedId);

                int choice;
                EditMenu menu;
                do
                {
                    this._trackerView.DisplayMessage("[1]. Source/Category\n[2]. Amount\n[3]. Date\n[4]. Exit");
                    this._trackerView.DisplayMessage("Please enter an option :");
                    choice = this.GetChoice();
                    menu = (EditMenu)choice;
                    switch (menu)
                    {
                        case EditMenu.Category:
                            while (true)
                            {
                                this._trackerView.DisplayMessage("Enter new source/category :");
                                tracker.Category = this._trackerView.ReadInput();
                                if (InputValidator.ValidateCategory(tracker.Category))
                                {
                                    break;
                                }

                                this._trackerView.DisplayMessage("Invalid input for source/category.\nEnter again :");
                            }

                            break;
                        case EditMenu.Amount:
                            while (true)
                            {
                                this._trackerView.DisplayMessage("Enter new amount :");
                                tracker.Amount = this.GetAmount();
                                if (InputValidator.ValidateAmount(tracker.Amount))
                                {
                                    break;
                                }

                                this._trackerView.DisplayMessage("Invalid input for amount. Amount cannot be negative or null.\nEnter again :");
                            }

                            break;
                        case EditMenu.Date:
                            while (true)
                            {
                                this._trackerView.DisplayMessage("Enter new date :");
                                tracker.Date = this.GetDate();
                                if (InputValidator.ValidateDate(tracker.Date))
                                {
                                    break;
                                }

                                this._trackerView.DisplayMessage("Invalid input for date. Date cannot be in future.\nEnter again :");
                            }

                            break;
                        default:
                            this._trackerView.DisplayMessage("Invalid input for choice\nPlease enter from [1 to 4].");
                            break;
                    }
                }
                while (menu != EditMenu.Exit);

                this._trackerManager.UpdateTransaction(tracker);
                this._trackerView.DisplayMessage("Update successful");
            }
        }

        private void DeleteRecord()
        {
            List<TrackerInfo> records = (List<TrackerInfo>)this._trackerManager.GetAllTransactions();
            if (records.Count == 0)
            {
                this._trackerView.DisplayMessage("Tracker is empty.");
                return;
            }

            this._trackerView.DisplayTracker(records);

            this._trackerView.DisplayMessage("Enter the serial number of the record to edit :");
            int serialNumber = this.GetChoice();
            if (serialNumber < 0 || serialNumber > records.Count)
            {
                this._trackerView.DisplayMessage($"There is no record with the serial number :{serialNumber}");
            }
            else
            {
                Guid selectedId = (Guid)records[serialNumber - 1].Id;
                TrackerInfo? tracker = this._trackerManager.GetByGuid(selectedId);
                bool removed = this._trackerManager.DeleteTransaction(tracker);
                if (removed)
                {
                    this._trackerView.DisplayMessage($"Record :{serialNumber} deleted successfully.");
                }
                else
                {
                    this._trackerView.DisplayMessage("Deletion failed.");
                }
            }
        }

        private void RetrieveSummary()
        {
            List<TrackerInfo> records = (List<TrackerInfo>)this._trackerManager.GetAllTransactions();
            if (records.Count == 0)
            {
                this._trackerView.DisplayMessage("Tracker has no records.");
                return;
            }

            decimal totalIncome = this._trackerManager.GetTotalIncome(records);
            decimal totalExpense = this._trackerManager.GetTotalExpense(records);
            decimal netBalance = this._trackerManager.TotalNetBalance(records);

            if (totalIncome < totalExpense)
            {
                this._trackerView.DisplayMessage("You have spent more than your income.");
                this._trackerView.DisplaySummary(totalIncome, totalExpense, netBalance);
            }
            else
            {
                this._trackerView.DisplaySummary(totalIncome, totalExpense, netBalance);
            }
        }

        private int GetChoice()
        {
            return this.GetValue<int>(int.TryParse, "Invalid choice\nPlease enter valid choice from the menu.");
        }

        private decimal GetAmount()
        {
            return this.GetValue<decimal>(decimal.TryParse, "Invalid entry for amount.\nPlease enter again :");
        }

        private DateOnly GetDate()
        {
            return this.GetValue<DateOnly>(DateOnly.TryParse, "Invalid entry for date.\nDate should be in (dd/mm/yyyy) format.\nPlease enter again :");
        }

        private T GetValue<T>(TryParseHandler<T> tryParse, string errorMessage)
        {
            while (true)
            {
                if (tryParse(this._trackerView.ReadInput(), out T value))
                {
                    return value;
                }

                this._trackerView.DisplayMessage(errorMessage);
            }
        }

        private void AddRecord(RecordType recordType, string fieldName, string recordName, string exampleMessage)
        {
            string? category;
            decimal amount;
            DateOnly date;
            while (true)
            {
                this._trackerView.DisplayMessage($"Enter {fieldName} of the {recordName} :");
                category = this._trackerView.ReadInput();

                if (InputValidator.ValidateCategory(category))
                {
                    break;
                }

                if (category != category?.Trim())
                {
                    this._trackerView.DisplayMessage("Entry should not contain leading or trailing whitespace.");
                    continue;
                }

                this._trackerView.DisplayMessage($"Enter valid {fieldName}.\n{exampleMessage}");
            }

            while (true)
            {
                this._trackerView.DisplayMessage($"Enter amount of {recordName} :");
                amount = this.GetAmount();

                if (InputValidator.ValidateAmount(amount))
                {
                    break;
                }

                this._trackerView.DisplayMessage("Enter valid amount.\nEnter again :");
            }

            while (true)
            {
                this._trackerView.DisplayMessage($"Enter the date of {recordName} (eg: dd/mm/yyyy) :");
                date = this.GetDate();

                if (InputValidator.ValidateDate(date))
                {
                    break;
                }

                this._trackerView.DisplayMessage("Please enter valid date\nDate cannot be in future.");
            }

            TrackerInfo tracker = new (recordType, category, amount, date);
            this._trackerManager.AddNewTransaction(tracker);
            this._trackerView.DisplayMessage("Record added successfully!");
        }
    }
}
