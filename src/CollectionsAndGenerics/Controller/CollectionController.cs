using CollectionsAndGenerics.Collections;
using CollectionsAndGenerics.ConsoleView;
using CollectionsAndGenerics.Enum;
using CollectionsAndGenerics.Service;

namespace CollectionsAndGenerics.Controller
{
    /// <summary>
    /// Handles coordination between collection data and the user interface.
    /// </summary>
    public class CollectionController
    {
        private readonly CollectionService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionController"/> class.
        /// </summary>
        /// <param name="service">The instance of the service.</param>
        public CollectionController(CollectionService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Executes the different tasks based on user input.
        /// </summary>
        public void RunTasks()
        {
            int choice;
            MainMenu menu;

            do
            {
                View.ShowTitle("MAIN MENU");
                View.ShowMessage("[1]. Task list\n[2]. Task stack\n[3]. Task queue\n[4]. Task dictionary\n" +
                    "[5]. Sum of elements\n[6]. Task 6\n[7]. Exit");
                View.ShowMessage("Enter your choice:");
                choice = View.GetIntInput();
                menu = (MainMenu)choice;

                switch (menu)
                {
                    case MainMenu.TaskList:
                        this.ListTask();
                        break;
                    case MainMenu.TaskStack:
                        this.TaskStack();
                        break;
                    case MainMenu.TaskQueue:
                        this.TaskQueue();
                        break;
                    case MainMenu.TaskDictionary:
                        this.TaskDictionary();
                        break;
                    case MainMenu.TaskEnumerable:
                        this.TaskSumOfElements();
                        break;
                    case MainMenu.TaskIReadOnlyDictionary:
                        this.GenerateDictionarys();
                        break;
                    case MainMenu.Exit:
                        View.ShowMessage("Closing the application...");
                        break;
                    default:
                        View.ShowMessage("Please select from menu [1 to 7].");
                        break;
                }
            }
            while (menu != MainMenu.Exit);
        }

        private void ListTask()
        {
            View.ShowTitle("List task");
            ListDemo<string> books = new ListDemo<string>();
            this._service.Add(books, "Ikigai");
            this._service.Add(books, "The 48 Laws of Power");
            this._service.Add(books, "The Alchemist");
            this._service.Add(books, "Ponniyin Selvan");
            this._service.Add(books, "Atomic habits");

            View.ShowMessage("List of books:\n");
            View.DisplayItems(books);

            this._service.Remove(books, "Ponniyin Selvan");
            View.ShowMessage("\nList of books after removing 'Ponniyin Selvan':\n");
            View.DisplayItems(books);

            View.ShowMessage($"\nIs there any book named 'Atomic habits': {this._service.Contains(books, "Atomic habits")}");

            View.ConsoleClose();
        }

        private void TaskStack()
        {
            View.ShowTitle("Stack task");

            View.ShowMessage("Enter the name to reverse: ");
            string? name = View.ReadInput();
            if (name == null)
            {
                View.ShowMessage("Name cannot be null or whitespace.");
                return;
            }

            string reverseName = this._service.ReverseString(name);

            View.ShowMessage($"Original name: {name}\nReverse name: {reverseName}");
            View.ConsoleClose();
        }

        private void TaskQueue()
        {
            View.ShowTitle("Queue task");
            QueueDemo<string> persons = new QueueDemo<string>();
            this._service.Enqueue(persons, "Tanish");
            this._service.Enqueue(persons, "dharanish");
            this._service.Enqueue(persons, "kavya");
            this._service.Enqueue(persons, "sukil");
            this._service.Enqueue(persons, "umayal");

            View.ShowMessage("People in the queue:\n");
            View.DisplayItems(persons);

            this._service.Dequeue(persons);
            View.ShowMessage("\nQueue after removing first person:\n");
            View.DisplayItems(persons);

            View.ConsoleClose();
        }

        private void TaskDictionary()
        {
            View.ShowTitle("Dictionary task");

            DictionaryDemo<string, int> students = new DictionaryDemo<string, int>();
            this._service.AddKeyValuePair(students, "Tanish", 99);
            this._service.AddKeyValuePair(students, "dharanish", 99);
            this._service.AddKeyValuePair(students, "kavya", 99);
            this._service.AddKeyValuePair(students, "sukil", 99);
            this._service.AddKeyValuePair(students, "umayal", 99);

            View.ShowMessage("Students in the dictionary: \n");
            View.DisplayDictionary(students);

            View.ShowMessage("\nStudents in the list after removing 'Tanish':\n");
            this._service.RemoveKey(students, "Tanish", 99);
            View.DisplayDictionary(students);

            View.ShowMessage("\nIs there any student named 'dharanish':");
            bool student = this._service.ContainsKey(students, "dharanish");
            View.ShowMessage(student ? "Yes" : "No");

            View.ConsoleClose();
        }

        private void TaskSumOfElements()
        {
            View.ShowTitle("IEnumerable task");

            int[] array = { 1, 2, 3, 4, 5 };
            int sum = this._service.SumOfElements(array);
            View.ShowMessage($"Sum of elements in array: {sum}");

            List<int> numbers = new List<int>() { 10, 20, 30, 40, 50 };
            int sum1 = this._service.SumOfElements(numbers);
            View.ShowMessage($"\nsum of elements in list: {sum1}\n");

            View.ConsoleClose();
        }

        private void GenerateDictionarys()
        {
            IReadOnlyDictionary<string, int> dictionary = this._service.GenerateDictionary();
            View.PrintDictionary(dictionary);
            View.ConsoleClose();
        }
    }
}
