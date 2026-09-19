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

            while (totalBytesWritten < targetSize)
            {
                dataStream.Write(buffer, 0, buffer.Length);
                totalBytesWritten += buffer.Length;
            }
        }
    }
}
