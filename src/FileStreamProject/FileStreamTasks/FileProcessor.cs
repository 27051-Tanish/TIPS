using System.Text;

namespace FileStreamProject.FileStreamTasks
{
    /// <summary>
    /// Implements file data processor and manages the execute read from file stream and buffer stream.
    /// </summary>
    public class FileProcessor
    {
        /// <summary>
        /// Reads the content using the file stream.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        public void ReadFromStreamer(string filePath)
        {
            byte[] buffer = new byte[4096];
            int bufferSize = 64 * 1024;
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize);
            long totalBytesRead = 0;
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalBytesRead += bytesRead;
            }
        }

        /// <summary>
        /// Reads the content using the buffered file stream.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        public void ReadFromBuffer(string filePath)
        {
            byte[] buffer = new byte[4096];
            int internalBuffer = 64 * 1024;

            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            long totalBytesRead = 0;
            int bytesRead;
            using BufferedStream bufferStream = new BufferedStream(stream, internalBuffer);

            while ((bytesRead = bufferStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalBytesRead += bytesRead;
            }
        }

        /// <summary>
        /// Reads a source file in chunks, processes its content to uppercase,
        /// and writes the transformed data into a new destination file.
        /// </summary>
        /// <param name="sourceFile">The file path of the input file to read from.</param>
        /// <param name="destinationFile">The file path of the output file to create.</param>
        public void WriteTheProcessedData(string sourceFile, string destinationFile)
        {
            char[] buffer = new char[4096];
            using StreamReader reader = new StreamReader(sourceFile, Encoding.UTF8);
            using FileStream outputStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write, FileShare.Read);

            int charsRead;
            int maxBufferSize = 64 * 1024;
            using MemoryStream memoryStream = new MemoryStream(maxBufferSize);

            while ((charsRead = reader.Read(buffer, 0, buffer.Length)) > 0)
            {
                string upperData = new string(buffer, 0, charsRead).ToUpperInvariant();
                byte[] processedData = Encoding.UTF8.GetBytes(upperData);

                memoryStream.Write(processedData, 0, processedData.Length);
                if (memoryStream.Length >= maxBufferSize)
                {
                    memoryStream.Position = 0;
                    memoryStream.CopyTo(outputStream);
                    memoryStream.SetLength(0); // Reset buffer size back to zero for the next batch
                }
            }

            if (memoryStream.Length > 0)
            {
                memoryStream.Position = 0;
                memoryStream.CopyTo(outputStream);
            }
        }
    }
}
