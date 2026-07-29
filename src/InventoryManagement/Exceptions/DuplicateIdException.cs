namespace InventoryManagement.Exceptions
{
    /// <summary>
    /// Throws exception when the product id already exists.
    /// </summary>
    public class DuplicateIdException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateIdException"/> class.
        /// Throws exception when the product id already exists.
        /// </summary>
        /// <param name="id">Id of the product</param>
        public DuplicateIdException(string? id)
            : base($"Product id :{id} already exists")
        {
        }
    }
}
