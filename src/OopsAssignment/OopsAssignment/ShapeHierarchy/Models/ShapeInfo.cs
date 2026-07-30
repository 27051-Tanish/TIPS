namespace OopsAssignment.ShapeHierarchy.Models
{
    /// <summary>
    /// Provides a base contract and shared properties for shape objects.
    /// </summary>
    public abstract class ShapeInfo
    {
        /// <summary>
        /// Gets or sets color.
        /// </summary>
        /// <value>
        /// Color of the circle.
        /// </value>
        public string? Color { get; set; }

        /// <summary>
        /// Gets the specific type of the shape.
        /// </summary>
        /// <returns>Specific type of shape.</returns>
        public abstract string GetShapeType();

        /// <summary>
        /// Calculates the area of the shape.
        /// </summary>
        /// <returns>The calculated area of a shape.</returns>
        public abstract double? CalculateArea();

        /// <summary>
        /// Prints details of the shape.
        /// </summary>
        /// <returns>Details of specific shape.</returns>
        public virtual string PrintDetails()
        {
            return $"Color: {this.Color}\nArea: {this.CalculateArea()}\nShape Type: {this.GetShapeType()}";
        }
    }
}
