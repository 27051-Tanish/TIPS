using System;
using OopsAssignment.EmployeeHierarchy.EmployeeModel;
using OopsAssignment.EmployeeHierarchy.EmployeeView;

namespace OopsAssignment.EmployeeHierarchy.EmployeeController
{
    /// <summary>
    /// Handles the communication between view and models.
    /// </summary>
    public class EmployeeControllerInfo
    {
        private readonly EmployeeConsoleView? _employeeView;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeControllerInfo"/> class.
        /// </summary>
        /// <param name="employeeView">The view is instance</param>
        public EmployeeControllerInfo(EmployeeConsoleView employeeView)
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

                userInput = Convert.ToInt32(this._employeeView.ReadInput());

                switch (userInput)
                {
                    case 1:
                        this.GetManagerDetails();
                        break;
                    case 2:
                        this.GetDeveloperDetails();
                        break;
                    case 3:
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
            decimal salary = Convert.ToDecimal(this._employeeView.ReadInput());
            Manager manager = new Manager(name, salary);
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
                this._employeeView.ShowMessage("Enter name of the manager: ");
                name = this._employeeView.ReadInput();
                if (!InputValidator.ValidateName(name))
                {
                    this._employeeView.ShowMessage("Invalid input for name");
                }
            }
            while (!InputValidator.ValidateName(name));
            this._employeeView.ShowMessage("Enter salary of the developer: ");
            decimal salary = Convert.ToDecimal(this._employeeView.ReadInput());
            Developer developer = new Developer(name, salary);
            this._employeeView.ShowMessage(developer.PrintDetails());
        }
    }
}
