using System.Text;

namespace FileStreamProject.Constants.Utility
{
    /// <summary>
    /// Provides mechanism for generating large text file.
    /// </summary>
    public static class FileGenerator
    {
        /// <summary>
        /// Uses FileStream to generate a large file from constant sample data.
        /// </summary>
        /// <param name="dataFilePath">The path of source file.</param>
        public static void CreateLargeTextFile(string dataFilePath)
        {
            string sampleRow = DataConstants.SampleData;
            long targetSize = 1L * 1024 * 1024 * 1024;
            byte[] buffer = Encoding.UTF8.GetBytes(sampleRow);
            long totalBytesWritten = 0;

            using FileStream dataStream = new FileStream(dataFilePath, FileMode.Create, FileAccess.Write);
            using BufferedStream bufferedStream = new BufferedStream(dataStream, 64 * 1024);
            while (totalBytesWritten < targetSize)
            {
                bufferedStream.Write(buffer, 0, buffer.Length);
                totalBytesWritten += buffer.Length;
            }
        }

        /// <summary>
        /// Generates multiple large testing source files dynamically at runtime if they do not already exist.
        /// </summary>
        /// <param name="sourceFiles">An array of target file paths to be checked or created.</param>
        /// <param name="sizePerFileInBytes">The targeted file size limit constraint in bytes.</param>
        public static void EnsureMultipleSourceFilesExist(string[] sourceFiles, long sizePerFileInBytes)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes("Hello, this is the file stream project.\n");

            foreach (string filePath in sourceFiles)
            {
                if (File.Exists(filePath))
                {
                    continue;
                }

                long bytesWritten = 0;
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    while (bytesWritten < sizePerFileInBytes)
                    {
                        fs.Write(buffer, 0, buffer.Length);
                        bytesWritten += buffer.Length;
                    }
                }
            }
        }
    }
}
