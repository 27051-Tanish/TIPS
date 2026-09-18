namespace AdvancedCSharpConcepts.AdvancedTasks
{
    /// <summary>
    /// Provides a mechanism for filter and modify a collection of data.
    /// </summary>
    public static class LambdaExpression
    {
        /// <summary>
        /// Filters out even numbers from the provided list, squares the remaining odd numbers numbers,
        /// and returns the transformed collection.
        /// </summary>
        /// <param name="numbers">The list of numbers to filter.</param>
        /// <returns>The filtered list.</returns>
        public static List<int> FilterFromList(List<int> numbers)
        {
            List<int> resultList = numbers.Where(n => n % 2 != 0)
                .Select(n =>
                {
                    return n * n;
                })
                .ToList();
            return resultList;
        }
    }
}
