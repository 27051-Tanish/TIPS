using System;

namespace OopsAssignment.BankingSystem.BankModel
{
    /// <summary>
    /// Enum for implementing bank menu.
    /// </summary>
    public enum BankMenu
    {
        /// <summary>
        /// Number representing the enum of savings account.
        /// </summary>
        Savings = 1,

        /// <summary>
        /// Number representing the enum of checking account.
        /// </summary>
        Checking,

        /// <summary>
        /// Number representing the enum for exiting.
        /// </summary>
        Exit,
    }

    /// <summary>
    /// Enum for implementing bank operations.
    /// </summary>
    public enum BankOperations
    {
        /// <summary>
        /// Number representing deposit method.
        /// </summary>
        Deposit = 1,

        /// <summary>
        /// Number representing withdraw method
        /// </summary>
        Withdraw,

        /// <summary>
        /// Number representing the enum for exiting.
        /// </summary>
        Exit,
    }
}
