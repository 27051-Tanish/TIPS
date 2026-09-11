namespace ErrorHandling.Exceptions
{
    /// <summary>
    /// If the user enters an invalid input, throw an InvalidUserInputException.
    /// </summary>
    public class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public InvalidUserInputException(string message)
            : base(message)
        {
        }
    }
}
