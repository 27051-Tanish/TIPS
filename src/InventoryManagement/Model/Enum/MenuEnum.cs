namespace InventoryManagement.Model.Enum
{
    /// <summary>
    /// Defines main menu navigation.
    /// </summary>
    public enum MenuEnum
    {
        /// <summary>
        /// Represents add function in menu.
        /// </summary>
        Insert = 1,

        /// <summary>
        /// Represents view function in menu.
        /// </summary>
        View,

        /// <summary>
        /// Represents edit function in menu.
        /// </summary>
        Edit,

        /// <summary>
        /// Represents remove function in menu.
        /// </summary>
        Remove,

        /// <summary>
        /// Represents search function in menu.
        /// </summary>
        Search,

        /// <summary>
        /// Represents exit function in menu.
        /// </summary>
        Exit,
    }

    /// <summary>
    /// Defines edit menu navigation.
    /// </summary>
    public enum EditMenu
    {
        /// <summary>
        /// Represents edit operation of name.
        /// </summary>
        Name = 1,

        /// <summary>
        /// Represents edit operation of price.
        /// </summary>
        Price,

        /// <summary>
        /// Represents edit operation of quantity.
        /// </summary>
        Quantity,

        /// <summary>
        /// Represents exit operation.
        /// </summary>
        Exit,
    }

    /// <summary>
    /// Defines the category used to edit.
    /// </summary>
    public enum EditOption
    {
        /// <summary>
        /// Represents the id option used for editing.
        /// </summary>
        Id = 1,

        /// <summary>
        /// Represents the name option used for editing.
        /// </summary>
        Name,

        /// <summary>
        /// Represents exit option used for editing.
        /// </summary>
        Exit,
    }
}
