using System.Runtime.CompilerServices;
using MusicalSequencer.Constants;

namespace Assignments
{
    /// <summary>
    /// Provides the main execution logic for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Provides the main entry point for the application.
        /// </summary>
        public static void Main()
        {
            List<string> notes = new List<string>();
            int duration = ApplicationConstants.DefaultPlaytime;
            string? choice;

            do
            {
                DisplayNotes(notes);
                Console.WriteLine("Available notes: " +
                    "[C, C#, D, D#, E, F, F#, G, G#, A, A#, B]");

                Console.WriteLine("Please select the note to play: (To close type 'Exit')");
                choice = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                for (int i = 0; i < choice.Length; i++)
                {
                    notes.Add(choice);
                    string singleNote = choice[i].ToString();
                    if (singleNote + 1 == "#")
                    {
                        singleNote += "#";
                    }

                    switch (singleNote)
                    {
                        case "C":
                            Console.Beep(261, duration);
                            break;
                        case "C#":
                            Console.Beep(277, duration);
                            break;
                        case "D":
                            Console.Beep(293, duration);
                            break;
                        case "D#":
                            Console.Beep(311, duration);
                            break;
                        case "E":
                            Console.Beep(329, duration);
                            break;
                        case "F":
                            Console.Beep(349, duration);
                            break;
                        case "F#":
                            Console.Beep(369, duration);
                            break;
                        case "G":
                            Console.Beep(392, duration);
                            break;
                        case "G#":
                            Console.Beep(415, duration);
                            break;
                        case "A":
                            Console.Beep(440, duration);
                            break;
                        case "A#":
                            Console.Beep(466, duration);
                            break;
                        case "B":
                            Console.Beep(493, duration);
                            break;
                        default:
                            Console.WriteLine("Please enter valid choice.");
                            break;
                    }
                }
            }
            while (choice != "Exit");
        }

        /// <summary>
        /// Displays the stored notes.
        /// </summary>
        /// <param name="notes">The list of musical notes.</param>
        public static void DisplayNotes(List<string> notes)
        {
            foreach (var note in notes)
            {
                Console.WriteLine($"Stored notes : {note}");
            }
        }
    }
}