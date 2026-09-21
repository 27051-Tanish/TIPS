namespace AdvancedCSharpConcepts.AdvancedTasks.PatternMatching
{
    /// <summary>
    /// Represents a cube shape used to test unhandled or default type patterns.
    /// </summary>
    public class Cube : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cube"/> class.
        /// </summary>
        public Cube()
        {
            this.Name = "Cube";
        }

        /// <inheritdoc/>
        public override double CalculateArea() => 0.0;
    }
}
