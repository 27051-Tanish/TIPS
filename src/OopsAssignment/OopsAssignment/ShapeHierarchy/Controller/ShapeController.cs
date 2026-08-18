using OopsAssignment.Helper;
using OopsAssignment.ShapeHierarchy.Models;
using Rectangle = OopsAssignment.ShapeHierarchy.Models.Rectangle;

namespace OopsAssignment.ShapeHierarchy.Controller
{
    /// <summary>
    /// Controls the communication between view and shape model components.
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
                this._view.ShowMenu("[1]. Rectangle\n[2]. Circle\n[3]. Exit");
                userChoice = this._view.GetChoice("Please enter valid choice from [1 to 3]\nPlease enter again :");
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

        private void CreateRectangle()
        {
            string? color;
            double length, width;
            while (true)
            {
                this._view.ShowMessage("Enter color of the rectangle :");
                color = this._view.ReadInput();

                if (InputValidator.ValidateName(color))
                {
                    break;
                }

                this._view.ShowMessage("Please enter valid input for color.");
            }

            while (true)
            {
                this._view.ShowMessage("Enter the length of the rectangle :");
<<<<<<< HEAD
                length = this._view.GetInput();
=======
                length = this.GetInput();
>>>>>>> 17d2e2e3cefcb344d9ed2f92709ef00e9eddc480

                if (InputValidator.ValidateDimension(length))
                {
                    break;
                }

                this._view.ShowMessage("Invalid entry for length.\nLength should be positive and should not exceed the limit.");
            }

            while (true)
            {
                this._view.ShowMessage("Enter the width of the rectangle :");
<<<<<<< HEAD
                width = this._view.GetInput();
=======
                width = this.GetInput();
>>>>>>> 17d2e2e3cefcb344d9ed2f92709ef00e9eddc480

                if (InputValidator.ValidateDimension(width))
                {
                    break;
                }

                this._view.ShowMessage("Invalid entry for width.\nWidth should be positive and should not exceed the limit.");
            }

            try
            {
                Rectangle rectangle = new (color, length, width);
                this._view.ShowMessage(rectangle.PrintDetails());
            }
            catch (OverflowException ex)
            {
                this._view.ShowMessage($"Error :{ex.Message}");
            }
        }

        private void CreateCircle()
        {
            string? color;
            double radius;
            while (true)
            {
                this._view.ShowMessage("Enter color of the circle :");
                color = this._view.ReadInput();

                if (InputValidator.ValidateName(color))
                {
                    break;
                }

                this._view.ShowMessage("Please enter valid input for color.");
            }

            while (true)
            {
                this._view.ShowMessage("Enter the radius of the circle :");
<<<<<<< HEAD
                radius = this._view.GetInput();
=======
                radius = this.GetInput();
>>>>>>> 17d2e2e3cefcb344d9ed2f92709ef00e9eddc480

                if (InputValidator.ValidateDimension(radius))
                {
                    break;
                }

                this._view.ShowMessage("Invalid entry for radius.\nRadius should be positive and should not exceed the limit.");
            }

            try
            {
                Circle circle = new (color, radius);
                this._view.ShowMessage(circle.PrintDetails());
            }
            catch (OverflowException ex)
            {
                this._view.ShowMessage($"Error :{ex.Message}");
            }
        }
<<<<<<< HEAD
=======

        private double GetInput()
        {
            while (true)
            {
                if (double.TryParse(this._view.ReadInput(), out double value))
                {
                    return value;
                }
                else
                {
                    this._view.ShowMessage("Invalid input for dimension.\nEnter again :");
                }
            }
        }
>>>>>>> 17d2e2e3cefcb344d9ed2f92709ef00e9eddc480
    }
}
