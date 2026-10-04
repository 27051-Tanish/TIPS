namespace AsynchronousProgramming.ApplicationConstants
{
    /// <summary>
    /// Stores the constant variables that is used across the application.
    /// </summary>
    public static class ConstantVariables
    {
        /// <summary>
        /// Stores a constant list of numbers.
        /// </summary>
        public static readonly List<int> ListOfNumbers = new List<int>() { 23, 34, 45, 56, 12, 8, 58, 90, 43, 11, 3 };

        /// <summary>
        /// Stores the constant value of the mock api url.
        /// </summary>
        public static readonly string MockApiUrl = "https://jsonplaceholder.typicode.com/todos/1";
    }
}
