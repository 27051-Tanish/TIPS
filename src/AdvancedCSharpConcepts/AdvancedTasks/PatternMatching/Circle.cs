namespace AdvancedCSharpConcepts.AdvancedTasks.PatternMatching
{
    /// <summary>
    /// Provides properties required for the circle shape.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        public Circle(double radius)
        {
            this.Name = "Circle";
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        /// <value>
        /// The radius of the circle.
        /// </value>
        public double Radius { get; set; }

        /// <inheritdoc/>
        public override double CalculateArea()
        {
            double maxRadius = Math.Sqrt(double.MaxValue / Math.PI);
            if (this.Radius > maxRadius)
            {
                throw new OverflowException("The radius is too big to calculate area of the circle.");
            }

            return Math.PI * this.Radius * this.Radius;
        }
    }
}
