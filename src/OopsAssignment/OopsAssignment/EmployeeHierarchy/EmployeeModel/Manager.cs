using OopsAssignment.EmployeeHierarchy.EmployeeModel;
using OopsAssignment.Helper.ConstantVariables;

namespace OopsAssignment.EmployeeHierarchy.EmployeeModel
{
    /// <summary>
    /// Inherits the EmployeeInfo class and its shared methods and properties.
    /// </summary>
    public class Manager : EmployeeInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="name">Name of the manager.</param>
        /// <param name="salary">Salary of the manager.</param>
        public Manager(string? name, decimal salary)
            : base(name, salary)
        {
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
            return this.Salary * BonusAmountConstant.ManagerBonus;
        }
    }
}
