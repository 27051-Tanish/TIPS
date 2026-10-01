namespace AsynchronousProgramming.AsyncTasks
{
    /// <summary>
    /// Provides methods that print the square of each number in the array.
    /// </summary>
    public class TaskParallelLib
    {
        private readonly int[] _array = Enumerable.Range(1, 1000).ToArray();

        /// <summary>
        /// Squares each number in an array.
        /// </summary>
        /// <returns>The squared array.</returns>
        public int[] SquareTheNumbers()
        {
            int lengthOfTheArray = this._array.Length;
            int[] squaredArray = new int[lengthOfTheArray];
            Parallel.ForEach(Enumerable.Range(0, lengthOfTheArray), i =>
            {
                squaredArray[i] = this._array[i] * this._array[i];
            });

            return squaredArray;
        }
    }
}
