namespace ReflectionsProject.SampleClasses
{
    /// <summary>
    /// Mock class for performing dynamic object task.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        /// <value>
        /// The name of the student.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the department of the student.
        /// </summary>
        /// <value>
        /// The department of the student.
        /// </value>
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the marks of the student.
        /// </summary>
        /// <value>
        /// The marks of the student.
        /// </value>
        public int Marks { get; set; }

        /// <summary>
        /// Displays the greeting message.
        /// </summary>
        public void DisplayHello()
        {
            Console.WriteLine("Hello from student");
        }
    }
}
