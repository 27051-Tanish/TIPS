using System.Diagnostics;
using System.Threading.Tasks;
using FileStreamProject.Constants;
using FileStreamProject.Enum;
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
                this._consoleView.ShowMessage("MAIN MENU");
                this._consoleView.ShowMessage("[1]. Task1\n[2]. Task2\n[3]. Task3\n[4]. Task4\n[5]. Exit\n");
                choice = this._consoleView.GetIntInput("Enter your choice: ");
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
                        string data = Task3.FileUsage();
                        this._consoleView.ShowMessage($"Data in the file: {data}");
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
            this._consoleView.ShowMessage("TASK 1");
            Directory.CreateDirectory("Destination");
            Task1 task = new Task1();
            task.CreateLargeTextFile(FilePaths.OneGbFile, FilePaths.DataFilePath);
            this._consoleView.ShowMessage("1GB File created successfully...");

            Stopwatch watch = Stopwatch.StartNew();
            task.ReadFromStreamer(FilePaths.DataFilePath);
            watch.Stop();
            this._consoleView.ShowMessage($"\nTime taken to read from the using FileStream is {watch.ElapsedMilliseconds}");

            watch.Restart();
            task.ReadFromBuffer(FilePaths.DataFilePath);
            watch.Stop();
            this._consoleView.ShowMessage($"\nTime taken to read from the using BufferedStream is {watch.ElapsedMilliseconds}");

            task.WriteTheProcessedData(FilePaths.DataFilePath, FilePaths.ProcessDataPath);
            this._consoleView.ShowMessage("Data processed to upper-case successfully");
        }

        private async Task PerformTask2()
        {
            try
            {
                this._consoleView.ShowMessage("TASK 2");
                Directory.CreateDirectory("Destination");
                Task2 task = new Task2();
                await task.CreateLargeTextFileAsync(FilePaths.OneGbFile, FilePaths.DataFilePath);
                this._consoleView.ShowMessage("1GB File created successfully...");

                Stopwatch watch = Stopwatch.StartNew();
                await task.ReadFromStreamerAsync(FilePaths.DataFilePath);
                watch.Stop();
                this._consoleView.ShowMessage($"\nTime taken to read from the file using FileStream is {watch.ElapsedMilliseconds}");

                watch.Restart();
                await task.ReadFromBufferAsync(FilePaths.DataFilePath);
                watch.Stop();
                this._consoleView.ShowMessage($"\nTime taken to read from the file using BufferedStream is {watch.ElapsedMilliseconds}");

                await task.WriteTheProcessedDataAsync(FilePaths.DataFilePath, FilePaths.ProcessDataPath);
                this._consoleView.ShowMessage("Data processed to upper-case successfully");

                await task.ProcessMultipleFileAsync(FilePaths.SourceFiles, FilePaths.DestinationFiles);
                this._consoleView.ShowMessage("\"Multiple files processed concurrently.");
            }
            catch (ArgumentException ex)
            {
                this._consoleView?.ShowMessage(ex.Message);
            }
        }

        private void PerformTask4()
        {
            this._consoleView.ShowMessage("TASK 4");
            Task4 task = new Task4();
            task.Run();

            // The files are modified after performing the tasks.
            this._consoleView.ShowMessage("Task 4 completed");
        }
    }
}
