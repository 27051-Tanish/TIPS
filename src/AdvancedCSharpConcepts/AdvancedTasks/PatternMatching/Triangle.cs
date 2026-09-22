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
        /// <param name="baseOfTriangle">The base of the triangle.</param>
        /// <param name="height">The height of the triangle.</param>
        public Triangle(double baseOfTriangle, double height)
        {
            if (!double.IsFinite(baseOfTriangle) || !double.IsFinite(height))
            {
                throw new ArgumentException("Triangle dimensions must be finite, valid numbers.");
            }

            if (baseOfTriangle < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(baseOfTriangle), "The base of the triangle cannot be negative.");
            }

            if (height < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "The height of the triangle cannot be negative.");
            }

            this.Base = baseOfTriangle;
            this.Height = height;
        }

        /// <inheritdoc/>
        public override string Name => "Triangle";

        /// <summary>
        /// Gets the base of the triangle.
        /// </summary>
        /// <value>
        /// The base of the triangle.
        /// </value>
        public double Base { get; init; }

        /// <summary>
        /// Gets the height of the triangle.
        /// </summary>
        /// <value>
        /// The height of the triangle.
        /// </value>
        public double Height { get; init; }

        /// <inheritdoc/>
        public override double CalculateArea()
        {
            return 0.5 * this.Base * this.Height;
        }
    }
}
