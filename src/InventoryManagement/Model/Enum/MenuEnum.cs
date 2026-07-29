namespace InventoryManagement.Model.Enum
{
    /// <summary>
    /// Enum for representing menu values.
    /// </summary>
    public enum MenuEnum
    {
        /// <summary>
        /// Number representing add function in menu.
        /// </summary>
        Insert = 1,

        /// <summary>
        /// Number representing view function in menu.
        /// </summary>
        View,

        /// <summary>
        /// Number representing edit function in menu
        /// </summary>
        Edit,

        /// <summary>
        /// Number representing remove function in menu
        /// </summary>
        Remove,

        /// <summary>
        /// Number representing search function in menu
        /// </summary>
        Search,

        /// <summary>
        /// Number representing exit function in menu
        /// </summary>
        Exit,
    }

    /// <summary>
    /// Enum for representing edit menu values.
    /// </summary>
    public enum EditMenu
    {
        /// <summary>
        /// Number representing edit operation of name.
        /// </summary>
        Name = 1,

        /// <summary>
        /// Number representing edit operation of price.
        /// </summary>
        Price,

        /// <summary>
        /// Number representing edit operation of quantity.
        /// </summary>
        Quantity,

        /// <summary>
        /// Number representing exit operation.
        /// </summary>
        Exit,
    }
}
