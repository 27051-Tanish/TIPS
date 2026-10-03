using AsynchronousProgramming.ApplicationConstants;

namespace AsynchronousProgramming.AsyncTasks
{
    /// <summary>
    /// Provides required methods for performing the tasks.
    /// </summary>
    public class MultiThreading
    {
        /// <summary>
        /// Gets the sorted values of the list.
        /// </summary>
        /// <value>
        /// The sorted values of the list.
        /// </value>
        public List<int> SortedList { get; private set; }

        /// <summary>
        /// Gets the squared values of the list.
        /// </summary>
        /// <value>
        /// The squared values of the list.
        /// </value>
        public List<int> SquaredList { get; private set; }

        /// <summary>
        /// Sorts a list in ascending order.
        /// </summary>
        public void SortAList()
        {
            this.SortedList = ConstantVariables.ListOfNumbers;
            this.SortedList.Sort();
        }

        /// <summary>
        /// Calculates the square value of the list.
        /// </summary>
        public void CalculateSquareOfList()
        {
            this.SquaredList = ConstantVariables.ListOfNumbers.Select(n => n * n).ToList();
        }
    }
}
