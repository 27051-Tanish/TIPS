using IDisposableDemo.FileOperations;
using Microsoft.Win32.SafeHandles;

namespace IDisposableDemo
{
    /// <summary>
    /// Contains the main execution logic for executing file reader and writer using IDisposable interface.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Serves as the primary entry point of the application.
        /// </summary>
        public static void Main()
        {
            using (FileWriter writer = new FileWriter("SampleFile.txt"))
            {
                writer.WriteToFile("Hi, this is for testing purpose.");
            }

            string fileData;
            using (FileReader reader = new FileReader("SampleFile.txt"))
            {
                fileData = reader.ReadFromFile();
            }

            Console.WriteLine($"File content: {fileData}");
            Console.ReadKey();
        }
    }
}