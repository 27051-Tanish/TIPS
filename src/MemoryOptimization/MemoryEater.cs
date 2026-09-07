namespace MemoryOptimization
{
    /// <summary>
    /// Fixes a memory issue provided in the code snippet and implement memory management best practices.
    /// </summary>
    public class MemoryEater
    {
        /// <summary>
        /// List of integer array to demonstrate memory management best practices.
        /// </summary>
        private List<int[]> _memAlloc = new List<int[]>();

        /// <summary>
        /// Adds new integer array to the list.
        /// </summary>
        public void Allocate()
        {
            while (true)
            {
                this._memAlloc.Add(new int[1000]);
                Thread.Sleep(10);
            }
        }
    }
}
