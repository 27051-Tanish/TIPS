using System;

namespace OopsAssignment.ShapeHierarchy.Models
{
    /// <summary>
    /// Gets or sets color value for shape
    /// </summary>
    public abstract class ShapeInfo
    {
        /// <summary>
        /// Gets or sets color.
        /// </summary>
        /// <value>
        /// Color of the circle as string.
        /// </value>
        public string? Color { get; set; }

        /// <summary>
        /// Gets or sets the type of the shape.
        /// </summary>
        /// <returns>string representing the shape type</returns>
        public abstract string GetShapeType();

        /// <summary>
        /// Gets or sets the values and calculates the area.
        /// </summary>
        /// <returns>double value representing area</returns>
        public abstract double? CalculateArea();

        /// <summary>
        /// Prints details of the shape.
        /// </summary>
        /// <returns>string representing the shape details</returns>
        public virtual string PrintDetails()
        {
            return $"Color: {this.Color}\nArea: {this.CalculateArea()}\nShape Type: {this.GetShapeType()}";
        }
    }
}
