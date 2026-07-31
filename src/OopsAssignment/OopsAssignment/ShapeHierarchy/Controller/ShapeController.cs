using OopsAssignment.Helper;
using OopsAssignment.Helper.CustomException;
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
            ShapeMenu shapeMenu;
            do
            {
                this._view.ShapeHierarchyMenu();
                userChoice = this.GetChoice();
                shapeMenu = (ShapeMenu)userChoice;

                switch (shapeMenu)
                {
                    case ShapeMenu.Rectangle:
                        this.CreateRectangle();
                        break;
                    case ShapeMenu.Circle:
                        this.CreateCircle();
                        break;
                    case ShapeMenu.Exit:
                        this._view.ShowMessage("Closing shape hierarchy application.");
                        break;
                    default:
                        this._view.ShowMessage("Invalid input: Please enter 1, 2, or 3.");
                        break;
                }
            }
            while (shapeMenu != ShapeMenu.Exit);
        }

        /// <summary>
        /// Performs calculation logic for rectangle class.
        /// </summary>
        public void CreateRectangle()
        {
            Rectangle rectangle = new ();
            while (true)
            {
                this._view.ShowMessage("Enter color of the rectangle :");
                rectangle.Color = this._view.ReadInput();

                if (InputValidator.ValidateName(rectangle.Color))
                {
                    break;
                }

                this._view.ShowMessage("Please enter valid input for color.");
            }

            while (true)
            {
                this._view.ShowMessage("Enter the length of the rectangle :");
                rectangle.Length = this.GetInput();

                if (InputValidator.ValidateDimensions(rectangle.Length))
                {
                    break;
                }

                this._view.ShowMessage("Invalid entry for length.\nLength should be positive and should not exceed the limit.");
            }

            while (true)
            {
                this._view.ShowMessage("Enter the width of the rectangle :");
                rectangle.Width = this.GetInput();

                if (InputValidator.ValidateDimensions(rectangle.Width))
                {
                    break;
                }

                this._view.ShowMessage("Invalid entry for width.\nWidth should be positive and should not exceed the limit.");
            }

            try
            {
                this._view.ShowMessage(rectangle.PrintDetails());
            }
            catch (MaxValueException ex)
            {
                this._view.ShowMessage($"Error :{ex.Message}");
            }
        }

        /// <summary>
        /// Performs calculation logic for circle class.
        /// </summary>
        public void CreateCircle()
        {
            Circle circle = new ();
            while (true)
            {
                this._view.ShowMessage("Enter color of the circle :");
                circle.Color = this._view.ReadInput();

                if (InputValidator.ValidateName(circle.Color))
                {
                    break;
                }

                this._view.ShowMessage("Please enter valid input for color.");
            }

            while (true)
            {
                this._view.ShowMessage("Enter the radius of the circle :");
                circle.Radius = this.GetInput();

                if (InputValidator.ValidateDimensions(circle.Radius))
                {
                    break;
                }

                this._view.ShowMessage("Invalid entry for radius.\nRadius should be positive and should not exceed the limit.");
            }

            try
            {
                this._view.ShowMessage(circle.PrintDetails());
            }
            catch (MaxValueException ex)
            {
                this._view.ShowMessage($"Error :{ex.Message}");
            }
        }

        /// <summary>
        /// Gets the user input for shape hierarchy application menu.
        /// </summary>
        /// <returns>Number representing choice from menu</returns>
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
        /// <returns>Dimensions of the shape.</returns>
        public double GetInput()
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
