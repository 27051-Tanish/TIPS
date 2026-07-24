using System;
using OopsAssignment;
using OopsAssignment.EmployeeHierarchy.EmployeeModel;

namespace OopsAssignment.EmployeeHierarchy.EmployeeController
{
    /// <summary>
    /// Handles the communication between view and models.
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
        public void RunEmployeeTask()
        {
            int userInput;
            do
            {
                this._employeeView.EndLine();
                this._employeeView.ShowMessage("[1].Manager");
                this._employeeView.ShowMessage("[2].Developer");
                this._employeeView.ShowMessage("[3].Exit");
                this._employeeView.EndLine();

                userInput = this.GetChoice();
                EmployeeMenu employeeMenu = (EmployeeMenu)userInput;

                switch (employeeMenu)
                {
                    case EmployeeMenu.Manager:
                        this.GetManagerDetails();
                        break;
                    case EmployeeMenu.Developer:
                        this.GetDeveloperDetails();
                        break;
                    case EmployeeMenu.Exit:
                        this._employeeView.ShowMessage("Exiting...");
                        break;
                    default:
                        this._employeeView.ShowMessage("Invalid input: select 1, 2, or 3");
                        break;
                }
            }
            while (userInput != 3);
        }

        /// <summary>
        /// Gets and prints manager details.
        /// </summary>
        public void GetManagerDetails()
        {
            string? name;
            do
            {
                this._employeeView.ShowMessage("Enter name of the manager: ");
                name = this._employeeView.ReadInput();
                if (!InputValidator.ValidateName(name))
                {
                    this._employeeView.ShowMessage("Invalid input for name");
                }
            }
            while (!InputValidator.ValidateName(name));

            this._employeeView.ShowMessage("Enter the salary of the manager: ");
            decimal salary = this.GetSalary();
            Manager manager = new (name, salary);
            this._employeeView.EndLine();
            this._employeeView.ShowMessage(manager.PrintDetails());
        }

        /// <summary>
        /// Gets and prints developer details.
        /// </summary>
        public void GetDeveloperDetails()
        {
            string? name;
            do
            {
                this._employeeView.ShowMessage("Enter name of the developer: ");
                name = this._employeeView.ReadInput();
                if (!InputValidator.ValidateName(name))
                {
                    this._employeeView.ShowMessage("Invalid input for name");
                }
            }
            while (!InputValidator.ValidateName(name));
            this._employeeView.ShowMessage("Enter salary of the developer: ");
            decimal salary = this.GetSalary();
            Developer developer = new (name, salary);
            this._employeeView.EndLine();
            this._employeeView.ShowMessage(developer.PrintDetails());
        }

        /// <summary>
        /// Gets user input for switch case choice.
        /// </summary>
        /// <returns>Int value representing choice from menu</returns>
        public int GetChoice()
        {
            while (true)
            {
                if (int.TryParse(this._employeeView.ReadInput(), out int choiceValue))
                {
                    return choiceValue;
                }
                else
                {
                    this._employeeView.ShowMessage("Please enter valid choice");
                }
            }
        }

        /// <summary>
        /// Gets user input for salary.
        /// </summary>
        /// <returns>double representing the value of salary</returns>
        public decimal GetSalary()
        {
            while (true)
            {
                if (decimal.TryParse(this._employeeView.ReadInput(), out decimal salary))
                {
                    return salary;
                }
                else
                {
                    this._employeeView.ShowMessage("Please enter valid salary :");
                }
            }
        }
    }
}
