using ExpenseTracker.Core.Model;
using ExpenseTracker.Core.Model.Enum;
using ExpenseTracker.Core.TrackerInterface;
using ExpenseTracker.Helper;

namespace ExpenseTracker.Persistence
{
    /// <summary>
    /// Provides file storage for tracking monetary records.
    /// </summary>
    public class TrackerFile : ITrackerRepository, IFileRepository
    {
        private const string Header = "Id,Type,Category/Source,Amount,Date";
        private readonly string _filePath = "records.csv";

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackerFile"/> class.
        /// </summary>
        public TrackerFile()
        {
            if (!File.Exists(this._filePath))
            {
                File.WriteAllLines(this._filePath, new[] { Header });
            }
        }

        /// <inheritdoc/>
        public void AddTransaction(TrackerInfo trackerInfo)
        {
            string record = $"{trackerInfo.Id},{trackerInfo.Type},{trackerInfo.Category},{trackerInfo.Amount},{trackerInfo.Date}";
            File.AppendAllText(this._filePath, record + Environment.NewLine);
        }

        /// <inheritdoc/>
        public TrackerInfo? GetById(Guid id)
        {
            return this.GetTransactions().Find(t => t.Id == id);
        }

        /// <inheritdoc/>
        public List<TrackerInfo> GetTransactions()
        {
            List<TrackerInfo> records = new ();
            if (!File.Exists(this._filePath))
            {
                return records;
            }

            string[] lines = File.ReadAllLines(this._filePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line == Header)
                {
                    continue;
                }

                string[] data = line.Split(',');

                if (data.Length < 5)
                {
                    continue;
                }

                if (Guid.TryParse(data[0].Trim(), out Guid id) &&
                    Enum.TryParse(data[1].Trim(), out RecordType type) &&
                    decimal.TryParse(data[3].Trim(), out decimal amount) &&
                    DateOnly.TryParse(data[4].Trim(), out DateOnly date))
                {
                    records.Add(new TrackerInfo(type, data[2].Trim(), amount, date) { Id = id });
                }
            }

            return records;
        }

        /// <inheritdoc/>
        public void RemoveTransaction(TrackerInfo trackerInfo)
        {
            List<TrackerInfo> records = this.GetTransactions();
            TrackerInfo? recordToRemove = records.Find(t => t.Id == trackerInfo.Id);
            if (recordToRemove != null)
            {
                records.Remove(recordToRemove);
                this.SaveRecord(records);
            }
        }

        /// <inheritdoc/>
        public void SaveRecord(List<TrackerInfo> records)
        {
            List<string> lines = new List<string> { Header };
            foreach (TrackerInfo trackerInfo in records)
            {
                lines.Add($"{trackerInfo.Id},{trackerInfo.Type},{trackerInfo.Category},{trackerInfo.Amount},{trackerInfo.Date}");
            }

            File.WriteAllLines(this._filePath, lines);
        }

        /// <inheritdoc/>
        public void UpdateTracker(TrackerInfo trackerInfo)
        {
            List<TrackerInfo> records = this.GetTransactions();
            TrackerInfo? record = records.FirstOrDefault(t => t.Id == trackerInfo.Id);
            if (record != null)
            {
                record.Category = trackerInfo.Category;
                record.Amount = trackerInfo.Amount;
                record.Date = trackerInfo.Date;
                this.SaveRecord(records);
            }
        }

        /// <inheritdoc/>
        public void FileBackup()
        {
            BackupHelper.Backup(this._filePath);
        }
    }
}
