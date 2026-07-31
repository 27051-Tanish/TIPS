using OopsAssignment.EmployeeHierarchy.EmployeeModel;

namespace OopsAssignment.EmployeeHierarchy.EmployeeModel
{
    /// <summary>
    /// Inherits the EmployeeInfo class and its methods.
    /// </summary>
    public class Developer : EmployeeInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class.
        /// </summary>
        /// <param name="name">Name of the employee.</param>
        /// <param name="salary">Salary of the employee.</param>
        public Developer(string? name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        /// <summary>
        /// Gets employee position.
        /// </summary>
        /// <returns>Position of the employee.</returns>
        public override string GetEmployeePosition()
        {
            return "Developer";
        }

        /// <summary>
        /// Calculates the bonus of the employee.
        /// </summary>
        /// <returns>Bonus amount of the employee.</returns>
        public override decimal CalculateBonus()
        {
            const decimal developerBonus = 0.10m;
            return this.Salary * developerBonus;
        }
    }
}
