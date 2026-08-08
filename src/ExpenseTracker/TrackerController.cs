using ExpenseTracker.Core.Model;
using ExpenseTracker.Core.Model.Enum;
using ExpenseTracker.Core.TrackerInterface;
using ExpenseTracker.Helper;
using ExpenseTracker.Service;
using ExpenseTracker.View;

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
            string? source;
            decimal amount;
            DateOnly date;

            while (true)
            {
                this._trackerView.DisplayMessage("Enter source of the income :");
                source = this._trackerView.ReadInput();

                if (source != source?.Trim())
                {
                    this._trackerView.DisplayMessage("Source should not contain leading or trailing whitespace.");
                    continue;
                }

                if (InputValidator.ValidateCategory(source))
                {
                    break;
                }

                this._trackerView.DisplayMessage("Enter valid source.\n(Eg: salary, freelance, etc.)");
            }

            while (true)
            {
                this._trackerView.DisplayMessage("Enter amount of income :");
                amount = this.GetAmount();

                if (InputValidator.ValidateAmount(amount))
                {
                    break;
                }

                this._trackerView.DisplayMessage("Enter valid amount.\nEnter again :");
            }

            while (true)
            {
                this._trackerView.DisplayMessage("Enter the date of income (eg: dd/mm/yyyy) :");
                date = this.GetDate();

                if (InputValidator.ValidateDate(date))
                {
                    break;
                }

                this._trackerView.DisplayMessage("Please enter valid date\nDate cannot be in future.");
            }

            TrackerInfo tracker = new ("Income", source, amount, date);
            this._trackerManager.AddNewTransaction(tracker);
        }

        private void AddExpense()
        {
            string? category;
            decimal amount;
            DateOnly date;

            while (true)
            {
                this._trackerView.DisplayMessage("Enter category of the expense :");
                category = this._trackerView.ReadInput();

                if (InputValidator.ValidateCategory(category))
                {
                    break;
                }

                if (category != category?.Trim())
                {
                    this._trackerView.DisplayMessage("Category should not contain leading or trailing whitespace.");
                    continue;
                }

                this._trackerView.DisplayMessage("Enter valid source.\n(Eg: food, transport, etc.)");
            }

            while (true)
            {
                this._trackerView.DisplayMessage("Enter amount of expense :");
                amount = this.GetAmount();

                if (InputValidator.ValidateAmount(amount))
                {
                    break;
                }

                this._trackerView.DisplayMessage("Enter valid amount.\nEnter again :");
            }

            while (true)
            {
                this._trackerView.DisplayMessage("Enter the date of expense (eg: dd/mm/yyyy) :");
                date = this.GetDate();

                if (InputValidator.ValidateDate(date))
                {
                    break;
                }

                this._trackerView.DisplayMessage("Please enter valid date\nDate cannot be in future.");
            }

            TrackerInfo tracker = new ("Expense", category, amount, date);
            this._trackerManager.AddNewTransaction(tracker);
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
            while (true)
            {
                if (int.TryParse(this._trackerView.ReadInput(), out int value))
                {
                    return value;
                }
                else
                {
                    this._trackerView.DisplayMessage("Invalid entry.\nEnter again :");
                }
            }
        }

        private decimal GetAmount()
        {
            while (true)
            {
                if (decimal.TryParse(this._trackerView.ReadInput(), out decimal value))
                {
                    return value;
                }
                else
                {
                    this._trackerView.DisplayMessage("Invalid entry for amount.\nPlease enter again :");
                }
            }
        }

        private DateOnly GetDate()
        {
            while (true)
            {
                if (DateOnly.TryParse(this._trackerView.ReadInput(), out DateOnly value))
                {
                    return value;
                }
                else
                {
                    this._trackerView.DisplayMessage("Invalid entry for date.\nDate should be in (dd/mm/yyyy) format.\nPlease enter again :");
                }
            }
        }
    }
}
