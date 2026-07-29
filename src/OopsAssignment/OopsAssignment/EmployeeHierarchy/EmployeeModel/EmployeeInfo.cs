namespace OopsAssignment.EmployeeHierarchy.EmployeeModel
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
        /// Name of the employee.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets salary.
        /// </summary>
        /// <value>
        /// Salary of the employee.
        /// </value>
        public decimal Salary { get; set; }

        /// <summary>
        /// Calculates the employee bonus.
        /// </summary>
        /// <returns>Bonus of the employee</returns>
        public abstract decimal CalculateBonus();

        /// <summary>
        /// Returns the position of the employee.
        /// </summary>
        /// <returns>Position of the employee</returns>
        public abstract string GetEmployeePosition();

        /// <summary>
        /// Prints the details of the employee.
        /// </summary>
        /// <returns>string of details</returns>
        public virtual string PrintDetails()
        {
            return $"Name: {this.Name}\nSalary: {this.Salary}\nBonus: {this.CalculateBonus()}\nPosition: {this.GetEmployeePosition()}";
        }
    }
}
