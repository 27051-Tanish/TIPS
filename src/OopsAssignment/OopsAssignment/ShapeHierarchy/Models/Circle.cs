namespace OopsAssignment.ShapeHierarchy.Models
{
    /// <summary>
    /// Represents a circle shape, inheriting shared shape properties and behaviors.
    /// </summary>
    public class Circle : ShapeInfo
    {
        /// <summary>
        /// Stores the value of pi.
        /// </summary>
        public const double Pi = Math.PI;

        /// <summary>
        /// Gets or sets radius of the circle.
        /// </summary>
        /// <value>
        /// Radius of the circle.
        /// </value>
        public double Radius { get; set; }

        /// <summary>
        /// Prints the type of the shape.
        /// </summary>
        /// <returns>Name of the shape type.</returns>
        public override string GetShapeType()
        {
            return "Circle";
        }

        /// <summary>
        /// Calculates the area of circle.
        /// </summary>
        /// <returns>The calculated area of circle.</returns>s
        public override double? CalculateArea()
        {
            return Pi * this.Radius * this.Radius;
        }
    }
}
