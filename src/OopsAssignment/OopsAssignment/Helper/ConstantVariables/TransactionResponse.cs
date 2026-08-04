namespace OopsAssignment.Helper.ConstantVariables
{
    /// <summary>
    /// Provides standard response messages for transaction operations.
    /// </summary>
    public static class TransactionResponse
    {
        /// <summary>
        /// Gets the standard error message for a failed debit operation.
        /// </summary>
        /// <returns>A message indicating that the debit operation failed.</returns>
        public static string GetFailureMessage() => "Debit operation failed";

        /// <summary>
        /// Gets a standard success message for a successful debit operation.
        /// </summary>
        /// <param name="balance">The remaining account balance after the debit.</param>
        /// <returns>A message indicating success and the current balance.</returns>
        public static string GetSuccessMessage(decimal balance) => $"Debit operation successful\nBalance: {balance}";
    }
}
