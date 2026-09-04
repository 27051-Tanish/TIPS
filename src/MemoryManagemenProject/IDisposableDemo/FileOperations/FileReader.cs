namespace IDisposableDemo.FileOperations
{
    /// <summary>
    /// Reads the content from the file.
    /// </summary>
    public class FileReader : IDisposable
    {
        private readonly StreamReader _reader;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        public FileReader(string filePath)
        {
            this._reader = new StreamReader(filePath);
        }

        /// <summary>
        /// Read from the file.
        /// </summary>
        /// <returns>The content read from the file.</returns>
        public string ReadFromFile()
        {
            return this._reader.ReadToEnd();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this._reader.Dispose();
        }
    }
}
