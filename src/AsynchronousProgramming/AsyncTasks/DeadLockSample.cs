namespace AsynchronousProgramming.AsyncTasks
{
    /// <summary>
    /// Provides methods that demonstrates the cause of deadlock and fix the issues.
    /// </summary>
    public class DeadLockSample
    {
        /// <summary>
        /// Asynchronously retrieves a message and assigns it to a local variable.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<string> DeadlockMethod()
        {
            string message = await this.SomeAsyncOperation();
            return message;
        }

        /// <summary>
        /// Waits for 1 second and returns a string message.
        /// </summary>
        /// <returns>A task of string.</returns>
        public async Task<string> SomeAsyncOperation()
        {
            await Task.Delay(1000);
            return "Hello, World!";
        }
    }
}
