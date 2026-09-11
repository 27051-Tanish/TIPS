namespace AdvancedLinqChallenge.Models.Enum
{
    /// <summary>
    /// Represents the various filter conditions.
    /// </summary>
    public enum FilterConditions
    {
        /// <summary>
        /// Represents the condition which checks whether the string contains the given input.
        /// </summary>
        Contains,

        /// <summary>
        /// Represents the condition which checks whether the string starts with the given input.
        /// </summary>
        StartsWith,

        /// <summary>
        /// Represents the condition which checks whether the string ends with the given input.
        /// </summary>
        EndsWith,

        /// <summary>
        /// Represents the condition which checks whether the value is greater than the given input.
        /// </summary>
        GreaterThanEqualTo,

        /// <summary>
        /// Represents the condition which checks whether the value is lesser than the given input.
        /// </summary>
        LesserThanEqualTo,
    }
}
