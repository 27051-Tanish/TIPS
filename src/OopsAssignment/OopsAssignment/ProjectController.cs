using System;
using OopsAssignment.BankingSystem.BankController;
using OopsAssignment.EmployeeHierarchy.EmployeeController;
using OopsAssignment.ShapeHierarchy.Controller;

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

                userInput = GetChoice();
                MainMenu mainMenu = (MainMenu)userInput;
                switch (mainMenu)
                {
                    case MainMenu.ShapeTask:
                        GetShapeTask();
                        break;
                    case MainMenu.EmployeeTask:
                        GetEmployeeTask();
                        break;
                    case MainMenu.BankTask:
                        GetBankingTask();
                        break;
                    case MainMenu.Exit:
                        break;
                    default:
                        this._projectConsole.ShowMessage("Invalid choice");
                        break;
                }
            }
            while (userInput != 4);

            void GetShapeTask()
            {
                ProjectConsoleView shapeConsoleView = new ();
                ShapeController controller = new (shapeConsoleView);
                controller.RunShape();
            }

            void GetEmployeeTask()
            {
                ProjectConsoleView employeeConsoleView = new ();
                EmployeeControllerInfo employeeController = new (employeeConsoleView);
                employeeController.RunEmployeeTask();
            }

            void GetBankingTask()
            {
                ProjectConsoleView bankConsoleView = new ();
                BankServiceController bankServiceController = new (bankConsoleView);
                bankServiceController.RunBankAccount();
            }

            int GetChoice()
            {
                while (true)
                {
                    if (int.TryParse(this._projectConsole.ReadInput(), out int choiceValue))
                    {
                        return choiceValue;
                    }
                    else
                    {
                        this._projectConsole.ShowMessage("Please enter valid choice\nEnter your choice again :");
                    }
                }
            }
        }
    }
}
