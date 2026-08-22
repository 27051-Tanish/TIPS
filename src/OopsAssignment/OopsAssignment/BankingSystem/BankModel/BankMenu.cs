namespace OopsAssignment.BankingSystem.BankModel
{
    /// <summary>
    /// Defines menu for bank types.
    /// </summary>
    public enum BankMenu
    {
        /// <summary>
        /// Represents savings account for performing banking operations.
        /// </summary>
        Savings = 1,

        /// <summary>
        /// Represents checking account for performing banking operations.
        /// </summary>
        Checking,

        /// <summary>
        /// Represents exit operation of the banking application.
        /// </summary>
        Exit,
    }

    /// <summary>
    /// Defines menu for banking operations.
    /// </summary>
    public enum BankOperations
    {
        /// <summary>
        /// Represents deposit operation.
        /// </summary>
        Deposit = 1,

        /// <summary>
        /// Represents withdraw operation.
        /// </summary>
        Withdraw,

        /// <summary>
        /// Represents exit operation from banking operation menu.
        /// </summary>
        Exit,
    }
}
