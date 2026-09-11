namespace MemoryOptimization
{
    /// <summary>
    /// Contains the execution logic of the project.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Provides the entry point for the main execution of the project.
        /// </summary>
        public static void Main()
        {
            MemoryEater me = new MemoryEater();
            me.Allocate();
            Console.WriteLine("Memory allocation and deallocation successful...");
            Console.ReadKey();
        }
    }
}