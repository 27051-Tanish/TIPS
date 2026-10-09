namespace ReflectionsProject.Interfaces
{
    /// <summary>
    /// Acts as the contract with sample methods.
    /// </summary>
    public interface ISampleInterface
    {
        /// <summary>
        /// Adds two numbers and returns the sum.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The sum of 2 numbers.</returns>
        int Add(int a, int b);
    }
}
