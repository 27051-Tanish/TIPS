namespace CollectionsAndGenerics.Collections
{
    /// <summary>
    /// Perform different operations in the stack.
    /// </summary>
    /// <typeparam name="T">Type of the stack.</typeparam>
    public class StackDemo<T>
    {
        private Stack<T> _stack = new Stack<T>();

        /// <summary>
        /// Pushes the characters of the string into a stack.
        /// </summary>
        /// <param name="name">The name to be pushed into a stack.</param>
        public void PushName(T name)
        {
            foreach (T c in name)
            {
                this._stack.Push(c);
            }

            Console.WriteLine($"original name: {name}");
        }

        /// <summary>
        /// Pops a character from the stack and appends with the string variables.
        /// </summary>
        public void PopName()
        {
            string reverse = " ";
            while (this._stack.Count > 0)
            {
                reverse += this._stack.Pop();
            }

            Console.WriteLine($"Reversed name: {reverse}");
        }
    }
}
