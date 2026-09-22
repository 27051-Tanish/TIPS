namespace AdvancedCSharpConcepts.AdvancedTasks
{
    /// <summary>
    /// Provides a mechanism for sorting an array of integers in ascending order.
    /// </summary>
    public static class AnonymousMethodTask
    {
        /// <summary>
        /// Hardcodes an array of integers instantiates a local sorting delegate,
        /// invokes it, and returns the sorted array.
        /// </summary>
        /// <param name="numbers">The array that needs to be sorted.</param>
        /// <returns>A sorted array.</returns>
        public static int[] SortAnArray(int[] numbers)
        {
            Array.Sort(numbers, delegate(int number1, int number2)
            {
                return number1.CompareTo(number2);
            });

            return numbers;
        }
    }
}
