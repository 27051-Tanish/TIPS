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
            IFileRepository fileRepository = new TrackerFile();
            TrackerManager manager = new TrackerManager(fileRepository);
            ITrackerView view = new TrackerView();

            TrackerController controller = new TrackerController(view, manager);
            controller.RunExpenseTrackerApp();
        }
    }
}
