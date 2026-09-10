using CollectionsAndGenerics.Collections;

namespace CollectionsAndGenerics
{
    /// <summary>
    /// Contains the execution logic of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Provides the entry point to the application.
        /// </summary>
        public static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("=== MAIN MENU ===");
                Console.WriteLine("[1]. List\n[2]. Stack\n[3]. Queue\n[4]. Dictionary\n[5]. Generics\n[6]. IEnumerable\n[7]. Exit");
                Console.WriteLine("Enter your choice: ");
                choice = GetInput();
                switch (choice)
                {
                    case 1:
                        ListDemo<string> list = new ListDemo<string>();
                        list.AddBooks("The 48 Laws of Power");
                        list.AddBooks("Rich dad, Poor dad");
                        list.AddBooks("GOT");
                        list.AddBooks("Ikigai");
                        list.AddBooks("Ponniyin Selvan");
                        list.DisplayAfterAdding();
                        list.RemoveBooks("Ponniyin Selvan");
                        list.ContainBooks("GOT");
                        break;
                    case 2:
                        StackDemo<string> stack = new StackDemo<string>();
                        stack.PushName("Tanish");
                        stack.PopName();
                        break;
                    case 3:
                        QueueDemo queue = new QueueDemo();
                        queue.AddPerson();
                        queue.RemovePerson();
                        break;
                    case 4:
                        DictionaryDemo<string, int> dictionary = new DictionaryDemo<string, int>();
                        dictionary.AddStudents("Tanish", 99);
                        dictionary.AddStudents("Banish", 90);
                        dictionary.AddStudents("Canish", 88);
                        dictionary.AddStudents("Danish", 80);
                        dictionary.AddStudents("Eanish", 78);
                        dictionary.DisplayAfterAdding();
                        dictionary.RemoveStudents("Tanish");
                        break;
                    default:
                        Console.WriteLine("Please select from menu [1 to 7].");
                        break;
                }
            }
            while (choice != 7);
        }

        private static int GetInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    return choice;
                }

                Console.WriteLine("Invalid input. Try again.");
            }
        }
    }
}