using ExpenseTracker.Core.Model;

namespace ExpenseTracker.Core.TrackerInterface
{
    /// <summary>
    /// Defines contract for data access operation on tracker records.
    /// </summary>
    public interface IFileRepository : ITrackerRepository
    {
        /// <summary>
        /// Writes the entire record details in the file.
        /// </summary>
        /// <param name="records">The record details to be written in the file.</param>
        void SaveRecord(List<TrackerInfo> records);

        /// <summary>
        /// Creates a backup copy of the current record file.
        /// </summary>
        void FileBackup();
    }
}
