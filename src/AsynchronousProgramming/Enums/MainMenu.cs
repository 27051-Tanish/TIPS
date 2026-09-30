namespace AsynchronousProgramming.Enums
{
    /// <summary>
    /// Represents the main menu of the application.
    /// </summary>
    public enum MainMenu
    {
        /// <summary>
        /// Represents the task which performs operations using HttpClient class.
        /// </summary>
        HttpClientTask = 1,

        /// <summary>
        /// Represents the task which performs operations using Task Parallel library.
        /// </summary>
        TaskParallelLibraryTask,

        /// <summary>
        /// Represents task which performs operations using multi threading.
        /// </summary>
        MultiThreadingTask,

        /// <summary>
        /// Represents the task which performs operations using multi layered async and await.
        /// </summary>
        MultiLayeredAsyncTask,

        /// <summary>
        /// Represents the task which performs debugging and fixing deadlock conditions.
        /// </summary>
        DebuggingDeadlockTask,

        /// <summary>
        /// Represents the task which performs real-world application of ConfigureAwait with Thread Tracking.
        /// </summary>
        ThreadTrackingTask,

        /// <summary>
        /// Represents the task which provides difference between async void and async Task with exceptions.
        /// </summary>
        ExceptionsInTask,
    }
}
