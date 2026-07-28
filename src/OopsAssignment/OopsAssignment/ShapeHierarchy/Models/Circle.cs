namespace OopsAssignment.ShapeHierarchy.Models
{
    /// <summary>
    /// Inherits the Shapeinfo class and its methods and properties
    /// </summary>
    public class Circle : ShapeInfo
    {
        /// <summary>
        /// Stores the value of pi.
        /// </summary>
        public const double Pi = Math.PI;

        /// <summary>
        /// Gets or sets radius of the circle
        /// </summary>
        /// <value>
        /// Radius of the circle with the type double.
        /// </value>
        public double? Radius { get; set; }

        /// <summary>
        /// Prints the type of the shape.
        /// </summary>
        /// <returns>string representing circle</returns>
        public override string GetShapeType()
        {
            return "Circle";
        }

        /// <summary>
        /// Calculates the area of circle.
        /// </summary>
        /// <returns>double reperesenting area of circle</returns>s
        public override double? CalculateArea()
        {
            return Pi * this.Radius * this.Radius;
        }

        /// <summary>
        /// Prints the details of circle.
        /// </summary>
        /// <returns>string containing circle details</returns>
        public override string PrintDetails()
        {
            return $"Color: {this.Color}\nArea: {this.CalculateArea()}\nShape Type: {this.GetShapeType()}";
        }
    }
}
