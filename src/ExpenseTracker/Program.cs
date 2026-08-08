using ExpenseTracker;
using ExpenseTracker.Core.TrackerInterface;
using ExpenseTracker.Persistence;
using ExpenseTracker.Service;
using ExpenseTracker.View;

namespace Assignments
{
    /// <summary>
    /// Contains the main execution logic of the expense tracker.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Serves as the primary entry point of the application.
        /// </summary>
        public static void Main()
        {
            ITrackerRepository repository = new InMemoryTrackerRepository();
            TrackerManager manager = new TrackerManager(repository);
            ITrackerView view = new TrackerView();

            TrackerController controller = new TrackerController(view, manager);
            controller.RunExpenseTrackerApp();
        }
    }
}
