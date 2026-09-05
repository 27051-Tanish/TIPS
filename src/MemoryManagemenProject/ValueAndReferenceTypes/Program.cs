using ValueAndReferenceTypes.PersonDetail;

namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Contains the main execution logic for performing basic value types and reference types demonstration.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Serves as the primary entry point of the application.
        /// </summary>
        public static void Main()
        {
            Person person = new Person();
            person.Name = "Badhusha";
            Person person1 = person;

            int ageOfPerson = 10;
            int ageOfPerson1 = ageOfPerson;
            Console.WriteLine("==================================================");
            Console.WriteLine("INITIAL STATE (Before modifying the objects and variables)");
            Console.WriteLine("==================================================");
            Console.WriteLine($"[Reference Type] Original Person Name: {person.Name}");
            Console.WriteLine($"[Reference Type] Copied Person1 Name: {person1.Name}");
            Console.WriteLine($"[Value Type] Original Age: {ageOfPerson}");
            Console.WriteLine($"[Value Type] Copied Age1: {ageOfPerson1}");
            Console.WriteLine();

            ModifyAndDisplay(person1, ageOfPerson1);
            Console.WriteLine("==================================================");
            Console.WriteLine("FINAL STATE (Verifying effects after applying the modifications.)");
            Console.WriteLine("==================================================");
            Console.WriteLine($"[Reference Type] Original Person Name: {person.Name} (CHANGED - Shares same reference)");
            Console.WriteLine($"[Value Type] Original Age: {ageOfPerson} (UNCHANGED - Passed by value)");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            Console.WriteLine("View heap allocation.");
            CreateLargeArray();
            Console.WriteLine();

            Console.WriteLine("View stack allocation.");
            CalculatingManyVariables();
            Console.WriteLine();
            Console.ReadKey();
        }

        /// <summary>
        /// Displays the value of both value type and reference type.
        /// </summary>
        /// <param name="person1">The person instance to be modified.</param>
        /// <param name="ageOfPerson1">The number to be modified.</param>
        public static void ModifyAndDisplay(Person person1, int ageOfPerson1)
        {
            person1.Name = "Badhusha1";
            ageOfPerson1 = 20;
            Console.WriteLine("==================================================");
            Console.WriteLine("INSIDE METHOD (Modifications Applied)");
            Console.WriteLine("==================================================");
            Console.WriteLine($"[Inside Method] person1.Name changed to: {person1.Name}");
            Console.WriteLine($"[Inside Method] ageOfPerson1 changed to: {ageOfPerson1}");
            Console.WriteLine();
        }

        /// <summary>
        /// Creates an array with size of 1 million to observe the heap memory allocation.
        /// </summary>
        public static void CreateLargeArray()
        {
            Console.WriteLine("Creating a large array.");
            int[] largeArray = new int[1000000];
            largeArray[0] = 1;
            largeArray[largeArray.Length - 1] = 100;
            Console.WriteLine($"The array size is {largeArray.Length}");
            Console.ReadLine();
        }

        /// <summary>
        /// Calculates multiple large number of local variable for observing the stack memory usage.
        /// </summary>
        public static void CalculatingManyVariables()
        {
            Console.WriteLine("Calculating multiple local variables.");
            int num1 = 8, num2 = 10, num3 = 12, num4 = 14, num5 = 15, num6 = 16, num7 = 17;
            long longNum1 = 12, longNum2 = 23, longNum3 = 33, longNum4 = 43, longNum5 = 53;
            double doubleNum1 = 10, doubleNum2 = 20, doubleNum3 = 30, doubleNum4 = 40;

            double result = (num1 + num2 + num3 + num4 + num5 + num6 + num7) * (longNum1 + longNum2 + longNum3 + longNum4 + longNum5)
                / (doubleNum1 + doubleNum2 + doubleNum3 + doubleNum4);

            Console.WriteLine($"Result of calculating the large number of local variables: {result}");
            Console.ReadLine();
        }
    }
}