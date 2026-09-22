using System.Text;
using System.Text.RegularExpressions;
using AdvancedCSharpConcepts.AdvancedTasks;
using AdvancedCSharpConcepts.AdvancedTasks.AdvancedDelegates;
using AdvancedCSharpConcepts.AdvancedTasks.PatternMatching;
using AdvancedCSharpConcepts.Enums;
using AdvancedCSharpConcepts.View;

namespace AdvancedCSharpConcepts.Controller
{
    /// <summary>
    /// Handles the data flow and communication between view and each tasks.
    /// </summary>
    public class TaskController
    {
        private readonly ConsoleView _consoleView;
        private readonly Notifier _notifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="consoleView">The instance of the view class handling user interface input and output.</param>
        /// <param name="notifier">The notification system used to broadcast event messages.</param>
        public TaskController(ConsoleView consoleView, Notifier notifier)
        {
            this._consoleView = consoleView;
            this._notifier = notifier;
        }

        /// <summary>
        /// Provides the execution of each tasks from the user input.
        /// </summary>
        public void RunApplication()
        {
            int choice;
            MainMenu menu;

            do
            {
                this._consoleView.ShowTitle("MAIN MENU");
                StringBuilder menuBuilder = new StringBuilder();
                foreach (MainMenu menuOption in Enum.GetValues<MainMenu>())
                {
                    int optionNumber = (int)menuOption;
                    string readableName = Regex.Replace(menuOption.ToString(), "([a-z])([A-Z])", "$1 $2");
                    menuBuilder.AppendLine($"{optionNumber}. {readableName}");
                }

                this._consoleView.ShowMessage(menuBuilder.ToString().TrimEnd());
                choice = this._consoleView.GetIntInput("Enter your choice: ");
                menu = (MainMenu)choice;

                switch (menu)
                {
                    case MainMenu.EventsAndDelegate:
                        this.PerformEventsTask();
                        break;
                    case MainMenu.DynamicAndVar:
                        this.ExecuteDifferentDataType();
                        break;
                    case MainMenu.AnonymousMethods:
                        this.ExecuteAnonymousMethod();
                        break;
                    case MainMenu.LambdaExpression:
                        this.ExecuteLambdaExpressionTask();
                        break;
                    case MainMenu.AdvancedDelegate:
                        this.ExecuteAdvancedDelegate();
                        break;
                    case MainMenu.RecordTask:
                        this.ExecuteBookRecord();
                        break;
                    case MainMenu.PatternMatching:
                        this.ExecutePatternMatching();
                        break;
                    case MainMenu.Exit:
                        break;
                    default:
                        this._consoleView.ShowMessage("Please select from the menu [1 to 8].");
                        break;
                }
            }
            while (menu != MainMenu.Exit);
        }

        private void PerformEventsTask()
        {
            // FIX: Unsubscribe first to clear out any legacy registrations from previous menu visits.
            this._notifier.OnAction -= this.EventNotification;
            this._notifier.OnAction += this.EventNotification;

            this._notifier.CallEvent("This event is triggered...");
            this._consoleView.ConsoleClear();
        }

        private void EventNotification(string message)
        {
            this._consoleView.ShowMessage(message);
        }

        private void ExecuteDifferentDataType()
        {
            this._consoleView.ShowMessage("\nPerforming operation with 'var' keyword\n");
            var content = "Tanish";

            // content = 10; Error: Cannot implicitly convert type 'int' to 'string'
            this._consoleView.ShowMessage($"When assigned a string value this is the output: {content}");

            this._consoleView.ShowMessage("\nPerforming operation with 'dynamic' keyword\n");
            dynamic value = "Tanish";
            this._consoleView.ShowMessage($"When assigned a string value this is the output: {value}");
            value = 10m;
            this._consoleView.ShowMessage($"When assigned a decimal value this is the output: {value}");

            this._consoleView.ConsoleClear();
        }

        private void ExecuteAnonymousMethod()
        {
            int[] numbers = { 23, 34, 12, 48, 82, 35, 6, 19, 27, 10 };
            this._consoleView.ShowMessage($"Before sorting the array: {string.Join(", ", numbers)}");

            int[] sortedNumbers = AnonymousMethodTask.SortAnArray(numbers);
            this._consoleView.ShowMessage($"\nAfter sorting the array: {string.Join(", ", sortedNumbers)}");

            this._consoleView.ConsoleClear();
        }

        private void ExecuteLambdaExpressionTask()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            this._consoleView.ShowMessage($"Original list: {string.Join(", ", numbers)}");

            List<int> filteredList = LambdaExpression.FilterAndSquareNumbers(numbers);
            this._consoleView.ShowMessage($"\nAfter applying the filter: {string.Join(", ", filteredList)}");
            this._consoleView.ConsoleClear();
        }

