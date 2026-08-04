namespace OopsAssignment.Helper.ConstantVariables
{
    /// <summary>
    /// Provides constant values used across the banking application.
    /// </summary>
    public static class AccountConstants
    {
        /// <summary>
        /// Minimum balance for savings account.
        /// </summary>
        public const decimal MinimumBalance = 1000m;

        /// <summary>
        /// Minimum length of the account number.
        /// </summary>
        public const int MinimumAccountNumberLength = 9;

        /// <summary>
        /// Maximum length of the account number.
        /// </summary>
        public const int MaximumAccountNumberLength = 18;
    }
}
