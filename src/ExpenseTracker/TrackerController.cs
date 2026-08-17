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
                choiceValue = this._trackerView.GetChoice();
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
                    case TrackerMenu.Backup:
                        this.PerformBackup();
                        break;
                    case TrackerMenu.Exit:
                        break;
                    default:
                        this._trackerView.DisplayMessage("Please enter valid choice from [1 to 8].\nEnter your choice again :");
                        break;
                }
            }
            while (menu != TrackerMenu.Exit);
        }

        private void AddIncome() => this.AddRecord(RecordType.Income, "source", "income", "(Eg: salary, freelance, etc.)");

        private void AddExpense() => this.AddRecord(RecordType.Expense, "category", "expense", "(Eg: food, transport, etc.)");

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
            int serialNumber = this._trackerView.GetChoice();

            if (serialNumber < 1 || serialNumber > records.Count)
            {
                Logger.WriteLog("FAILURE", "Trying to edit record that is not present in the tracker.");
                this._trackerView.DisplayMessage($"There is no record with the serial number :{serialNumber}");
                return;
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
                    choice = this._trackerView.GetChoice();
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
                                    this._trackerView.DisplayMessage($"Source/category updated successfully");
                                    break;
                                }

                                this._trackerView.DisplayMessage("Invalid input for source/category.\nEnter again :");
                            }

                            break;
                        case EditMenu.Amount:
                            while (true)
                            {
                                this._trackerView.DisplayMessage("Enter new amount :");
                                tracker.Amount = this._trackerView.GetAmount();
                                if (InputValidator.ValidateAmount(tracker.Amount))
                                {
                                    this._trackerView.DisplayMessage($"Amount updated successfully");
                                    break;
                                }

                                this._trackerView.DisplayMessage("Invalid input for amount. Amount cannot be negative or null.\nEnter again :");
                            }

                            break;
                        case EditMenu.Date:
                            while (true)
                            {
                                this._trackerView.DisplayMessage("Enter new date :");
                                tracker.Date = this._trackerView.GetDate();
                                if (InputValidator.ValidateDate(tracker.Date))
                                {
                                    this._trackerView.DisplayMessage($"Date updated successfully");
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
                Logger.WriteLog("SUCCESS", $"Record: {serialNumber} updated successfully ");
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
            int serialNumber = this._trackerView.GetChoice();
            if (serialNumber < 1 || serialNumber > records.Count)
            {
                Logger.WriteLog("FAILURE", "Trying to delete record that is not present in the tracker.");
                this._trackerView.DisplayMessage($"There is no record with the serial number :{serialNumber}");
                return;
            }
            else
            {
                Guid selectedId = (Guid)records[serialNumber - 1].Id;
                TrackerInfo? tracker = this._trackerManager.GetByGuid(selectedId);
                bool removed = this._trackerManager.DeleteTransaction(tracker);
                if (removed)
                {
                    Logger.WriteLog("SUCCESS", $"Record: {serialNumber} deleted successfully ");
                    this._trackerView.DisplayMessage($"Record :{serialNumber} deleted successfully.");
                }
                else
                {
                    Logger.WriteLog("FAILURE", $"Record: {serialNumber} deletion failed.");
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
                Logger.WriteLog("WARNING", "Expense is more than income.");
                this._trackerView.DisplayMessage("You have spent more than your income.");
                this._trackerView.DisplaySummary(totalIncome, totalExpense, netBalance);
            }
            else
            {
                this._trackerView.DisplaySummary(totalIncome, totalExpense, netBalance);
            }
        }

        private void PerformBackup()
        {
            this._trackerManager.BackupRecords();
            Logger.WriteLog("SUCCESS", "Backup created successfully.");
            this._trackerView.DisplayMessage("Backup created successfully.");
        }

        private void AddRecord(RecordType recordType, string fieldName, string recordName, string exampleMessage)
        {
            string? category;
            decimal amount;
            DateOnly date;
            try
            {
                category = this.GetCategoryInput(fieldName, recordName, exampleMessage);
                amount = this.GetAmountInput(recordName);
                date = this.GetDateInput(recordName);
            }
            catch (InvalidOperationException ex)
            {
                this._trackerView.DisplayMessage($"Error :{ex.Message}");
                return;
            }

            TrackerInfo tracker = new (recordType, category, amount, date);
            this._trackerManager.AddNewTransaction(tracker);
            Logger.WriteLog("SUCCESS", "Record added successfully");
            this._trackerView.DisplayMessage("Record added successfully!");
        }

        private string GetCategoryInput(string fieldName, string recordName, string exampleMessage)
        {
            string? category;
            int attempt = 0;

            while (attempt < ConstantVariables.MaxLimit)
            {
                this._trackerView.DisplayMessage($"Enter {fieldName} of the {recordName} :");
                category = this._trackerView.ReadInput();

                if (InputValidator.ValidateCategory(category))
                {
                    return category;
                }

                attempt++;

                if (category != category?.Trim())
                {
                    this._trackerView.DisplayMessage("Entry should not contain leading or trailing whitespace.");
                }
                else
                {
                    this._trackerView.DisplayMessage($"Enter valid {fieldName}.\n{exampleMessage}");
                }

                if (attempt < ConstantVariables.MaxLimit)
                {
                    this._trackerView.DisplayMessage($"Attempts remaining : {ConstantVariables.MaxLimit - attempt}");
                }
            }

            Logger.WriteLog("FAILURE", "Maximum re-try limit reached for getting source/category as input.");
            throw new InvalidOperationException($"Maximum limit reached.");
        }

        private decimal GetAmountInput(string recordName)
        {
            decimal amount;
            int attempt = 0;
            while (attempt < ConstantVariables.MaxLimit)
            {
                this._trackerView.DisplayMessage($"Enter amount of {recordName} :");
                amount = this._trackerView.GetAmount();

                if (InputValidator.ValidateAmount(amount))
                {
                    return amount;
                }

                attempt++;
                this._trackerView.DisplayMessage("Enter valid amount.\nEnter again :");
                this._trackerView.DisplayMessage($"Attempts remaining : {ConstantVariables.MaxLimit - attempt}");
            }

            Logger.WriteLog("FAILURE", "Maximum re-try limit reached for getting amount as input.");
            throw new InvalidOperationException("Maximum limit reached.");
        }

        private DateOnly GetDateInput(string recordName)
        {
            DateOnly date;
            int attempt = 0;
            while (attempt < ConstantVariables.MaxLimit)
            {
                this._trackerView.DisplayMessage($"Enter the date of {recordName} (eg: dd/mm/yyyy) :");
                date = this._trackerView.GetDate();

                if (InputValidator.ValidateDate(date))
                {
                    return date;
                }

                attempt++;
                this._trackerView.DisplayMessage("Please enter valid date\nDate cannot be in future.");
                this._trackerView.DisplayMessage($"Attempts remaining : {ConstantVariables.MaxLimit - attempt}");
            }

            Logger.WriteLog("FAILURE", "Maximum re-try limit reached for getting date as input.");
            throw new InvalidOperationException("Maximum limit reached.");
        }
    }
}
