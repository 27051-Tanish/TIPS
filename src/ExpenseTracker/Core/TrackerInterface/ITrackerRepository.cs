using ExpenseTracker.Core.Model;

namespace ExpenseTracker.Core.TrackerInterface
{
    /// <summary>
    /// Defines a contract for data access operation on tracker records.
    /// </summary>
    public interface ITrackerRepository
    {
         /// <summary>
         /// Adds new tracker information to the record.
         /// </summary>
         /// <param name="trackerInfo">The record that needs to be added to the tracker.</param>
         void AddTransaction(TrackerInfo trackerInfo);

         /// <summary>
         /// Removes the tracker information from the record.
         /// </summary>
         /// <param name="trackerInfo">The record that needs to be removed from the tracker.</param>
         void RemoveTransaction(TrackerInfo trackerInfo);

         /// <summary>
         /// Retrieves the tracker information from the record.
         /// </summary>
         /// <returns>The tracker records information.</returns>
         List<TrackerInfo> GetTransactions();

         /// <summary>
         /// Retrieves the particular tracker record by unique id.
         /// </summary>
         /// <param name="id">The unique id of the tracker record.</param>
         /// <returns>The tracker record of the id.</returns>
         TrackerInfo? GetById(Guid id);

         /// <summary>
         /// Update the tracker records.
         /// </summary>
         /// <param name="transaction">The tracker record that needs to be edited.</param>
         void UpdateTracker(TrackerInfo transaction);
    }
}
