using System.Text;
using System.Threading;

namespace FileStreamProject.FileStreamTasks
{
    /// <summary>
    /// Implement file data processor with asynchronous methods.
    /// </summary>
    public class FileProcessorAsyncTask
    {
        private const int _bufferSize = 4096;

        /// <summary>
        /// Reads the content using the file stream.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The total number bytes read from the file using FileStreamer.</returns>
        public async Task<long> ReadFromStreamerAsync(string filePath, CancellationToken token = default)
        {
            byte[] buffer = new byte[_bufferSize];
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, _bufferSize, useAsync: true);
            long totalBytesRead = 0;
            int bytesRead;

            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
            {
                totalBytesRead += bytesRead;
            }

            return totalBytesRead;
        }

        /// <summary>
        /// Reads the content using the buffered file stream.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The total number bytes read from the file using BufferedStreamer.</returns>
        public async Task<long> ReadFromBufferAsync(string filePath, CancellationToken token = default)
        {
            byte[] buffer = new byte[_bufferSize];
            byte[] internalBuffer = new byte[64 * 1024];

            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, _bufferSize, useAsync: true);
            long totalBytesRead = 0;
            int bytesRead;
            using BufferedStream bufferStream = new BufferedStream(stream, internalBuffer.Length);

            while ((bytesRead = await bufferStream.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
            {
                totalBytesRead += bytesRead;
            }

            return totalBytesRead;
        }

        /// <summary>
        /// Reads a source file in chunks, processes its content to uppercase,
        /// and writes the transformed data into a new destination file.
        /// </summary>
        /// <param name="sourceFile">The file path of the input file to read from.</param>
        /// <param name="destinationFile">The file path of the output file to create.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task WriteTheProcessedDataAsync(string sourceFile, string destinationFile, CancellationToken token = default)
        {
            char[] buffer = new char[1 * 1024 * 1024];
            using StreamReader reader = new StreamReader(sourceFile, Encoding.UTF8);
            using FileStream outputStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 1 * 1024 * 1024, useAsync: true);

            int charsRead;

            while ((charsRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                token.ThrowIfCancellationRequested();

                string upperData = new string(buffer, 0, charsRead).ToUpper();
                byte[] processedData = Encoding.UTF8.GetBytes(upperData);

                await outputStream.WriteAsync(processedData, 0, processedData.Length, token);
            }
        }

        /// <summary>
        /// Processes multiple files concurrently.
        /// </summary>
        /// <param name="sourceFiles">The source file paths.</param>
        /// <param name="destinationFiles">The destination file paths.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task ProcessMultipleFileAsync(string[] sourceFiles, string[] destinationFiles, CancellationToken token = default)
        {
            if (sourceFiles.Length != destinationFiles.Length)
            {
                throw new ArgumentException("Source and destination file counts must be the same.");
            }

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < sourceFiles.Length; i++)
            {
                tasks.Add(this.WriteTheProcessedDataAsync(sourceFiles[i], destinationFiles[i], token));
            }

            await Task.WhenAll(tasks);
        }
    }
}
