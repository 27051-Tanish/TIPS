namespace ExpenseTracker.Helper
{
    /// <summary>
    /// Validates the user input.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Validates the category of the transaction given from user.
        /// </summary>
        /// <param name="category">Source or category of monetary transaction.</param>
        /// <returns>True if the category is valid, otherwise false.</returns>
        public static bool ValidateCategory(string? category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return false;
            }

            if (category.Any(c => char.IsDigit(c)))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the amount of the monetary transaction for income and expense. 
        /// </summary>
        /// <param name="amount">The amount to be validated.</param>
        /// <returns>True if the amount is valid, otherwise false.</returns>
        public static bool ValidateAmount(decimal amount)
        {
            return amount > 0;
        }

        /// <summary>
        /// Validates the date of the income or expense.
        /// </summary>
        /// <param name="date">The date needs to validate.</param>
        /// <returns>True if the date is valid, otherwise false.</returns>
        public static bool ValidateDate(DateOnly date)
        {
            if (date > DateOnly.FromDateTime(DateTime.Now))
            {
                return false;
            }

            return true;
        }
    }
}
