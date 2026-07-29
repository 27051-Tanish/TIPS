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
        /// Runs the overall project.
        /// </summary>
        public void Start()
        {
            int userInput;
            MainMenu mainMenu;
            do
            {
                this._projectConsole.ShowMessage("--Please select the application--");
                this._projectConsole.ApplicationMenu();
                userInput = this.GetChoice();
                mainMenu = (MainMenu)userInput;
                switch (mainMenu)
                {
                    case MainMenu.ShapeHierarchy:
                        StartShapeHierarchy();
                        break;
                    case MainMenu.EmployeeHierarchy:
                        StartEmployeeHierarchy();
                        break;
                    case MainMenu.BankingSystem:
                        StartBankApplication();
                        break;
                    case MainMenu.Exit:
                        break;
                    default:
                        this._projectConsole.ShowMessage("Invalid choice");
                        break;
                }
            }
            while (mainMenu != MainMenu.Exit);

            void StartShapeHierarchy()
            {
                ProjectConsoleView shapeConsoleView = new ();
                ShapeController controller = new (shapeConsoleView);
                controller.StartShapeHierarchy();
            }

            void StartEmployeeHierarchy()
            {
                ProjectConsoleView employeeConsoleView = new ();
                EmployeeControllerInfo employeeController = new (employeeConsoleView);
                employeeController.StartEmployeeHierarchy();
            }

            void StartBankApplication()
            {
                ProjectConsoleView bankConsoleView = new ();
                BankServiceController bankServiceController = new (bankConsoleView);
                bankServiceController.StartBankingSystem();
            }
        }

        private int GetChoice()
        {
            while (true)
            {
                if (int.TryParse(this._projectConsole.ReadInput(), out int choiceValue))
                {
                    return choiceValue;
                }
                else
                {
                    this._projectConsole.ShowMessage("Please enter valid choice from [1 to 4]\nEnter your choice again :");
                }
            }
        }
    }
}
