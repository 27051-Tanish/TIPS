namespace FileStreamProject.Constants
{
    /// <summary>
    /// It maintains the file paths that are used across the application.
    /// </summary>
    public static class FilePaths
    {
        /// <summary>
        /// It represents the 1 gb source file path.
        /// </summary>
        public static readonly string OneGbFile = "SourceData/SourceTextFile.txt";

        /// <summary>
        /// It represents the data file path.
        /// </summary>
        public static readonly string DataFilePath = "DataTextFile.txt";

        /// <summary>
        /// It represents the path of processed data.
        /// </summary>
        public static readonly string ProcessDataPath = "Destination/ProcessData.txt";

        /// <summary>
        /// It represents the path of the text file for performing task 4.
        /// </summary>
        public static readonly string FilePathTask4 = "Task4.txt";

        /// <summary>
        /// It represents three different source files.
        /// </summary>
        public static readonly string[] SourceFiles =
        {
            "Source/file1.txt",
            "Source/file2.txt",
            "Source/file3.txt",
        };

        /// <summary>
        /// It represents three different destination files.
        /// </summary>
        public static readonly string[] DestinationFiles =
        {
            "Destination/file1.txt",
            "Destination/file2.txt",
            "Destination/file3.txt",
        };
    }
}
