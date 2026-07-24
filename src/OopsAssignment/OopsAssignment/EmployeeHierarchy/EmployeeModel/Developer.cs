using System;
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
        /// <param name="name">string name of the developer</param>
        /// <param name="salary">decimal salary of the developer</param>
        public Developer(string? name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        /// <summary>
        /// Returns the position of the Employee.
        /// </summary>
        /// <returns>string representing the position</returns>
        public override string GetEmployeePosition()
        {
            return "Developer";
        }

        /// <summary>
        /// Calculates the bonus of the developer.
        /// </summary>
        /// <returns>decimal representing the bonus</returns>
        public override decimal CalculateBonus()
        {
            const decimal developerBonus = 0.10m;
            return this.Salary * developerBonus;
        }

        /// <summary>
        /// Prints the developer details.
        /// </summary>
        /// <returns>string representing manager details</returns>
        public override string PrintDetails()
        {
            return $"Name: {this.Name}\nSalary: {this.Salary}\nBonus: {this.CalculateBonus()}\nPosition: {this.GetEmployeePosition()}";
        }
    }
}