        private void ExecuteAdvancedDelegate()
        {
            List<Product> products = new List<Product>()
            {
                new Product { Name = "Watch", Category = "Accessories", Price = 1500m },
                new Product { Name = "Apple", Category = "Fruits", Price = 100m },
                new Product { Name = "Bike", Category = "Vehicle", Price = 150000m },
                new Product { Name = "Ponniyin Selvan", Category = "Books", Price = 500m },
                new Product { Name = "Phone", Category = "Electronics", Price = 25000m },
            };
            this._consoleView.ShowMessage("PRODUCTS IN THE LIST");
            this._consoleView.DrawSeparatorLine();
            this._consoleView.DisplaySortedProducts(products);
            this._consoleView.ShowMessage("\n");

            SortProducts.SortDelegate sort;
            sort = SortProducts.SortByName;
            List<Product> sortByName = SortProducts.GetSortedProducts(sort, products);
            this._consoleView.ShowMessage("SORT BY NAME");
            this._consoleView.DrawSeparatorLine();
            this._consoleView.DisplaySortedProducts(sortByName);
            this._consoleView.ShowMessage("\n");

            sort = SortProducts.SortByCategory;
            List<Product> sortByCategory = SortProducts.GetSortedProducts(sort, products);
            this._consoleView.ShowMessage("SORT BY CATEGORY");
            this._consoleView.DrawSeparatorLine();
            this._consoleView.DisplaySortedProducts(sortByCategory);
            this._consoleView.ShowMessage("\n");

            sort = SortProducts.SortByPrice;
            List<Product> sortByPrice = SortProducts.GetSortedProducts(sort, products);
            this._consoleView.ShowMessage("SORT BY PRICE");
            this._consoleView.DrawSeparatorLine();
            this._consoleView.DisplaySortedProducts(sortByPrice);

            this._consoleView.ConsoleClear();
        }

        private void ExecuteBookRecord()
        {
            Book book1 = new Book("The 48 Laws of Power", "Robert Greene", "978-0140280197");
            Book book2 = new Book("The 48 Laws of Power", "Robert Greene", "978-0140280197");
            Book book3 = new Book("Atomic Habits", "James Clear", "978-0735211292");
            Book book4 = new Book("Deep Work", "Cal Newport", "978-1455586691");
            Book book5 = new Book("Sapiens", "Yuval Noah Harari", "978-0062316097");

            bool isValueEqual = book1 == book2;
            this._consoleView.ShowMessage("Is the first book in the record and the second book in the record is equal:");
            this._consoleView.ShowMessage(isValueEqual ? "Yes" : "No"); // True
            this._consoleView.DrawSeparatorLine();

            this._consoleView.ShowMessage("\nThe values of the 4th book in the record before changing the author name.");
            this._consoleView.ShowMessage($"Book Name: {book4.Title}\nAuthor Name: {book4.AuthorName}\nISBN: {book4.Isbn}");

            // Note: book4.AuthorName = "Tanish";
            // This line was commented out because C# records use init properties. Trying to mutate it directly causes a compiler error.
            this._consoleView.ShowMessage("\nThe values of the 4th book in the record after trying to change the author name" +
                "which throws an compiler error.");
            this._consoleView.ShowMessage($"Book Name: {book4.Title}\nAuthor Name: {book4.AuthorName}\nISBN: {book4.Isbn}");
            this._consoleView.DrawSeparatorLine();

            Book updatedBook = book3 with
            {
                Title = "Atomic Habits: Special Edition",
                Isbn = "978-0000000000",
            };

            this._consoleView.ShowMessage("\nThe values of the 3rd book in the record before changing title and ISBN.");
            this._consoleView.ShowMessage($"Book Name: {book3.Title}\nAuthor Name: {book3.AuthorName}\nISBN: {book3.Isbn}");

            this._consoleView.ShowMessage("\nThe values of the 3rd book in the record after changing title and ISBN.");
            this._consoleView.ShowMessage($"Book Name: {updatedBook.Title}\nAuthor Name: {updatedBook.AuthorName}\nISBN: {updatedBook.Isbn}");
            this._consoleView.DrawSeparatorLine();

            this._consoleView.ShowMessage("Display the 5th book from the record.");
            this._consoleView.DisplayBook(book5);
            this._consoleView.DrawSeparatorLine();

            this._consoleView.ConsoleClear();
        }

        private void ExecutePatternMatching()
        {
            try
            {
                List<Shape> shapes = new List<Shape>()
                {
                    new Circle(4),
                    new Rectangle(4, 5),
                    new Triangle(3, 8),
                    new Square(4),
                    null!,
                };

                foreach (Shape shape in shapes)
                {
                    this.DisplayShapeDetails(shape);
                }

                this._consoleView.ConsoleClear();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                this._consoleView.ShowMessage($"{ex.Message}");
            }
            catch (OverflowException ex)
            {
                this._consoleView.ShowMessage($"{ex.Message}");
            }
        }

        private void DisplayShapeDetails(Shape shape)
        {
            switch (shape)
            {
                case Circle c:
                    this._consoleView.ShowMessage($"Shape: {c.Name} | Radius: {c.Radius} | Area: {c.CalculateArea():F2}");
                    break;

                case Rectangle r:
                    this._consoleView.ShowMessage($"Shape: {r.Name} | Dimensions: {r.Length}x{r.Width} | Area: {r.CalculateArea():F2}");
                    break;

                case Triangle t:
                    this._consoleView.ShowMessage($"Shape: {t.Name} | Base: {t.Base}, Height: {t.Height} | Area: {t.CalculateArea():F2}");
                    break;

                case null:
                    this._consoleView.ShowMessage("Error: The shape reference is null.");
                    break;

                default:
                    this._consoleView.ShowMessage("Error: Unknown or unsupported shape type.");
                    break;
            }
        }
    }
}
