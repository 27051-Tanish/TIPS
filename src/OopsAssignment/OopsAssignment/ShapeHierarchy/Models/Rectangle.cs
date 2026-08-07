namespace OopsAssignment.ShapeHierarchy.Models
{
    /// <summary>
    /// Represents a rectangular shape, inheriting shared shape properties and behaviors.
    /// </summary>
    public class Rectangle : ShapeInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="color">Color of the rectangle.</param>
        /// <param name="length">Length of the rectangle.</param>
        /// <param name="width">Width of the rectangle.</param>
        public Rectangle(string? color, double length, double width)
        {
            this.Color = color;
            this.Length = length;
            this.Width = width;
        }

        /// <summary>
        /// Gets or sets length.
        /// </summary>
        /// <value>
        /// Length of the rectangle.
        /// </value>
        public double Length { get; set; }

        /// <summary>
        /// Gets or sets width.
        /// </summary>
        /// <value>
        /// Width of the rectangle.
        /// </value>
        public double Width { get; set; }

        /// <summary>
        /// Prints the type of the shape.
        /// </summary>
        /// <returns>The name of the shape type.</returns>
        public override string GetShapeType()
        {
            return "Rectangle";
        }

        /// <summary>
        /// Calculates the area of the rectangle.
        /// </summary>
        /// <returns>The calculated area of rectangle.</returns>
        public override double? CalculateArea()
        {
            if (this.Length > 0 && this.Width > double.MaxValue / this.Length)
            {
                throw new OverflowException("The dimensions are too large to calculate the area of the rectangle.");
            }

            return this.Length * this.Width;
        }
    }
}
