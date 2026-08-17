using ExpenseTracker.Core.Model;
using ExpenseTracker.Core.Model.Enum;
using ExpenseTracker.Core.TrackerInterface;

namespace ExpenseTracker.Service
{
    /// <summary>
    /// Manages core CRUD operations and calculations for financial tracking records.
    /// </summary>
    public class TrackerManager
    {
        private readonly IFileRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackerManager"/> class.
        /// </summary>
        /// <param name="repository">Contract of the data repository.</param>
        public TrackerManager(IFileRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Add new transaction details to the record.
        /// </summary>
        /// <param name="transaction">Transaction to be added.</param>
        public void AddNewTransaction(TrackerInfo transaction)
        {
            transaction.Id = Guid.NewGuid();
            this._repository.AddTransaction(transaction);
        }

        /// <summary>
        /// Delete transaction detail from the record.
        /// </summary>
        /// <param name="transaction">Transaction to be deleted.</param>
        /// <returns>True if the transaction details deleted, otherwise false.</returns>
        public bool DeleteTransaction(TrackerInfo? transaction)
        {
            TrackerInfo? tracker = this._repository.GetById(transaction.Id);

            if (tracker != null)
            {
                this._repository.RemoveTransaction(tracker);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves the record from the tracker by unique id.
        /// </summary>
        /// <param name="id">The unique id of the record.</param>
        /// <returns>The record from the tracker of the given id.</returns>
        public TrackerInfo? GetByGuid(Guid id)
        {
            return this._repository.GetById(id);
        }

        /// <summary>
        /// Update the details of the given transaction type in the tracker.
        /// </summary>
        /// <param name="transaction">Transaction which needed to be edited.</param>
        public void UpdateTransaction(TrackerInfo transaction)
        {
            this._repository.UpdateTracker(transaction);
        }

        /// <summary>
        /// Get all the transaction details from the tracker.
        /// </summary>
        /// <returns>The list of tracking record.</returns>
        public List<TrackerInfo> GetAllTransactions()
        {
            return this._repository.GetTransactions();
        }

        /// <summary>
        /// Copies all the record details to a new backup file.
        /// </summary>
        public void BackupRecords()
        {
            this._repository.FileBackup();
        }

        /// <summary>
        /// Gets the total sum of the income.
        /// </summary>
        /// <param name="trackerInfos">The list of tracking record.</param>
        /// <returns>The total income from the tracker.</returns>
        public decimal GetTotalIncome(List<TrackerInfo> trackerInfos)
        {
            decimal totalIncome = 0;
            foreach (var transaction in trackerInfos)
            {
                if (transaction.Type == RecordType.Income)
                {
                    totalIncome += transaction.Amount;
                }
            }

            return totalIncome;
        }

        /// <summary>
        /// Gets the total sum of the expense.
        /// </summary>
        /// <param name="trackerInfos">The list of tracking record.</param>
        /// <returns>The total income from the tracker.</returns>
        public decimal GetTotalExpense(List<TrackerInfo> trackerInfos)
        {
            decimal totalExpense = 0;
            foreach (var transaction in trackerInfos)
            {
                if (transaction.Type == RecordType.Expense)
                {
                    totalExpense += transaction.Amount;
                }
            }

            return totalExpense;
        }

        /// <summary>
        /// Calculates the net balance of the tracker record.
        /// </summary>
        /// <param name="trackerInfos">The list of tracking record.</param>
        /// <returns>The difference of the income and expense.</returns>
        public decimal TotalNetBalance(List<TrackerInfo> trackerInfos)
        {
            return this.GetTotalIncome(trackerInfos) - this.GetTotalExpense(trackerInfos);
        }
    }
}
