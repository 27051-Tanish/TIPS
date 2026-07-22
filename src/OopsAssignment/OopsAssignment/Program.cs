using System;
using OopsAssignment.BankingSystem.BankController;
using OopsAssignment.BankingSystem.BankView;
using OopsAssignment.EmployeeHierarchy.EmployeeController;
using OopsAssignment.EmployeeHierarchy.EmployeeView;
using OopsAssignment.ShapeHierarchy.Controller;
using OopsAssignment.ShapeHierarchy.View;

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
        public static void Main(string[] args)
        {
            ProjectConsoleView view = new ProjectConsoleView();
            ProjectController controller = new ProjectController(view);
            controller.RunProject();
        }
    }
}
