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

        /// <summary>
        /// Add new income record to the tracker.
        /// </summary>
        private void AddIncome()
        {
            this.AddRecord(RecordType.Income, "source", "income", "(Eg: salary, freelance, etc.)");
        }

        /// <summary>
        /// Add new expense record to the tracker.
        /// </summary>
        private void AddExpense()
        {
            this.AddRecord(RecordType.Expense, "category", "expense", "(Eg: food, transport, etc.)");
        }

        /// <summary>
        /// Display all the records of the tracker.
        /// </summary>
        private void ViewTracker()
        {
            List<TrackerInfo> tracker = this._trackerManager.GetAllTransactions();
            if (tracker.Count == 0)
            {
                this._trackerView.DisplayMessage("Tracker is empty.");
                return;
            }

            int choice;
            ViewMenu menu;
            do
            {
                this._trackerView.DisplayMessage("[1]. View income records\n[2]. View expense record\n[3]. View entire record\n[4]. Exit");
                choice = this._trackerView.GetChoice();
                menu = (ViewMenu)choice;
                switch (menu)
                {
                    case ViewMenu.IncomeRecord:
                        this._trackerView.DisplayIncome(tracker);
                        break;
                    case ViewMenu.ExpenseRecord:
                        this._trackerView.DisplayExpense(tracker);
                        break;
                    case ViewMenu.EntireRecord:
                        this._trackerView.DisplayTracker(tracker);
                        break;
                    case ViewMenu.Exit:
                        this._trackerView.DisplayMessage("Closing view menu...");
                        break;
                    default:
                        this._trackerView.DisplayMessage("Invalid choice\nEnter from the menu [1 to 4]");
                        break;
                }
            }
            while (menu != ViewMenu.Exit);
        }

        /// <summary>
        /// Edit a particular record from the tracker.
        /// </summary>
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
                Logger.WriteLog("[WARNING]", "Trying to edit record that is not present in the tracker.");
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
                            if (tracker is Income incomeRecord)
                            {
                                incomeRecord.Source = this.GetSourceOrCategoryInput("source", "income", ConstantMessages.IncomeCategoryMessage);
                                this._trackerView.DisplayMessage($"Source updated successfully\nDo you want to edit anything or close edit menu :");
                            }
                            else if (tracker is Expense expenseRecord)
                            {
                                expenseRecord.Category = this.GetSourceOrCategoryInput("category", "expense", ConstantMessages.ExpenseCategoryMessage);
                                this._trackerView.DisplayMessage($"Category updated successfully\nDo you want to edit anything or close edit menu :");
                            }

                            break;
                        case EditMenu.Amount:
                            if (tracker is Income income)
                            {
                                tracker.Amount = this.GetAmountInput("income");
                                this._trackerView.DisplayMessage($"Amount updated successfully\n" +
                                            $"Do you want to edit anything or close edit menu :");
                            }
                            else if (tracker is Expense expense)
                            {
                                tracker.Amount = this.GetAmountInput("expense");
                                this._trackerView.DisplayMessage($"Amount updated successfully\n" +
                                            $"Do you want to edit anything or close edit menu :");
                            }

                            break;
                        case EditMenu.Date:
                            if (tracker is Income incomeType)
                            {
                                tracker.Date = this.GetDateInput("income");
                                this._trackerView.DisplayMessage($"Date updated successfully\n" +
                                            $"Do you want to edit anything or close edit menu :");
                            }
                            else if (tracker is Expense expense)
                            {
                                tracker.Date = this.GetDateInput("expense");
                                this._trackerView.DisplayMessage($"Date updated successfully\n" +
                                            $"Do you want to edit anything or close edit menu :");
                            }

                            break;
                        case EditMenu.Exit:
                            this._trackerView.DisplayMessage("Closing edit menu...");
                            break;
                        default:
                            this._trackerView.DisplayMessage("Invalid input for choice\nPlease enter from [1 to 4].");
                            break;
                    }
                }
                while (menu != EditMenu.Exit);

                this._trackerManager.UpdateTransaction(tracker);
                Logger.WriteLog("[INFO]", $"Record: {serialNumber} updated successfully ");
                this._trackerView.DisplayMessage("Update successful");
            }
        }

        /// <summary>
        /// Delete a particular record from the tracker.
        /// </summary>
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
                Logger.WriteLog("[WARNING]", "Trying to delete record that is not present in the tracker.");
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
                    Logger.WriteLog("[INFO]", $"Record: {serialNumber} deleted successfully ");
                    this._trackerView.DisplayMessage($"Record :{serialNumber} deleted successfully.");
                }
                else
                {
                    Logger.WriteLog("[ERROR]", $"Record: {serialNumber} deletion failed.");
                    this._trackerView.DisplayMessage("Deletion failed.");
                }
            }
        }

        /// <summary>
        /// Retrieves the total summary of the records in the tracker.
        /// </summary>
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
                Logger.WriteLog("[WARNING]", "Expense is more than income.");
                this._trackerView.DisplayMessage("You have spent more than your income.");
                this._trackerView.DisplaySummary(totalIncome, totalExpense, netBalance);
            }
            else
            {
                this._trackerView.DisplaySummary(totalIncome, totalExpense, netBalance);
            }
        }

        /// <summary>
        /// Takes all the details from the source file and takes a backup copy.
        /// </summary>
        private void PerformBackup()
        {
            List<TrackerInfo> tracker = this._trackerManager.GetAllTransactions();
            if (tracker.Count == 0)
            {
                Logger.WriteLog("[ERROR]", "Tracker is empty cannot create a backup.");
                this._trackerView.DisplayMessage("Tracker is empty cannot create a backup.");
                return;
            }

            this._trackerManager.BackupRecords();
            Logger.WriteLog("[INFO]", "Backup created successfully.");
            this._trackerView.DisplayMessage("Backup created successfully.");
        }

        /// <summary>
        /// Reuse method for adding new record to the tracker.
        /// </summary>
        /// <param name="recordType">The type of the record.</param>
        /// <param name="fieldName">The field name that is source or category.</param>
        /// <param name="recordName">The record name that is income or expense.</param>
        /// <param name="exampleMessage">The message to be displayed as an example.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception when the record type is not income or expense.</exception>
        private void AddRecord(RecordType recordType, string fieldName, string recordName, string exampleMessage)
        {
            string? input;
            decimal amount;
            DateOnly date;
            try
            {
                input = this.GetSourceOrCategoryInput(fieldName, recordName, exampleMessage);
                amount = this.GetAmountInput(recordName);
                date = this.GetDateInput(recordName);
            }
            catch (InvalidOperationException ex)
            {
                this._trackerView.DisplayMessage($"Error: {ex.Message}");
                return;
            }

            TrackerInfo tracker = recordType switch
            {
                RecordType.Income => new Income(Guid.NewGuid(), amount, date, input),
                RecordType.Expense => new Expense(Guid.NewGuid(), amount, date, input),
                _ => throw new ArgumentOutOfRangeException(nameof(recordType), $"Invalid record type: {recordType}")
            };

            this._trackerManager.AddNewTransaction(tracker);
            this._trackerView.DisplayMessage($"{recordType} record added successfully!");
        }

        /// <summary>
        /// Reusable method for getting source or category as input.
        /// </summary>
        /// <param name="fieldName">The field name that is source or category.</param>
        /// <param name="recordName">The type of the record.</param>
        /// <param name="exampleMessage">The message to be displayed as an example.</param>
        /// <returns>The source or category as the outcome.</returns>
        /// <exception cref="InvalidOperationException">Throws an exception when the user ran out of retries.</exception>
        private string GetSourceOrCategoryInput(string fieldName, string recordName, string exampleMessage)
        {
            string? input;
            int attempt = 0;

            while (attempt < ConstantVariables.MaxLimit)
            {
                this._trackerView.DisplayMessage($"Enter {fieldName} of the {recordName} :");
                input = this._trackerView.ReadInput();

                if (InputValidator.ValidateCategory(input))
                {
                    return input;
                }

                attempt++;

                if (input != input?.Trim())
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

            Logger.WriteLog("[ERROR]", "Maximum re-try limit reached for getting source/category as input.");
            throw new InvalidOperationException($"Maximum limit reached.");
        }

        /// <summary>
        /// Gets amount as an input from the user.
        /// </summary>
        /// <param name="recordName">The type of the record.</param>
        /// <returns>The amount of income or expense.</returns>
        /// <exception cref="InvalidOperationException">Throws an exception when the user ran out of retries.</exception>
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
                this._trackerView.DisplayMessage($"Enter valid amount.\nAmount limit : {ConstantVariables.MaxAmount}\nEnter again :");
                this._trackerView.DisplayMessage($"Attempts remaining : {ConstantVariables.MaxLimit - attempt}");
            }

            Logger.WriteLog("[ERROR]", "Maximum re-try limit reached for getting amount as input.");
            throw new InvalidOperationException("Maximum limit reached.");
        }

        /// <summary>
        /// Gets the date of the income or expense.
        /// </summary>
        /// <param name="recordName">The type of the record.</param>
        /// <returns>The date of occurrence of the transaction.</returns>
        /// <exception cref="InvalidOperationException">Throws an exception when the user ran out of retries.</exception>
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

            Logger.WriteLog("[ERROR]", "Maximum re-try limit reached for getting date as input.");
            throw new InvalidOperationException("Maximum limit reached.");
        }
    }
}
