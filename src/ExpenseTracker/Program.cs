using ExpenseTracker;
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
            TrackerView view = new TrackerView();
            TrackerManager manager = new TrackerManager();

            TrackerController controller = new TrackerController(view, manager);
            controller.RunExpenseTrackerApp();
        }
    }
}