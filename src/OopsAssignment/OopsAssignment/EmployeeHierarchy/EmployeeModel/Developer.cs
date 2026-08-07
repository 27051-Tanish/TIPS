using OopsAssignment.EmployeeHierarchy.EmployeeModel;
using OopsAssignment.Helper.ConstantVariables;

namespace OopsAssignment.EmployeeHierarchy.EmployeeModel
{
    /// <summary>
    /// Inherits the EmployeeInfo class and its shared methods and properties.
    /// </summary>
    public class Developer : EmployeeInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class.
        /// </summary>
        /// <param name="name">Name of the employee.</param>
        /// <param name="salary">Salary of the employee.</param>
        public Developer(string? name, decimal salary)
            : base(name, salary)
        {
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
            return this.Salary * BonusAmountConstant.DeveloperBonus;
        }
    }
}
