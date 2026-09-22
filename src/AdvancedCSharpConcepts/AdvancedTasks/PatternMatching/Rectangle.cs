namespace AdvancedCSharpConcepts.AdvancedTasks.PatternMatching
{
    /// <summary>
    /// Provides properties required for the rectangle shape.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="length">The length of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        public Rectangle(double length, double width)
        {
            if (!double.IsFinite(length) || !double.IsFinite(width))
            {
                throw new ArgumentException("Rectangle dimensions must be finite, valid numbers.");
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length cannot be negative.");
            }

            if (width < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "Width cannot be negative.");
            }

            if (length > 0 && width > double.MaxValue / length)
            {
                throw new OverflowException("The dimensions are too large to calculate the area of the rectangle.");
            }

            this.Length = length;
            this.Width = width;
        }

        /// <inheritdoc/>
        public override string Name => "Rectangle";

        /// <summary>
        /// Gets the length of the rectangle.
        /// </summary>
        /// <value>
        /// The length of the rectangle.
        /// </value>
        public double Length { get; init; }

        /// <summary>
        /// Gets the width of the rectangle.
        /// </summary>
        /// <value>
        /// The width of the rectangle.
        /// </value>
        public double Width { get; init; }

        /// <inheritdoc/>
        public override double CalculateArea()
        {
            return this.Length * this.Width;
        }
    }
}
