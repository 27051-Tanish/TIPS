using System;
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
        /// <param name="args">string args</param>
        public static void Main()
        {
            ProjectConsoleView view = new ();
            ProjectController controller = new (view);
            controller.RunProject();
        }
    }
}
