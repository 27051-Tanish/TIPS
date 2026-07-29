using OopsAssignment;
using OopsAssignment.BankingSystem.BankController;
using OopsAssignment.EmployeeHierarchy.EmployeeController;
using OopsAssignment.ShapeHierarchy.Controller;

namespace OopsAssignment
{
    /// <summary>
    /// Contains the main execution logic for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Serves as the primary entry point of the program.
        /// </summary>
        public static void Main()
        {
            ProjectConsoleView view = new ();
            ProjectController controller = new (view);
            controller.Start();
        }
    }
}
