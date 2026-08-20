using ExpenseTracker.Core.Model;
using ExpenseTracker.Core.TrackerInterface;

namespace ExpenseTracker.Persistence
{
    /// <summary>
    /// Provides in-memory storage for tracking financial transactions.
    /// </summary>
    public class InMemoryTrackerRepository : ITrackerRepository
    {
        private readonly List<TrackerInfo> _records;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryTrackerRepository"/> class.
        /// </summary>
        public InMemoryTrackerRepository()
        {
            this._records = new List<TrackerInfo>();
        }

        /// <inheritdoc/>
        public void AddTransaction(TrackerInfo trackerInfo)
        {
            this._records.Add(trackerInfo);
        }

        /// <inheritdoc/>
        public void RemoveTransaction(TrackerInfo trackerInfo)
        {
            this._records.Remove(trackerInfo);
        }

        /// <inheritdoc/>
        public List<TrackerInfo> GetTransactions()
        {
            return this._repository.OrderBy(records => records.Date).ToList();
        }

        /// <inheritdoc/>
        public TrackerInfo? GetById(Guid id)
        {
            return this._records.Find(i => i.Id == id);
        }

        /// <inheritdoc/>
        public void UpdateTracker(TrackerInfo transaction)
        {
            TrackerInfo? oldTransaction = this.GetById(transaction.Id);

            if (oldTransaction != null)
            {
                oldTransaction.Amount = transaction.Amount;
                oldTransaction.Date = transaction.Date;

                if (oldTransaction is Income oldIncome && transaction is Income newIncome)
                {
                    oldIncome.Source = newIncome.Source;
                }
                else if (oldTransaction is Expense oldExpense && transaction is Expense newExpense)
                {
                    oldExpense.Category = newExpense.Category;
                }
            }
        }
    }
}
