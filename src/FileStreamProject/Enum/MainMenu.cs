using FileStreamProject.FileStreamTasks;

namespace FileStreamProject.Enum
{
    /// <summary>
    /// Represents the options for main menu.
    /// </summary>
    public enum MainMenu
    {
        /// <summary>
        /// Represents the file data processor operation.
        /// </summary>
        Task1 = 1,

        /// <summary>
        /// Represents the file data processor with asynchronous methods operation.
        /// </summary>
        Task2,

        /// <summary>
        /// Represents the task which fixes the basic issue in file usage operation.
        /// </summary>
        Task3,

        /// <summary>
        /// Represents the task which analyze and resolve performance issues with logging system for multiple users.
        /// </summary>
        Task4,

        /// <summary>
        /// Represents the exit operation.
        /// </summary>
        Exit,
    }
}
