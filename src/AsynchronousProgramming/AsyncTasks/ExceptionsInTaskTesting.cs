namespace AsynchronousProgramming.AsyncTasks
{
    /// <summary>
    /// Provides methods for testing the whether exceptions can be handled in async void and async task.
    /// </summary>
    public class ExceptionsInTaskTesting
    {
        /// <summary>
        /// Asynchronously performs an action and throws an unhandled exception.
        /// Warning: Because this is an async void method, the exception cannot be caught by standard try-catch blocks on the caller side.
        /// </summary>
        /// <exception cref="Exception">Thrown unconditionally to simulate an unhandled async void failure.</exception>
        public async void VoidMethod()
        {
            await Task.Delay(1);
            throw new Exception();
        }

        /// <summary>
        /// Asynchronously performs an operation that fails and returns a faulted task containing an exception.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the failed asynchronous operation.</returns>
        /// <exception cref="Exception">Thrown with a message indicating it originated from a task method.</exception>
        public async Task TaskMethod()
        {
            await Task.Delay(1);
            throw new Exception("Exception from task method");
        }
    }
}
