using ExpenseTracker.Helper;
using ExpenseTracker.Model;
using ExpenseTracker.Model.Enum;
using ExpenseTracker.Service;
using ExpenseTracker.View;

namespace ExpenseTracker
{
    /// <summary>
    /// Controls the data flow between the service logic and view components.
    /// </summary>
    public class TrackerController
    {
        private readonly TrackerView _trackerView;
        private readonly TrackerManager _trackerManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackerController"/> class.
        /// </summary>
        /// <param name="trackerView">The console view instance used for user interaction.</param>
        /// <param name="trackerManager">The project manager instance used for managing inventory data.</param>
        public TrackerController(TrackerView trackerView, TrackerManager trackerManager)
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
                        break;
                    case TrackerMenu.Delete:
                        break;
                    case TrackerMenu.Exit:
                        break;
                    default:
                        this._trackerView.ShowMessage("Please enter valid choice from [1 to 3].");
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
                this._trackerView.ShowMessage("Enter source of the income :");
                source = this._trackerView.ReadInput();

                if (InputValidator.ValidateCategory(source))
                {
                    break;
                }

                this._trackerView.ShowMessage("Enter valid source.\n(Eg: salary, freelance, etc.)");
            }

            while (true)
            {
                this._trackerView.ShowMessage("Enter amount of income :");
                amount = this.GetAmount();

                if (InputValidator.ValidateAmount(amount))
                {
                    break;
                }

                this._trackerView.ShowMessage("Enter valid amount.\nEnter again :");
            }

            while (true)
            {
                this._trackerView.ShowMessage("Enter the date of income (eg: dd/mm/yyyy) :");
                date = this.GetDate();

                if (InputValidator.ValidateDate(date))
                {
                    break;
                }

                this._trackerView.ShowMessage("Please enter valid date\nDate cannot be in future.");
            }

            TrackerInfo tracker = new TrackerInfo("Income", source, amount, date);
            this._trackerManager.AddNewTransaction(tracker);
        }

        private void AddExpense()
        {
            string? category;
            decimal amount;
            DateOnly date;

            while (true)
            {
                this._trackerView.ShowMessage("Enter category of the expense :");
                category = this._trackerView.ReadInput();

                if (InputValidator.ValidateCategory(category))
                {
                    break;
                }

                this._trackerView.ShowMessage("Enter valid source.\n(Eg: food, transport, etc.)");
            }

            while (true)
            {
                this._trackerView.ShowMessage("Enter amount of expense :");
                amount = this.GetAmount();

                if (InputValidator.ValidateAmount(amount))
                {
                    break;
                }

                this._trackerView.ShowMessage("Enter valid amount.\nEnter again :");
            }

            while (true)
            {
                this._trackerView.ShowMessage("Enter the date of expense (eg: dd/mm/yyyy) :");
                date = this.GetDate();

                if (InputValidator.ValidateDate(date))
                {
                    break;
                }

                this._trackerView.ShowMessage("Please enter valid date\nDate cannot be in future.");
            }

            TrackerInfo tracker = new TrackerInfo("Expense", category, amount, date);
            this._trackerManager.AddNewTransaction(tracker);
        }

        private void ViewTracker()
        {
            List<TrackerInfo> tracker = (List<TrackerInfo>)this._trackerManager.GetAllTransactions();
            this._trackerView.DisplayTracker(tracker);
        }

        private void EditTracker()
        {
            List<TrackerInfo> trackerInfo = (List<TrackerInfo>)this._trackerManager.GetAllTransactions();
            if (trackerInfo.Count == 0)
            {
                this._trackerView.ShowMessage("Tracker is empty.");
                return;
            }

            this._trackerView.ShowMessage("Enter which section you need to edit :");

            this._trackerView.ShowMessage("Enter the serial number of the record to edit :");

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
                    this._trackerView.ShowMessage("Invalid entry for choice.\nEnter again :");
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
                    this._trackerView.ShowMessage("Invalid entry for amount.\nPlease enter again :");
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
                    this._trackerView.ShowMessage("Invalid entry for date.\nPlease enter again :");
                }
            }
        }
    }
}
