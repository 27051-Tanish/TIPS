namespace FileStreamProject.Constants
{
    /// <summary>
    /// It maintains the file paths that are used across the application.
    /// </summary>
    public static class FilePaths
    {
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
        public static readonly string SampleTextFileTask3 = "Task3.txt";

        /// <summary>
        /// Gets the three different source files in the sampleFolder directory.
        /// </summary>
        /// <value>
        /// The three different source files in the sampleFolder directory.
        /// </value>
        public static string[] SourceFiles => new[]
        {
            "SampleFolder/file1.txt",
            "SampleFolder/file2.txt",
            "SampleFolder/file3.txt",
        };

        /// <summary>
        /// Gets the three different processed data files in the destination directory.
        /// </summary>
        /// <value>
        /// The three different processed data files in the destination directory.
        /// </value>
        public static string[] DestinationFiles => new[]
        {
            "Destination/file1.txt",
            "Destination/file2.txt",
            "Destination/file3.txt",
        };
    }
}
