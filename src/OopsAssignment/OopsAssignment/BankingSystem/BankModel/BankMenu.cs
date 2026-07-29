namespace OopsAssignment.BankingSystem.BankModel
{
    /// <summary>
    /// Defines menu for bank types.
    /// </summary>
    public enum BankMenu
    {
        /// <summary>
        /// Selects savings account for performing banking operations.
        /// </summary>
        Savings = 1,

        /// <summary>
        /// Selects checking account for performing banking operations.
        /// </summary>
        Checking,

        /// <summary>
        /// Exits the banking application.
        /// </summary>
        Exit,
    }

    /// <summary>
    /// Defines menu for banking operations.
    /// </summary>
    public enum BankOperations
    {
        /// <summary>
        /// Selects deposit operation.
        /// </summary>
        Deposit = 1,

        /// <summary>
        /// Selects withdraw operation.
        /// </summary>
        Withdraw,

        /// <summary>
        /// Exits from banking operation menu.
        /// </summary>
        Exit,
    }
}
