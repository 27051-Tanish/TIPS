namespace OopsAssignment.EmployeeHierarchy.EmployeeModel
{
    /// <summary>
    /// Provides a base contract and shared properties for employee objects.
    /// </summary>
    public abstract class EmployeeInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeInfo"/> class.
        /// </summary>
        /// <param name="name">The name of the employee.</param>
        /// <param name="salary">The salary of the employee.</param>
        public EmployeeInfo(string? name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

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
        /// <returns>Details of the employee.</returns>
        public virtual string PrintDetails()
        {
            return $"Name: {this.Name}\nSalary: {this.Salary}\nBonus: {this.CalculateBonus()}\nPosition: {this.GetEmployeePosition()}";
        }
    }
}
