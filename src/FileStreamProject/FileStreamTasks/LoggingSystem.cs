using System.Text;

namespace FileStreamProject.FileStreamTasks
{
    /// <summary>
    /// performs efficient, thread-safe logging system that can handle multiple users logging errors simultaneously without
    /// contention or significant performance degradation.
    /// </summary>
    public class LoggingSystem
    {
        // FIX: Changing this to static ensures all instances share the exact same lock boundary
        private static readonly object _lock = new object();
        private static string _logFilePath = "Data/Log/log.txt";

        private readonly string _userLogFolder = "Data/Log/Users";

        private readonly string _naiveLogFile = "Data/Log/NaiveUsers";

        /// <summary>
        /// Modify the LogError method to write directly to the file.
        /// </summary>
        /// <param name="errorMessage">The message to be written in the file.</param>
        public void ImproveFileWriting(string errorMessage)
        {
            byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);

            lock (_lock)
            {
                // [subtask 1] Fix of the starter code: Stream directly to disk, completely bypassing the redundant MemoryStream array copies.
                using (FileStream stream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write, FileShare.None))
                {
                    stream.Write(errorBytes, 0, errorBytes.Length);
                }
            }
        }

        /// <summary>
        /// Implement a locking mechanism to ensure that file write operations are thread safe when multiple users try to write.
        /// </summary>
        /// <param name="numberOfUsers">The total number of simulated concurrent user threads to spin up.</param>
        /// <param name="messagePerUser">The total number of messages per user.</param>
        public void ThreadSafeLogging(int numberOfUsers, int messagePerUser)
        {
            Parallel.For(0, numberOfUsers, i =>
            {
                int userId = i + 1;
                for (int messageId = 1; messageId <= messagePerUser; messageId++)
                {
                    this.LogThreadSafe(userId, messageId);
                }
            });
        }

        /// <summary>
        /// Creates a new logging file for each users and log the error message of each user in the specific file.
        /// </summary>
        /// /// <param name="numberOfUsers">The total number of simulated concurrent user threads to spin up.</param>
        /// <param name="messagePerUser">The total number of messages per user.</param>
        public void LogErrorNaive(int numberOfUsers, int messagePerUser)
        {
            Directory.CreateDirectory(this._naiveLogFile);

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < numberOfUsers; i++)
            {
                int userId = i + 1;

                Thread thread = new Thread(() =>
                {
                    string filePath =
                        Path.Combine(
                            this._userLogFolder,
                            $"user-{userId}.txt");

                    using (FileStream stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None, 4096))
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                    {
                        for (int messageId = 1; messageId <= messagePerUser; messageId++)
                        {
                            string message = $"{DateTime.Now} - User {userId} => with error ID: {messageId} Error";

                            writer.WriteLine(message);
                        }
                    }
                });

                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }

        /// <summary>
        /// Creates a new logging file for each users and log the error message of each user in the specific file.
        /// </summary>
        /// <param name="numberOfUsers">The total number of simulated concurrent user threads to spin up.</param>
        /// <param name="messagePerUser">The total number of messages per user.</param>
        public void IndependentLogFiles(int numberOfUsers, int messagePerUser)
        {
            Directory.CreateDirectory(this._userLogFolder);

            Parallel.For(0, numberOfUsers, i =>
            {
                int userId = i + 1;
                string filePath = Path.Combine(this._userLogFolder, $"user-{userId}.txt");

                using (FileStream stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None, 4096))
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    for (int messageId = 1; messageId <= messagePerUser; messageId++)
                    {
                        string message = $"{DateTime.Now} - User {userId} => with error ID: {messageId} Error";
                        writer.WriteLine(message);
                    }
                }
            });
        }

        private void LogThreadSafe(int userId, int messageId)
        {
            string message = $"{DateTime.Now}: User - {userId} => with error ID: {messageId} error";
            lock (_lock)
            {
                byte[] messageByte = Encoding.UTF8.GetBytes(message + Environment.NewLine);
                using FileStream stream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write);
                stream.Write(messageByte, 0, messageByte.Length);
            }
        }
    }
}
