using System.IO;
using System.Text;
using FileStreamProject.Constants;

namespace FileStreamProject.FileStreamTasks
{
    /// <summary>
    /// Investigate Issues in Basic File usage.
    /// </summary>
    public static class BasicFileUsage
    {
        /// <summary>
        /// Writing to file from memory stream and reading from file using file stream.
        /// </summary>
        /// <returns>The data written in the file.</returns>
        public static string FileUsage()
        {
            string path = FilePaths.SampleTextFileTask3;
            string data = "This is some text data";

            // Fix of the starter code: Stream directly to disk, completely bypassing the redundant MemoryStream array copies.
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8))
            {
                writer.Write(data);
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
