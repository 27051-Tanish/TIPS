using GarbageCollection.DemoClass;

namespace GarbageCollection
{
    /// <summary>
    /// Contains the main execution logic for executing basic garbage collection tasks.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Serves as the primary entry point of the application.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Memory Before Object Creation:");
            DisplayMemory();
            CreateAndDestroyLargeObjects();
            Console.WriteLine("\nMemory After Object Creation:");
            DisplayMemory();

            Console.WriteLine("\nTriggering Garbage Collection...");
            GC.Collect();

            Console.WriteLine("\nMemory After GC.Collect():");
            DisplayMemory();
            Console.ReadKey();
        }

        /// <summary>
        /// Creates and destroys a large number of objects in a for loop with large count.
        /// Use GC.Collect to manually trigger garbage collection and observe the impact on memory usage.
        /// </summary>
        public static void CreateAndDestroyLargeObjects()
        {
            for (int i = 0; i < 100000000; i++)
            {
                Demo demo = new Demo();
            }
        }

        /// <summary>
        /// Displays the current amount of managed memory allocated by the application.
        /// </summary>
        public static void DisplayMemory()
        {
            long memory = GC.GetTotalMemory(false);
            Console.WriteLine($"Managed memory: {memory / 1024.0 / 1024.0:F2}MB");
        }
    }
}