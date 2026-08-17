namespace InventoryManagement.Helper
{
    /// <summary>
    /// Variables of constant values that used across the application.
    /// </summary>
    public static class ConstantVariables
    {
        /// <summary>
        /// Stores the constant value of minimum length of the name.
        /// </summary>
        public const int MinimumNameLength = 2;

        /// <summary>
        /// Stores the constant value of maximum length of the name.
        /// </summary>
        public const int MaximumNameLength = 50;

        /// <summary>
        /// Stores the constant value of minimum price value.
        /// </summary>
        public const decimal MinimumPriceValue = 0m;

        /// <summary>
        /// Stores the constant value of maximum price value.
        /// </summary>
        public const decimal MaximumPriceValue = 10000000m;

        /// <summary>
        /// Stores the constant value of minimum quantity value.
        /// </summary>
        public const int MinimumQuantity = 1;

        /// <summary>
        /// Stores the constant value of maximum quantity value.
        /// </summary>
        public const int MaximumQuantity = 1000;

        /// <summary>
        /// Stores the constant value of maximum attempts to get input.
        /// </summary>
        public const int MaxAttempts = 5;
    }
}
