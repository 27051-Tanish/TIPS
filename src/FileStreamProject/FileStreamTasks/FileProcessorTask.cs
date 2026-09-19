using System.Text;
using FileStreamProject.Constants;

namespace FileStreamProject.FileStreamTasks
{
    /// <summary>
    /// Implements file data processor and manages the execute read from file stream and buffer stream.
    /// </summary>
    public class FileProcessorTask
    {
        /// <summary>
        /// Reads the content using the file stream.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <returns>The content read from the file using FileStreamer.</returns>
        public long ReadFromStreamer(string filePath)
        {
            byte[] buffer = new byte[4096];
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            long totalBytesRead = 0;
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalBytesRead += bytesRead;
            }

            return totalBytesRead;
        }

        /// <summary>
        /// Reads the content using the buffered file stream.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <returns>The content read from the file using BufferedStreamer.</returns>
        public long ReadFromBuffer(string filePath)
        {
            byte[] buffer = new byte[4096];
            byte[] internalBuffer = new byte[64 * 1024];

            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            long totalBytesRead = 0;
            int bytesRead;
            using BufferedStream bufferStream = new BufferedStream(stream, internalBuffer.Length);

            while ((bytesRead = bufferStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalBytesRead += bytesRead;
            }

            return totalBytesRead;
        }

        /// <summary>
        /// Converts a specified number of bytes from a buffer into a UTF-8 string,
        /// transforms it to uppercase, and returns the result as a new UTF-8 byte array.
        /// </summary>
        /// <param name="buffer">The byte array containing the data to process.</param>
        /// <param name="bytesRead">The number of bytes to read from the buffer starting at index 0.</param>
        /// <returns>A new byte array containing the uppercase UTF-8 encoded data.</returns>
        public byte[] ProcessToUpperCase(byte[] buffer, int bytesRead)
        {
            string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            string upperCaseData = data.ToUpper();
            return Encoding.UTF8.GetBytes(upperCaseData);
        }

        /// <summary>
        /// Reads a source file in chunks, processes its content to uppercase, 
        /// and writes the transformed data into a new destination file.
        /// </summary>
        /// <param name="sourceFile">The file path of the input file to read from.</param>
        /// <param name="destinationFile">The file path of the output file to create.</param>
        public void WriteTheProcessedData(string sourceFile, string destinationFile)
        {
            byte[] buffer = new byte[4096];
            using FileStream inputStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
            using FileStream outputStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write);

            int bytesRead;

            while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                byte[] processData = this.ProcessToUpperCase(buffer, bytesRead);
                using MemoryStream memoryStream = new MemoryStream();
                memoryStream.Write(processData, 0, processData.Length);
                memoryStream.WriteTo(outputStream);
            }
        }
    }
}
