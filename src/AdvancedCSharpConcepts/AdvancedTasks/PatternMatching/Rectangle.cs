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
            this.Name = "Rectangle";
            this.Length = length;
            this.Width = width;
        }

        /// <summary>
        /// Gets or sets the length of the rectangle.
        /// </summary>
        /// <value>
        /// The length of the rectangle.
        /// </value>
        public double Length { get; set; }

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        /// <value>
        /// The width of the rectangle.
        /// </value>
        public double Width { get; set; }

        /// <inheritdoc/>
        public override double CalculateArea()
        {
            if (this.Length < 0 || this.Width < 0)
            {
                throw new ArgumentOutOfRangeException("Dimensions cannot be negative.");
            }

            if (this.Length > 0 && this.Width > double.MaxValue / this.Length)
            {
                throw new OverflowException("The dimensions are too large to calculate the area of the rectangle.");
            }

            return this.Length * this.Width;
        }
    }
}
