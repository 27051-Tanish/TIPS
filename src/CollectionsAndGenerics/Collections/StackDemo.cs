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
        /// <param name="item">The name to be pushed into a stack.</param>
        public void PushName(T item)
        {
            this._stack.Push(item);
        }

        /// <summary>
        /// Pops a character from the stack and appends with the string variables.
        /// </summary>
        /// <returns>The stack after removing elements.</returns>
        public T PopName()
        {
            return this._stack.Pop();
        }

        /// <summary>
        /// Checks for the count in the stack.
        /// </summary>
        /// <returns>True if the stack is empty, otherwise false.</returns>
        public bool IsEmpty()
        {
            return this._stack.Count == 0;
        }
    }
}
