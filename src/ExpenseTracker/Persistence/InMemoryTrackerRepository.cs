using ExpenseTracker.Core.Model;
using ExpenseTracker.Core.TrackerInterface;

namespace ExpenseTracker.Persistence
{
    /// <summary>
    /// Provides in-memory storage for tracking financial transactions.
    /// </summary>
    public class InMemoryTrackerRepository : ITrackerRepository
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
        /// Add a new tracker information to the record.
        /// </summary>
        /// <param name="trackerInfo">The tracker record to be added.</param>
        public void AddTransactions(TrackerInfo trackerInfo)
        {
            this._repository.Add(trackerInfo);
        }

        /// <summary>
        /// Remove a existing tracker record from the list.
        /// </summary>
        /// <param name="trackerInfo">Tracker record needed to be deleted.</param>
        public void RemoveTransactions(TrackerInfo trackerInfo)
        {
            this._repository.Remove(trackerInfo);
        }

        /// <summary>
        /// Retrieves the tracker records information.
        /// </summary>
        /// <returns>The list of transaction record.</returns>
        public List<TrackerInfo> GetTransactions()
        {
            return this._repository;
        }

        /// <summary>
        /// Retrieves the particular tracker record using unique id.
        /// </summary>
        /// <param name="id">Id of the tracker record.</param>
        /// <returns>The particular tracker record.</returns>
        public TrackerInfo? GetById(Guid id)
        {
            return this._repository.Find(i => i.Id == id);
        }

        /// <summary>
        /// Update the tracker details.
        /// </summary>
        /// <param name="transaction">The record that needed to be updated.</param>
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
