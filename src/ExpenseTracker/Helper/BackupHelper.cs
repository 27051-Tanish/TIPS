using System.IO;

namespace ExpenseTracker.Helper
{
    /// <summary>
    /// Defines functionality for creating backups.
    /// </summary>
    public static class BackupHelper
    {
        private static readonly string BackupPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "Records_backup.csv");

        /// <summary>
        /// Performs the backup operation.
        /// </summary>
        /// <param name="filePath">File path of the original file.</param>
        public static void Backup(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            File.Copy(filePath, BackupPath, true);
        }
    }
}