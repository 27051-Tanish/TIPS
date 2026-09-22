using System.Security.Cryptography.X509Certificates;

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
            if (!double.IsFinite(radius))
            {
                throw new ArgumentException("Radius must be a finite, valid number.", nameof(radius));
            }

            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius cannot be negative.");
            }

            double maxRadius = Math.Sqrt(double.MaxValue / Math.PI);
            if (this.Radius > maxRadius)
            {
                throw new OverflowException("The radius is too big to calculate area of the circle.");
            }

            this.Radius = radius;
        }

        /// <inheritdoc/>
        public override string Name => "Circle";

        /// <summary>
        /// Gets the radius of the circle.
        /// </summary>
        /// <value>
        /// The radius of the circle.
        /// </value>
        public double Radius { get; init; }

        /// <inheritdoc/>
        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }
    }
}
