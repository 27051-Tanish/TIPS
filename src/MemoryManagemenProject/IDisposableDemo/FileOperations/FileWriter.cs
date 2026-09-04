namespace IDisposableDemo.FileOperations
{
    /// <summary>
    /// Writes the content from the file.
    /// </summary>
    public class FileWriter : IDisposable
    {
        private readonly StreamWriter _writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        public FileWriter(string filePath)
        {
            this._writer = new StreamWriter(filePath, true);
        }

        /// <summary>
        /// Writes to a file.
        /// </summary>
        /// <param name="content">The content to be written in the file.</param>
        public void WriteToFile(string content)
        {
            this._writer.WriteLine(content + Environment.NewLine);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this._writer.Dispose();
        }
    }
}
