namespace InventoryManagement.Model.Enum
{
    /// <summary>
    /// Defines main menu navigation.
    /// </summary>
    public enum MenuEnum
    {
        /// <summary>
        /// Selects add function in menu.
        /// </summary>
        Insert = 1,

        /// <summary>
        /// Selects view function in menu.
        /// </summary>
        View,

        /// <summary>
        /// Selects edit function in menu.
        /// </summary>
        Edit,

        /// <summary>
        /// Selects remove function in menu.
        /// </summary>
        Remove,

        /// <summary>
        /// Selects search function in menu.
        /// </summary>
        Search,

        /// <summary>
        /// Selects exit function in menu.
        /// </summary>
        Exit,
    }

    /// <summary>
    /// Defines edit menu navigation.
    /// </summary>
    public enum EditMenu
    {
        /// <summary>
        /// Selects edit operation of name.
        /// </summary>
        Name = 1,

        /// <summary>
        /// Selects edit operation of price.
        /// </summary>
        Price,

        /// <summary>
        /// Selects edit operation of quantity.
        /// </summary>
        Quantity,

        /// <summary>
        /// Selects exit operation.
        /// </summary>
        Exit,
    }
}
