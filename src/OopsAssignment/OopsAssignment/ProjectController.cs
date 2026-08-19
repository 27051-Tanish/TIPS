using OopsAssignment.BankingSystem.BankController;
using OopsAssignment.EmployeeHierarchy.EmployeeController;
using OopsAssignment.ShapeHierarchy.Controller;

namespace OopsAssignment
{
    /// <summary>
    /// Coordinates application flow by invoking the appropriate modules.
    /// </summary>
    public class ProjectController
    {
        private readonly ProjectConsoleView _projectConsole;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectController"/> class.
        /// </summary>
        /// <param name="projectConsole">The console service used to interact with project output/input.</param>
        public ProjectController(ProjectConsoleView projectConsole)
        {
            this._projectConsole = projectConsole;
        }

        /// <summary>
        /// Runs the overall application.
        /// </summary>
        public void RunApplication()
        {
            int userInput;
            MainMenu mainMenu;
            do
            {
                this._projectConsole.ShowMessage("--Please select the application--");
                this._projectConsole.ShowMenu("[1]. Shape Hierarchy\n[2]. Employee Hierarchy\n[3]. Banking System\n[4]. Exit");
                userInput = this._projectConsole.GetChoice("Please select from [1 to 4]\nEnter again :");
                mainMenu = (MainMenu)userInput;
                switch (mainMenu)
                {
                    case MainMenu.ShapeHierarchy:
                        this.StartShapeHierarchy();
                        break;
                    case MainMenu.EmployeeHierarchy:
                        this.StartEmployeeHierarchy();
                        break;
                    case MainMenu.BankingSystem:
                        this.StartBankApplication();
                        break;
                    case MainMenu.Exit:
                        this._projectConsole.ShowMessage("Exiting the application.");
                        this._projectConsole.ShowMessage("Exiting the application.");
                        break;
                    default:
                        this._projectConsole.ShowMessage("Invalid choice");
                        break;
                }
            }
            while (mainMenu != MainMenu.Exit);
        }

        private void StartShapeHierarchy()
        {
            ProjectConsoleView shapeConsoleView = new ();
            ShapeController controller = new (shapeConsoleView);
            controller.StartShapeHierarchy();
        }

        private void StartEmployeeHierarchy()
        {
            ProjectConsoleView employeeConsoleView = new ();
            EmployeeControllerInfo employeeController = new (employeeConsoleView);
            employeeController.StartEmployeeHierarchy();
        }

        private void StartBankApplication()
        {
            ProjectConsoleView bankConsoleView = new ();
            BankServiceController bankServiceController = new (bankConsoleView);
            bankServiceController.StartBankingSystem();
        }
    }
}
