namespace AdvancedCSharpConcepts.AdvancedTasks
{
    /// <summary>
    /// Provides a mechanism for publishing string-based notification events to subscribers.
    /// </summary>
    public class Notifier
    {
        /// <summary>
        /// Represents the delegate handler for processing notification messages.
        /// </summary>
        /// <param name="message">The text message being broadcasted.</param>
        public delegate void Notify(string message);

        /// <summary>
        /// Occurs when an action triggers a new notification.
        /// </summary>
        public event Notify? OnAction;

        /// <summary>
        /// Safely raises the <see cref="OnAction"/> event to all registered subscribers.
        /// </summary>
        /// <param name="message">The notification message to send.</param>
        public void CallEvent(string message)
        {
            this.OnAction?.Invoke(message);
        }
    }
}
