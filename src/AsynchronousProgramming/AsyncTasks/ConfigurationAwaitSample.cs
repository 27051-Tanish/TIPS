namespace AsynchronousProgramming.AsyncTasks
{
    /// <summary>
    /// Provides methods that demonstrates the usage of ConfigureAwait.
    /// </summary>
    public class ConfigurationAwaitSample
    {
        /// <summary>
        /// Represents the event which is triggered when invoked.
        /// </summary>
        public event Action<string>? ThreadNotifier;

        /// <summary>
        /// Simulates a long-running calculation asynchronously by delaying the execution,
        /// invoking a thread notifier event before and after the awaitable operation.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing the calculated integer result.</returns>
        public async Task<int> PerformMethodA()
        {
            this.ThreadNotifier?.Invoke($"Before await operation [Thread Id]: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(3000).ConfigureAwait(false);
            this.ThreadNotifier?.Invoke($"After await operation [Thread Id]: {Thread.CurrentThread.ManagedThreadId}");

            return 100;
        }

        /// <summary>
        /// Asynchronously invokes <see cref="PerformMethodA"/>, awaits its result,
        /// and performs additional text formatting processing.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing a formatted message string with the calculation result.</returns>
        public async Task<string> PerformMethodB()
        {
            this.ThreadNotifier?.Invoke($"Calling Method A from [Thread Id]: {Thread.CurrentThread.ManagedThreadId}");
            int calculatedValue = await this.PerformMethodA();
            this.ThreadNotifier?.Invoke($"The remaining execution after the await operation [Thread Id]: {Thread.CurrentThread.ManagedThreadId}");
            return $"The calculated value is {calculatedValue}";
        }
    }
}
