using FileStreamProject.Constants;
using System.Text;

namespace FileStreamProject.FileStreamTasks
{
    /// <summary>
    /// performs efficient, thread-safe logging system that can handle multiple users logging errors simultaneously without
    /// contention or significant performance degradation.
    /// </summary>
    public class Task4
    {
        private static string _logFilePath = "log.txt";

        private readonly object _lock = new object();

        private readonly string _userLogFolder = "Data/Log/Users";

        /// <summary>
        /// Modify the LogError method to write directly to the file.
        /// </summary>
        /// <param name="errorMessage">The message to be written in the file.</param>
        public void ImproveFileWriting(string errorMessage)
        {
            byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);

            // [subtask 1] Fix of the starter code: Stream directly to disk, completely bypassing the redundant MemoryStream array copies.
            using (FileStream stream = new FileStream(_logFilePath, FileMode.Append))
            {
                stream.Write(errorBytes, 0, errorBytes.Length);
            }
        }

        /// <summary>
        /// Implement a locking mechanism to ensure that file write operations are thread safe when multiple users try to write.
        /// </summary>
        /// <param name="numberOfUsers">The total number of simulated concurrent user threads to spin up.</param>
        public void ThreadSafeLogging(int numberOfUsers)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < numberOfUsers; i++)
            {
                int userId = i + 1;
                Thread thread = new Thread(() =>
                {
                    this.LogThreadSafe(userId);
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
        /// /// <param name="numberOfUsers">The total number of simulated concurrent user threads to spin up.</param>
        public void IndependentLogFiles(int numberOfUsers)
        {
            Directory.CreateDirectory(this._userLogFolder);

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

                    string message =
                        $"{DateTime.Now} - User {userId}: Error";
                    byte[] messageByte = Encoding.UTF8.GetBytes(message + Environment.NewLine);
                    using FileStream stream = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                    stream.Write(messageByte, 0, messageByte.Length);
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
        /// Executes all the methods one by one.
        /// </summary>
        public void Run()
        {
            this.ImproveFileWriting("Error occurred from improved logging.\n");

            this.ThreadSafeLogging(5);

            this.IndependentLogFiles(5);
        }

        private void LogThreadSafe(int userId)
        {
            string message = $"{DateTime.Now}: User - {userId} error";
            lock (this._lock)
            {
                byte[] messageByte = Encoding.UTF8.GetBytes(message + Environment.NewLine);
                using FileStream stream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write);
                stream.Write(messageByte, 0, messageByte.Length);
            }
        }
    }
}
