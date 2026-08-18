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
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 3c66d6011e67eb4f8bc54cb3e5c87a50fb33cd2e
                        this.HandleManagerDetails();
                        break;
                    case EmployeeMenu.Developer:
                        this.HandleDeveloperDetails();
<<<<<<< HEAD
=======
                        this.GetManagerDetails();
                        break;
                    case EmployeeMenu.Developer:
                        this.GetDeveloperDetails();
>>>>>>> 17d2e2e3cefcb344d9ed2f92709ef00e9eddc480
=======
>>>>>>> 3c66d6011e67eb4f8bc54cb3e5c87a50fb33cd2e
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
<<<<<<< HEAD
<<<<<<< HEAD
        public void HandleManagerDetails()
=======
        public void GetManagerDetails()
>>>>>>> 17d2e2e3cefcb344d9ed2f92709ef00e9eddc480
=======
        public void HandleManagerDetails()
>>>>>>> 3c66d6011e67eb4f8bc54cb3e5c87a50fb33cd2e
        {
            var employee = this.GetEmployeeDetails("Manager");
            Manager manager = new (employee.name, employee.salary);
            this._employeeView.EndLine();
            this._employeeView.ShowMessage(manager.PrintDetails());
        }

        /// <summary>
        /// Gets and prints developer details.
        /// </summary>
<<<<<<< HEAD
<<<<<<< HEAD
        public void HandleDeveloperDetails()
=======
        public void GetDeveloperDetails()
>>>>>>> 17d2e2e3cefcb344d9ed2f92709ef00e9eddc480
=======
        public void HandleDeveloperDetails()
>>>>>>> 3c66d6011e67eb4f8bc54cb3e5c87a50fb33cd2e
        {
            var employee = this.GetEmployeeDetails("Developer");
            Developer developer = new (employee.name, employee.salary);
            this._employeeView.EndLine();
            this._employeeView.ShowMessage(developer.PrintDetails());
        }

<<<<<<< HEAD
<<<<<<< HEAD
=======
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

>>>>>>> 17d2e2e3cefcb344d9ed2f92709ef00e9eddc480
=======
>>>>>>> 3c66d6011e67eb4f8bc54cb3e5c87a50fb33cd2e
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
<<<<<<< HEAD
<<<<<<< HEAD
                salary = this._employeeView.GetSalary();
=======
                salary = this.GetSalary();
>>>>>>> 17d2e2e3cefcb344d9ed2f92709ef00e9eddc480
=======
                salary = this._employeeView.GetSalary();
>>>>>>> 3c66d6011e67eb4f8bc54cb3e5c87a50fb33cd2e

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
