using CollectionsAndGenerics.Collections;
using CollectionsAndGenerics.Controller;
using CollectionsAndGenerics.Service;

namespace CollectionsAndGenerics
{
    /// <summary>
    /// Contains the execution logic of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Provides the entry point to the application.
        /// </summary>
        public static void Main()
        {
            CollectionService service = new CollectionService();
            CollectionController controller = new CollectionController(service);
            controller.RunTasks();
        }
    }
}