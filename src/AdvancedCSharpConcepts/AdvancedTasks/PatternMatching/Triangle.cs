namespace AdvancedCSharpConcepts.AdvancedTasks.PatternMatching
{
    /// <summary>
    /// Provides the properties and methods necessary for triangle shape.
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="base">The base of the triangle.</param>
        /// <param name="height">The height of the triangle.</param>
        public Triangle(double @base, double height)
        {
            this.Name = "Triangle";
            this.Base = @base;
            this.Height = height;
        }

        /// <summary>
        /// Gets or sets the base of the triangle.
        /// </summary>
        /// <value>
        /// The base of the triangle.
        /// </value>
        public double Base { get; set; }

        /// <summary>
        /// Gets or sets the height of the triangle.
        /// </summary>
        /// <value>
        /// The height of the triangle.
        /// </value>
        public double Height { get; set; }

        /// <inheritdoc/>
        public override double CalculateArea()
        {
            double area = 0.5 * this.Base * this.Height;

            // Check if the double calculation resulted in positive infinity (overflow)
            if (double.IsPositiveInfinity(area))
            {
                throw new OverflowException($"The dimensions are too large caused an arithmetic overflow during area calculation.");
            }

            return area;
        }
    }
}
