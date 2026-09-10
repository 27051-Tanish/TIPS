namespace CollectionsAndGenerics.Collections
{
    /// <summary>
    /// Performs different operations in the queue.
    /// </summary>
    public class QueueDemo
    {
        private Queue<string> _persons = new Queue<string>();

        /// <summary>
        /// Adds the name of a person to the queue.
        /// </summary>
        /// <param name="person">The name of the person</param>
        public void AddPerson()
        {
            this._persons.Enqueue("Tanish");
            this._persons.Enqueue("Dharanish");
            this._persons.Enqueue("Sukil");
            this._persons.Enqueue("Kavya");
            this._persons.Enqueue("Umayal");

            Console.WriteLine("Persons in the queue: ");
            Console.WriteLine(new string('=', 20));
            this.DisplayPerson();
            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Press any key to continue with dequeue");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Removes the first person from the queue.
        /// </summary>
        public void RemovePerson()
        {
            this._persons.Dequeue();
            Console.WriteLine("Persons in the queue after removing the first person:");
            Console.WriteLine(new string('=', 20));
            this.DisplayPerson();
            Console.WriteLine(new string('=', 20));
        }

        /// <summary>
        /// Displays the name of the person in the queue.
        /// </summary>
        public void DisplayPerson()
        {
            foreach (string person in this._persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
