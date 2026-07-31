namespace OopsAssignment.Helper.CustomException
{
    /// <summary>
    /// Represents an error that occurs when a maximum allowed value is exceeded.
    /// </summary>
    public class MaxValueException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaxValueException"/> class.
        /// </summary>
        /// <param name="message">The error message to be displayed.</param>
        public MaxValueException(string message)
            : base(message)
        {
        }
    }
}
