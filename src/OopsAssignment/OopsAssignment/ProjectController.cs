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
    /// Handles between different tasks.
    /// </summary>
    public class ProjectController
    {
        private readonly ProjectConsoleView _projectConsole;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectController"/> class.
        /// </summary>
        /// <param name="projectConsole">This is an instance for Project controller</param>
        public ProjectController(ProjectConsoleView projectConsole)
        {
            this._projectConsole = projectConsole;
        }

        /// <summary>
        /// Runs the overall project.
        /// </summary>
        public void RunProject()
        {
            int userInput;

            do
            {
                this._projectConsole.ShowMessage("--Enter which task you want to run--");
                this._projectConsole.EndLine();
                this._projectConsole.ShowMessage("[1].Shape Hierarchy");
                this._projectConsole.ShowMessage("[2].Employee Hierarchy");
                this._projectConsole.ShowMessage("[3].Banking System");
                this._projectConsole.ShowMessage("[4].Exit");
                this._projectConsole.EndLine();

                userInput = Convert.ToInt32(this._projectConsole.ReadInput());

                switch (userInput)
                {
                    case 1:
                        GetShapeTask();
                        break;
                    case 2:
                        GetEmployeeTask();
                        break;
                    case 3:
                        GetBankingTask();
                        break;
                    case 4:
                        this._projectConsole.ExitKey();
                        break;
                    default:
                        this._projectConsole.ShowMessage("Invalid choice");
                        break;
                }
            }
            while (userInput != 4);

            void GetShapeTask()
            {
                ShapeView view = new ShapeView();
                ShapeController controller = new ShapeController(view);
                controller.RunShape();
            }

            void GetEmployeeTask()
            {
                EmployeeConsoleView employeeConsoleView = new EmployeeConsoleView();
                EmployeeControllerInfo employeeController = new EmployeeControllerInfo(employeeConsoleView);
                employeeController.RunEmployeeTask();
            }

            void GetBankingTask()
            {
                BankConsoleView bankConsoleView = new BankConsoleView();
                BankServiceController bankServiceController = new BankServiceController(bankConsoleView);
                bankServiceController.RunBankAccount();
            }
        }
    }
}
