namespace OopsAssignment.ShapeHierarchy.Models
{
    /// <summary>
    /// Inherits the Shapeinfo class and its methods and properties
    /// </summary>
    public class Rectangle : ShapeInfo
    {
        /// <summary>
        /// Gets or sets length.
        /// </summary>
        /// <value>
        /// Length of the rectangle in double type.
        /// </value>
        public double? Length { get; set; }

        /// <summary>
        /// Gets or sets width.
        /// </summary>
        /// <value>
        /// Width of the rectangle in double type.
        /// </value>
        public double? Width { get; set; }

        /// <summary>
        /// Prints the type of the shape.
        /// </summary>
        /// <returns>string representing rectangle</returns>
        public override string GetShapeType()
        {
            return "Rectangle";
        }

        /// <summary>
        /// Calculates the area of the rectangle.
        /// </summary>
        /// <returns>double area of rectangle value</returns>
        public override double? CalculateArea()
        {
            if (this.Length != null && this.Width != null)
            {
                return this.Length * this.Width;
            }

            return null;
        }

        /// <summary>
        /// Prints the details of rectangle.
        /// </summary>
        /// <returns>string containing rectangle details</returns>
        public override string PrintDetails()
        {
            return $"Color: {this.Color}\nArea: {this.CalculateArea()}\nShape Type: {this.GetShapeType()}";
        }
    }
}
