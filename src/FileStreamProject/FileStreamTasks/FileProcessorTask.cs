using System.Text;

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
        public void ReadFromStreamer(string filePath)
        {
            byte[] buffer = new byte[4096];
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
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
            byte[] internalBuffer = new byte[64 * 1024];

            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            long totalBytesRead = 0;
            int bytesRead;
            using BufferedStream bufferStream = new BufferedStream(stream, internalBuffer.Length);

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
            using MemoryStream memoryStream = new MemoryStream();

            while ((charsRead = reader.Read(buffer, 0, buffer.Length)) > 0)
            {
                string upperData = new string(buffer, 0, charsRead).ToUpper();
                byte[] processedData = Encoding.UTF8.GetBytes(upperData);

                memoryStream.SetLength(0);
                memoryStream.Write(processedData, 0, processedData.Length);
                memoryStream.Position = 0;
                memoryStream.CopyTo(outputStream);
            }
        }
    }
}
