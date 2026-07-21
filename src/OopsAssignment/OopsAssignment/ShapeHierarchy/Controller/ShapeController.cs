using System;
using OopsAssignment.ShapeHierarchy.Models;
using OopsAssignment.ShapeHierarchy.View;
using Rectangle = OopsAssignment.ShapeHierarchy.Models.Rectangle;

namespace OopsAssignment.ShapeHierarchy.Controller
{
    /// <summary>
    /// Handles the communication between view and models
    /// </summary>
    public class ShapeController
    {
        // Changed to non-nullable because the controller requires a view to function
        private readonly ShapeView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeController"/> class.
        /// </summary>
        /// <param name="view">The view instance</param>
        public ShapeController(ShapeView view)
        {
            // Fail fast: Prevent the controller from being created with a null view
            this._view = view ?? throw new ArgumentNullException(nameof(view), "ShapeView cannot be null.");
        }

        /// <summary>
        /// Starts the execution of the Shape project
        /// </summary>
        public void RunShape()
        {
            int userChoice;
            do
            {
                this._view.ShowMessage("[1].Rectangle");
                this._view.ShowMessage("[2].Circle");
                this._view.ShowMessage("[3].Exit"); // Added exit option to prevent infinite loop

                userChoice = Convert.ToInt32(this._view.ReadInput());

                switch (userChoice)
                {
                    case 1:
                        GetRectangle();
                        break;
                    case 2:
                        GetCircle();
                        break;
                    case 3:
                        this._view.ShowMessage("Exiting program...");
                        break;
                    default:
                        this._view.ShowMessage("Invalid input: Please enter 1, 2, or 3");
                        break;
                }
            }
            while (userChoice != 3); // Loop continues until user chooses to exit
        }

        /// <summary>
        /// Performs logic for rectangle class
        /// </summary>
        public void GetRectangle()
        {
            Rectangle rectangle = new Rectangle();
            this._view.ShowMessage("Enter the color of the rectangle");
            rectangle.Color = this._view.ReadInput();
            this._view.ShowMessage("Enter the Length of the rectangle");
            rectangle.Length = Convert.ToDouble(this._view.ReadInput());
            this._view.ShowMessage("Enter the Width of the rectangle");
            rectangle.Width = Convert.ToDouble(this._view.ReadInput());

            rectangle.GetShapeType();
            rectangle.CalculateArea();
            this._view.ShowMessage(rectangle.PrintDetails());
        }

        /// <summary>
        /// Performs operation on circle class
        /// </summary>
        public void GetCircle()
        {
            Circle circle = new Circle();
            this._view.ShowMessage("Enter the color of the circle");
            circle.Color = this._view.ReadInput();
            this._view.ShowMessage("Enter the radius of the circle");
            circle.Radius = Convert.ToDouble(this._view.ReadInput());

            circle.GetShapeType();
            circle.CalculateArea();
            this._view.ShowMessage(circle.PrintDetails());
        }
    }
}