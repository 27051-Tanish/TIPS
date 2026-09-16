using System.Text;

namespace FileStreamProject.FileStreamTasks
{
    /// <summary>
    /// Implement file data processor with asynchronous methods.
    /// </summary>
    public class Task2
    {
        /// <summary>
        /// Uses FileStream to read data from a large text file.
        /// </summary>
        /// <param name="sourcePath">The path of source file.</param>
        /// <param name="destinationPath">The path of the destination file.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task CreateLargeTextFileAsync(string sourcePath, string destinationPath)
        {
            long targetSize = 1L * 1024 * 1024 * 1024;
            byte[] buffer = new byte[4096]; // The size of the buffer is set to 4KB.

            using FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            using FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);

            long totalBytesWritten = 0;

            while (totalBytesWritten < targetSize)
            {
                int byteRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length);
                if (byteRead == 0)
                {
                    sourceStream.Position = 0;
                    continue;
                }

                long remainingBytes = targetSize - totalBytesWritten;
                int bytesToWrite = (int)Math.Min(byteRead, remainingBytes);
                await destinationStream.WriteAsync(buffer, 0, bytesToWrite);
                totalBytesWritten += bytesToWrite;
            }
        }

        /// <summary>
        /// Reads the content using the file stream.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <returns>The content read from the file using FileStreamer.</returns>
        public async Task<long> ReadFromStreamerAsync(string filePath)
        {
            byte[] buffer = new byte[4096];
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            long totalBytesRead = 0;
            int bytesRead;

            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
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
        public async Task<long> ReadFromBufferAsync(string filePath)
        {
            byte[] buffer = new byte[4096];
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            long totalBytesRead = 0;
            int bytesRead;
            using BufferedStream bufferStream = new BufferedStream(stream);

            while ((bytesRead = await bufferStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
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
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task WriteTheProcessedDataAsync(string sourceFile, string destinationFile)
        {
            byte[] buffer = new byte[4096];
            using FileStream inputStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
            using FileStream outputStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write);

            int bytesRead;

            while ((bytesRead = await inputStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                byte[] processData = this.ProcessToUpperCase(buffer, bytesRead);
                using MemoryStream memoryStream = new MemoryStream();
                await memoryStream.WriteAsync(processData, 0, processData.Length);
                await memoryStream.CopyToAsync(outputStream);
            }
        }

        /// <summary>
        /// Processes multiple files concurrently.
        /// </summary>
        /// <param name="sourceFiles">The source file paths.</param>
        /// <param name="destinationFiles">The destination file paths.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task ProcessMultipleFileAsync(string[] sourceFiles, string[] destinationFiles)
        {
            if (sourceFiles.Length != destinationFiles.Length)
            {
                throw new ArgumentException("Source and destination file counts must be the same.");
            }

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < sourceFiles.Length; i++)
            {
                tasks.Add(this.WriteTheProcessedDataAsync(sourceFiles[i], destinationFiles[i]));
            }

            await Task.WhenAll(tasks);
        }
    }
}
