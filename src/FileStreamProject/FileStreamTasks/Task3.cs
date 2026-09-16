using System.IO;
using System.Text;
using FileStreamProject.Constants;

namespace FileStreamProject.FileStreamTasks
{
    /// <summary>
    /// Investigate Issues in Basic File usage.
    /// </summary>
    public static class Task3
    {
        /// <summary>
        /// Writing to file from memory stream and reading from file using file stream.
        /// </summary>
        /// <returns>The data written in the file.</returns>
        public static string FileUsage()
        {
            string path = FilePaths.FilePathTask4;
            string data = "This is some text data";

            // Fix of the starter code: Stream directly to disk, completely bypassing the redundant MemoryStream array copies.
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8))
            {
                writer.Write(data);
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                // Fix of the starter code: Use the StringBuilder to read from the buffer and append them to produce as a string
                // to prevent dynamic memory re-allocations.
                StringBuilder sb = new StringBuilder();
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                }

                return sb.ToString();
            }
        }
    }
}
