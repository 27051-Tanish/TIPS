namespace OopsAssignment.ShapeHierarchy.Models
{
    /// <summary>
    /// Represents a circle shape, inheriting shared shape properties and behaviors.
    /// </summary>
    public class Circle : ShapeInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="color">Color of the circle.</param>
        /// <param name="radius">Radius of the circle.</param>
        public Circle(string? color, double radius)
        {
            this.Color = color;
            this.Radius = radius;
        }

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
            double maxRadius = Math.Sqrt(double.MaxValue / Math.PI);
            if (this.Radius > maxRadius)
            {
                throw new OverflowException("The radius is too big to calculate area of the circle");
            }

            return Math.PI * this.Radius * this.Radius;
        }
    }
}
