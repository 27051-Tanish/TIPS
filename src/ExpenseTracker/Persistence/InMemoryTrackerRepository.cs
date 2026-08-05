using ExpenseTracker.Model;
using ExpenseTracker.Model.Enum;

namespace ExpenseTracker.Persistence
{
    /// <summary>
    /// Provides in-memory storage for tracking financial transactions.
    /// </summary>
    public class InMemoryTrackerRepository
    {
        private readonly List<TrackerInfo> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryTrackerRepository"/> class.
        /// </summary>
        public InMemoryTrackerRepository()
        {
            this._repository = new List<TrackerInfo>();
        }

        /// <summary>
        /// Add a new transaction record to the list.
        /// </summary>
        /// <param name="trackerInfo">The transaction record to be added.</param>
        public void AddTransactions(TrackerInfo trackerInfo)
        {
            this._repository.Add(trackerInfo);
        }

        /// <summary>
        /// Remove a existing transaction record from the list.
        /// </summary>
        /// <param name="trackerInfo">Transaction needed to be deleted.</param>
        public void RemoveTransactions(TrackerInfo trackerInfo)
        {
            this._repository.Remove(trackerInfo);
        }

        /// <summary>
        /// Copies the in-memory repository to a duplicate list.
        /// </summary>
        /// <returns>The copied list of transaction record.</returns>
        public List<TrackerInfo> GetTransactions()
        {
            return this._repository;
        }

        /// <summary>
        /// Retrieves the particular transaction using unique id.
        /// </summary>
        /// <param name="id">Id of the transaction.</param>
        /// <returns>The particular transaction.</returns>
        public TrackerInfo GetById(Guid id)
        {
            return this._repository.Find(i => i.Id == id);
        }

        /// <summary>
        /// Update the transaction details.
        /// </summary>
        /// <param name="transaction">The transaction that needed to be updated.</param>
        public void UpdateTracker(TrackerInfo transaction)
        {
            TrackerInfo oldTransaction = this.GetById(transaction.Id);

            if (oldTransaction != null)
            {
                oldTransaction.Category = transaction.Category;
                oldTransaction.Amount = transaction.Amount;
                oldTransaction.Date = transaction.Date;
            }
        }
    }
}
