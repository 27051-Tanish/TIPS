using System.IO;

namespace ExpenseTracker.Helper
{
    /// <summary>
    /// Logs success, error, and informational messages to a local file.
    /// </summary>
    public static class Logger
    {
        private static readonly string _logFile = "tracker_log.txt";

        /// <summary>
        /// Writes a message to a log file with current time.
        /// </summary>
        /// <param name="messageType">Type of message.</param>
        /// <param name="message">The message to be displayed.</param>
        public static void WriteLog(string messageType, string message)
        {
            string log =
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] " +
                $"[{messageType}] {message}{Environment.NewLine}";

            File.AppendAllText(_logFile, log);
        }
    }
}
