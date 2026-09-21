using System.Collections.Generic;
using CollectionsAndGenerics.Collections;

namespace CollectionsAndGenerics.ConsoleView
{
    /// <summary>
    /// Provides console UI by calling methods that writes messages to the console.
    /// </summary>
    public static class View
    {
        /// <summary>
        /// Writes the message to the UI.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays a collection of items.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="items">The collection of items to display.</param>
        public static void DisplayItems<T>(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                ShowMessage(item.ToString() ?? string.Empty);
            }
        }

        /// <summary>
        /// Displays the title of the task in the UI.
        /// </summary>
        /// <param name="title">The title of the task.</param>
        public static void ShowTitle(string title)
        {
            ShowMessage(new string('=', 25));
            ShowMessage($"       {title}");
            ShowMessage(new string('=', 25));
        }

        /// <summary>
        /// Prints the dictionary.
        /// </summary>
        /// <param name="dictionary">A dictionary with the type IReadOnlyDictionary.</param>
        public static void PrintDictionary(IReadOnlyDictionary<string, int> dictionary)
        {
            foreach (var item in dictionary)
            {
                ShowMessage($"{item.Key}: {item.Value}");
            }
        }

        /// <summary>
        /// Displays the dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key.</typeparam>
        /// <typeparam name="TValue">The type of value.</typeparam>
        /// <param name="dictionary">The dictionary that needs to be displayed.</param>
        public static void DisplayDictionary<TKey, TValue>(DictionaryDemo<TKey, TValue> dictionary)
        {
            foreach (var item in dictionary)
            {
                ShowMessage($"{item.Key}: {item.Value}");
            }
        }

        /// <summary>
        /// Reads user input from the UI.
        /// </summary>
        /// <returns>The user input.</returns>
        public static string? ReadInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets user input for main menu
        /// </summary>
        /// <returns>Valid integer entered by the user.</returns>
        public static int GetIntInput()
        {
            while (true)
            {
                if (int.TryParse(ReadInput(), out int value))
                {
                    return value;
                }

                ShowMessage("Please enter valid input from menu [1 to 7].");
            }
        }

        /// <summary>
        /// Close the console after user entry.
        /// </summary>
        public static void ConsoleClose()
        {
            ShowMessage("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            ShowMessage("\x1b[3J");
        }
    }
}
