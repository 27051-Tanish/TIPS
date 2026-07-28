using OopsAssignment;
using OopsAssignment.BankingSystem.BankController;
using OopsAssignment.EmployeeHierarchy.EmployeeController;
using OopsAssignment.ShapeHierarchy.Controller;

namespace OopsAssignment
{
    /// <summary>
    /// Entry point of the program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        public static void Main()
        {
            ProjectConsoleView view = new ();
            ProjectController controller = new (view);
            controller.Start();
        }
    }
}
