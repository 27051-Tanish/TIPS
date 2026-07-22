using System;
using OopsAssignment.EmployeeHierarchy.EmployeeModel;
using OopsAssignment.EmployeeHierarchy.Model;

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
        /// <param name="name">string name of the manager</param>
        /// <param name="salary">decimal salary of the manager</param>
        public Manager(string name, decimal salary)
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
            return "Manager";
        }

        /// <summary>
        /// Calculates the bonus of the manager.
        /// </summary>
        /// <returns>decimal representing the bonus</returns>
        public override decimal CalculateBonus()
        {
            return this.Salary * 0.20m;
        }

        /// <summary>
        /// Prints the manager details.
        /// </summary>
        /// <returns>string representing manager details</returns>
        public override string PrintDetails()
        {
            return $"Name: {this.Name}\nSalary: {this.Salary}\nBonus: {this.CalculateBonus()}\nPosition: {this.GetEmployeePosition()}";
        }
    }
}
