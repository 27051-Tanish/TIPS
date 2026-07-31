using OopsAssignment.EmployeeHierarchy.EmployeeModel;

namespace OopsAssignment.EmployeeHierarchy.EmployeeModel
{
    /// <summary>
    /// Manager class inherits EmployeeInfo.
    /// </summary>
    public class Manager : EmployeeInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="name">Name of the manager.</param>
        /// <param name="salary">Salary of the manager.</param>
        public Manager(string? name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        /// <summary>
        /// Returns the position of the Employee.
        /// </summary>
        /// <returns>Position of the employee.</returns>
        public override string GetEmployeePosition()
        {
            return "Manager";
        }

        /// <summary>
        /// Calculates the bonus of the manager.
        /// </summary>
        /// <returns>Bonus amount of the employee.</returns>
        public override decimal CalculateBonus()
        {
            const decimal managerBonus = 0.20m;
            return this.Salary * managerBonus;
        }
    }
}
