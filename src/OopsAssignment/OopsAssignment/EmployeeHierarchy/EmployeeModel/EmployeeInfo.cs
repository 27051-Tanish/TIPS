using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsAssignment.EmployeeHierarchy.Model
{
    /// <summary>
    /// Gets or sets employee information
    /// </summary>
    public abstract class EmployeeInfo
    {
        /// <summary>
        /// Gets or sets name.
        /// </summary>
        /// <value>
        /// Name as string.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets salary.
        /// </summary>
        /// <value>
        /// Salary as decimal.
        /// </value>
        public decimal Salary { get; set; }

        /// <summary>
        /// Calculates the employee bonus.
        /// </summary>
        /// <returns>decimal value of the bonus</returns>
        public abstract decimal CalculateBonus();

        /// <summary>
        /// Returns the position of the employee.
        /// </summary>
        /// <returns>string representing position of the employee</returns>
        public abstract string GetEmployeePosition();

        /// <summary>
        /// Prints the details of the employee.
        /// </summary>
        /// <returns>string of details</returns>
        public virtual string PrintDetails()
        {
            return $"Name: {this.Name}\nSalary: {this.Salary}\nBonus: {this.CalculateBonus()}\nPosition: {this.GetEmployeePosition}";
        }
    }
}
