namespace AdvancedCSharpConcepts.AdvancedTasks.PatternMatching
{
    /// <summary>
    /// Provides necessary properties and methods for shapes.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Gets or sets the name of the shape.
        /// </summary>
        /// <value>
        /// The name of the shape.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Calculates the area of the shape.
        /// </summary>
        /// <returns>The area of the shape.</returns>
        public abstract double CalculateArea();
    }
}
