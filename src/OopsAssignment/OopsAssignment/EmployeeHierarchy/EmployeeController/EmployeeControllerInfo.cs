using OopsAssignment.EmployeeHierarchy.EmployeeModel;
using OopsAssignment.Helper;

namespace OopsAssignment.EmployeeHierarchy.EmployeeController
{
    /// <summary>
    /// Controls data flow and communication between the employee view and model components.
    /// </summary>
    public class EmployeeControllerInfo
    {
        private readonly ProjectConsoleView _employeeView;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeControllerInfo"/> class.
        /// </summary>
        /// <param name="employeeView">The view is instance</param>
        public EmployeeControllerInfo(ProjectConsoleView employeeView)
        {
            this._employeeView = employeeView;
        }

        /// <summary>
        /// Starts the execution of the employee program.
        /// </summary>
        public void StartEmployeeHierarchy()
        {
            int userInput;
            EmployeeMenu employeeMenu;
            do
            {
                this._employeeView.ShowMenu("[1]. Manager\n[2]. Developer\n[3]. Exit");
                userInput = this._employeeView.GetChoice("Please enter valid choice from [1 to 3]\nPlease enter again :");
                employeeMenu = (EmployeeMenu)userInput;

                switch (employeeMenu)
                {
                    case EmployeeMenu.Manager:
                        this.HandleManagerDetails();
                        break;
                    case EmployeeMenu.Developer:
                        this.HandleDeveloperDetails();
                        break;
                    case EmployeeMenu.Exit:
                        this._employeeView.ShowMessage("Closing employee hierarchy application.");
                        break;
                    default:
                        this._employeeView.ShowMessage("Invalid input: please select 1, 2, or 3");
                        break;
                }
            }
            while (employeeMenu != EmployeeMenu.Exit);
        }

        /// <summary>
        /// Gets and prints manager details.
        /// </summary>
        public void HandleManagerDetails()
        {
            var employee = this.GetEmployeeDetails("Manager");
            Manager manager = new (employee.name, employee.salary);
            this._employeeView.EndLine();
            this._employeeView.ShowMessage(manager.PrintDetails());
        }

        /// <summary>
        /// Gets and prints developer details.
        /// </summary>
        public void HandleDeveloperDetails()
        {
            var employee = this.GetEmployeeDetails("Developer");
            Developer developer = new (employee.name, employee.salary);
            this._employeeView.EndLine();
            this._employeeView.ShowMessage(developer.PrintDetails());
        }

        private decimal GetSalary()
        {
            while (true)
            {
                if (decimal.TryParse(this._employeeView.ReadInput(), out decimal salary))
                {
                    return salary;
                }
                else
                {
                    this._employeeView.ShowMessage($"Salary should not contains characters and should not exceed the limit.\nSalary limit :{decimal.MaxValue}\nPlease enter valid salary :");
                }
            }
        }

        private (string? name, decimal salary) GetEmployeeDetails(string employeeType)
        {
            string? name;
            while (true)
            {
                this._employeeView.ShowMessage($"Enter name of the {employeeType}: ");
                name = this._employeeView.ReadInput();

                if (InputValidator.ValidateName(name))
                {
                    break;
                }

                this._employeeView.ShowMessage("Invalid entry for name.");
            }

            decimal salary;
            while (true)
            {
                this._employeeView.ShowMessage($"Enter salary of the {employeeType}: ");
                salary = this._employeeView.GetSalary();

                if (InputValidator.ValidateAmount(salary))
                {
                    break;
                }

                this._employeeView.ShowMessage($"Salary cannot be negative or greater than the limit\nSalary limit :{decimal.MaxValue}");
            }

            return (name, salary);
        }
    }
}
