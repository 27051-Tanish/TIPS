using System.Diagnostics;
using System.Threading.Tasks;
using FileStreamProject.Constants;
using FileStreamProject.Constants.Utility;
using FileStreamProject.Enums;
using FileStreamProject.FileStreamTasks;
using FileStreamProject.View;

namespace FileStreamProject.Controller
{
    /// <summary>
    /// Coordinates the application workflow by managing user input from the view and
    /// directing the execution of file streaming tasks.
    /// </summary>
    public class TaskController
    {
        private readonly ConsoleView _consoleView;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="consoleView">The instance used to handle user interactions and display messages.</param>
        public TaskController(ConsoleView consoleView)
        {
            this._consoleView = consoleView;
        }

        /// <summary>
        /// Starts the main program loop, continuously displaying the menu and executing tasks based on user selection until the user exits.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task RunTasks()
        {
            int choice;
            MainMenu menu;

            do
            {
                this._consoleView.ShowTitle("MAIN MENU");
                this._consoleView.ShowMessage("[1]. Task1\n[2]. Task2\n[3]. Task3\n[4]. Task4\n[5]. Exit\n");
                choice = this._consoleView.GetIntInput("Enter your choice: ");

                if (!Enum.IsDefined(typeof(MainMenu), choice))
                {
                    this._consoleView.ShowMessage("Invalid entry! Please select from the menu [1 to 5].\n");
                    menu = (MainMenu)(-1);
                    continue;
                }

                menu = (MainMenu)choice;

                switch (menu)
                {
                    case MainMenu.Task1:
                        this.PerformTask1();
                        break;
                    case MainMenu.Task2:
                        await this.PerformTask2();
                        break;
                    case MainMenu.Task3:
                        string data = BasicFileUsage.FileUsage();
                        this._consoleView.ShowMessage($"Data in the file: {data}\n");
                        this._consoleView.ConsoleClear();
                        break;
                    case MainMenu.Task4:
                        this.PerformTask4();
                        break;
                    case MainMenu.Exit:
                        break;
                    default:
                        this._consoleView.ShowMessage("Please select from the menu [1 to 5].");
                        break;
                }
            }
            while (menu != MainMenu.Exit);
        }

        private void PerformTask1()
        {
            this._consoleView.ShowTitle("TASK 1");

            if (!File.Exists(FilePaths.DataFilePath))
            {
                this._consoleView.ShowMessage("Creating 1GB file, please wait...\n");
                FileGenerator.CreateLargeTextFile(FilePaths.DataFilePath);
                this._consoleView.ShowMessage("1GB File created successfully...\n");
            }
            else
            {
                this._consoleView.ShowMessage("Existing 1GB file detected. Skipping generation...\n");
            }

            Directory.CreateDirectory("Destination");
            FileProcessor fileProcessor = new FileProcessor();

            Stopwatch watch = Stopwatch.StartNew();
            fileProcessor.ReadFromStreamer(FilePaths.DataFilePath);
            watch.Stop();
            this._consoleView.ShowMessage($"\nTime taken to read from the using FileStream is {watch.ElapsedMilliseconds} ms");

            watch.Restart();
            fileProcessor.ReadFromBuffer(FilePaths.DataFilePath);
            watch.Stop();
            this._consoleView.ShowMessage($"\nTime taken to read from the using BufferedStream is {watch.ElapsedMilliseconds} ms");

            watch.Restart();
            fileProcessor.WriteTheProcessedData(FilePaths.DataFilePath, FilePaths.ProcessDataPath);
            watch.Stop();
            this._consoleView.ShowMessage("\nData processed to upper-case successfully.\n" +
                $"Time taken to process the data: {watch.ElapsedMilliseconds} ms");

            this._consoleView.ConsoleClear();
        }

        private async Task PerformTask2()
        {
            // Create a CancellationTokenSource that automatically triggers after 2 minutes.
            using CancellationTokenSource cancelToken = new CancellationTokenSource(TimeSpan.FromMinutes(2));
            CancellationToken token = cancelToken.Token;
            try
            {
                this._consoleView.ShowTitle("TASK 2");
                Directory.CreateDirectory("Destination");

                FileProcessorAsync fileProcessorAsync = new FileProcessorAsync();

                Stopwatch watch = Stopwatch.StartNew();
                long totalStreamBytes = await fileProcessorAsync.ReadFromStreamerAsync(FilePaths.DataFilePath, token);
                watch.Stop();
                this._consoleView.ShowMessage($"\nTime taken to Read {totalStreamBytes:N0} bytes asynchronously using FileStream is {watch.ElapsedMilliseconds} ms");

                watch.Restart();
                long totalBytesFromBuffer = await fileProcessorAsync.ReadFromBufferAsync(FilePaths.DataFilePath, token);
                watch.Stop();
                this._consoleView.ShowMessage($"\nTime taken to Read {totalBytesFromBuffer:N0} asynchronously using BufferedStream is {watch.ElapsedMilliseconds} ms");

                watch.Restart();
                await fileProcessorAsync.WriteTheProcessedDataAsync(FilePaths.DataFilePath, FilePaths.ProcessDataPath, token);
                watch.Stop();
                this._consoleView.ShowMessage($"\nData processed to upper-case successfully.\nTime taken to process the data: {watch.ElapsedMilliseconds} ms");

                // Specify a target size for each concurrent file (e.g., 50 MB)
                long fiftyMbInBytes = 50L * 1024 * 1024;

                // Ensure the source paths are generated before testing non-blocking concurrency
                FileGenerator.EnsureMultipleSourceFilesExist(FilePaths.SourceFiles, fiftyMbInBytes);
                this._consoleView.ShowMessage("50MB testing source files verified/created at runtime.");
                await fileProcessorAsync.ProcessMultipleFileAsync(FilePaths.SourceFiles, FilePaths.DestinationFiles, token);
                this._consoleView.ShowMessage("\nMultiple files processed concurrently.\n");

                this._consoleView.ConsoleClear();
            }
            catch (OperationCanceledException)
            {
                this._consoleView.ShowMessage("\nThe 1 GB file operation was successfully canceled midway by the user/system timeout.");
            }
            catch (ArgumentException ex)
            {
                this._consoleView.ShowMessage(ex.Message);
            }
        }

        private void PerformTask4()
        {
            this._consoleView.ShowTitle("TASK 4");
            LoggingSystem loggingSystem = new LoggingSystem();

            loggingSystem.ImproveFileWriting("Error occurred from improved logging.\n");
            this._consoleView.ShowMessage("Message written to the file successfully.");

            Stopwatch watch = Stopwatch.StartNew();
            loggingSystem.ThreadSafeLogging(5, 30);
            watch.Stop();
            this._consoleView.ShowMessage($"Time taken to log error in single in thread safe manner: {watch.ElapsedMilliseconds} ms");

            watch.Restart();
            loggingSystem.IndependentLogFiles(1000, 30);
            watch.Stop();
            this._consoleView.ShowMessage($"[Naive Implementation] Time taken to log errors of multiple users in independent files: {watch.ElapsedMilliseconds} ms");

            watch.Restart();
            loggingSystem.IndependentLogFiles(1000, 30);
            watch.Stop();
            this._consoleView.ShowMessage($"[Optimized Implementation] Time taken to log errors of multiple users in independent files: {watch.ElapsedMilliseconds} ms");

            this._consoleView.ConsoleClear();
        }
    }
}
