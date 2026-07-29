using OopsAssignment;
using OopsAssignment.ShapeHierarchy.Models;
using Rectangle = OopsAssignment.ShapeHierarchy.Models.Rectangle;

namespace OopsAssignment.ShapeHierarchy.Controller
{
    /// <summary>
    /// Handles the communication between view and models.
    /// </summary>
    public class ShapeController
    {
        private readonly ProjectConsoleView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeController"/> class.
        /// </summary>
        /// <param name="view">The view instance</param>
        public ShapeController(ProjectConsoleView view)
        {
            this._view = view;
        }

        /// <summary>
        /// Starts the execution of the Shape project.
        /// </summary>
        public void StartShapeHierarchy()
        {
            int userChoice;
            do
            {
                this._view.EndLine();
                this._view.ShowMessage("[1].Rectangle");
                this._view.ShowMessage("[2].Circle");
                this._view.ShowMessage("[3].Exit");
                this._view.EndLine();

                userChoice = this.GetChoice();
                ShapeMenu shapeMenu = (ShapeMenu)userChoice;

                switch (shapeMenu)
                {
                    case ShapeMenu.Rectangle:
                        this.GetRectangle();
                        break;
                    case ShapeMenu.Circle:
                        this.GetCircle();
                        break;
                    case ShapeMenu.Exit:
                        this._view.ShowMessage("Closing shape hierarchy application.");
                        break;
                    default:
                        this._view.ShowMessage("Invalid input: Please enter 1, 2, or 3.");
                        break;
                }
            }
            while (userChoice != 3);
        }

        /// <summary>
        /// Performs calculation logic for rectangle class.
        /// </summary>
        public void GetRectangle()
        {
            Rectangle rectangle = new ();
            do
            {
                this._view.ShowMessage("Enter color of the rectangle :");
                rectangle.Color = this._view.ReadInput();
                if (!InputValidator.ValidateName(rectangle.Color))
                {
                    this._view.ShowMessage("Invalid input for color");
                }
            }
            while (!InputValidator.ValidateName(rectangle.Color));
            this._view.ShowMessage("Enter the length of the rectangle :");
            rectangle.Length = this.GetShapeDimensions();
            this._view.ShowMessage("Enter the width of the rectangle :");
            rectangle.Width = this.GetShapeDimensions();

            this._view.ShowMessage(rectangle.PrintDetails());
        }

        /// <summary>
        /// Performs calculation logic for circle class.
        /// </summary>
        public void GetCircle()
        {
            Circle circle = new ();
            do
            {
                this._view.ShowMessage("Enter color of the circle :");
                circle.Color = this._view.ReadInput();
                if (!InputValidator.ValidateName(circle.Color))
                {
                    this._view.ShowMessage("Invalid input for color.");
                }
            }
            while (!InputValidator.ValidateName(circle.Color));
            this._view.ShowMessage("Enter the radius of the circle :");
            circle.Radius = this.GetShapeDimensions();

            this._view.ShowMessage(circle.PrintDetails());
        }

        /// <summary>
        /// Gets the user input for shape hierarchy application menu.
        /// </summary>
        /// <returns>Int value representing choice from menu</returns>
        public int GetChoice()
        {
            while (true)
            {
                if (int.TryParse(this._view.ReadInput(), out int choiceValue))
                {
                    return choiceValue;
                }
                else
                {
                    this._view.ShowMessage("Please enter valid choice");
                }
            }
        }

        /// <summary>
        /// Gets user input for length, width, and radius.
        /// </summary>
        /// <returns>double representing the dimensions</returns>
        public double GetShapeDimensions()
        {
            while (true)
            {
                if (double.TryParse(this._view.ReadInput(), out double value))
                {
                    return value;
                }
                else
                {
                    this._view.ShowMessage("Invalid dimension value\nEnter again :");
                }
            }
        }
    }
}