namespace AdvancedCSharpConcepts.AdvancedTasks.PatternMatching
{
    /// <summary>
    /// Represents a cube shape used to test unhandled or default type patterns.
    /// </summary>
    public class Square : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="sides">The sides of the square</param>
        public Square(double sides)
        {
            this.Sides = sides;
        }

        /// <inheritdoc/>
        public override string Name => "Square";

        /// <summary>
        /// Gets or sets the sides of the square.
        /// </summary>
        /// <value>
        /// The sides of the square.
        /// </value>
        public double Sides { get; set; }

        /// <inheritdoc/>
        public override double CalculateArea() => 0.0;
    }
}
