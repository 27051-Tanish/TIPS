namespace AdvancedLinqChallenge.Models
{
    /// <summary>
    /// Defines properties for the supplier class.
    /// </summary>
    public class SupplierInfo
    {
        /// <summary>
        /// Gets or sets the supplier id.
        /// </summary>
        /// <value>
        /// The supplier id.
        /// </value>
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the supplier name.
        /// </summary>
        /// <value>
        /// The supplier name.
        /// </value>
        public string SupplierName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The user id.
        /// </value>
        public Guid ProductId { get; set; }
    }
}
