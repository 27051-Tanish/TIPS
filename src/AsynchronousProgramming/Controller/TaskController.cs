using System.Text;
using System.Text.RegularExpressions;
using AsynchronousProgramming.AsyncTasks;
using AsynchronousProgramming.Enums;
using AsynchronousProgramming.View;

namespace AsynchronousProgramming.Controller
{
    /// <summary>
    /// Acts as the orchestrator between the different tasks and view.
    /// </summary>
    public class TaskController
    {
        private readonly ConsoleView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="view">The instance of the view.</param>
        public TaskController(ConsoleView view)
        {
            this._view = view;
        }

        /// <summary>
        /// Main execution logic of the application.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task RunApplication()
        {
            int choice;
            MainMenu menu;

            do
            {
                StringBuilder menuBuilder = new StringBuilder();
                foreach (var menuOption in Enum.GetValues<MainMenu>())
                {
                    int optionNumber = (int)menuOption;
                    string readableMenu = Regex.Replace(menuOption.ToString(), "([a-z])([A-Z])", "$1 $2");
                    menuBuilder.AppendLine($"[{optionNumber}]. {readableMenu}");
                }

                this._view.ShowTitle("MAIN MENU");
                this._view.ShowMessage(menuBuilder.ToString().TrimEnd());
                choice = this._view.GetIntInput("\nPlease select your choice: ", "\nPlease select valid option from [1 to 8].");

                menu = (MainMenu)choice;
                switch (menu)
                {
                    case MainMenu.HttpClientTask:
                        await this.PerformHttpTask();
                        break;
                    case MainMenu.TaskParallelLibraryTask:
                        this.DisplaySquaredNumbers();
                        break;
                    case MainMenu.MultiThreadingTask:
                        this.PerformMultiThreading();
                        break;
                    case MainMenu.MultiLayeredAsyncTask:
                        break;
                    case MainMenu.DebuggingDeadlockTask:
                        break;
                    case MainMenu.ExceptionsInTask:
                        break;
                    case MainMenu.ThreadTrackingTask:
                        break;
                    case MainMenu.Exit:
                        break;
                }
            }
            while (menu != MainMenu.Exit);
        }

        private async Task PerformHttpTask()
        {
            HttpClientTask http = new HttpClientTask();
            string content = await http.DownloadContentAsync();
            this._view.ShowMessage(content);
        }

        private void DisplaySquaredNumbers()
        {
            TaskParallelLib taskParallelLib = new TaskParallelLib();
            int[] numbers = taskParallelLib.SquareTheNumbers();
            this._view.ShowTitle("Squared numbers");
            int serialNumber = 1;
            foreach (var number in numbers)
            {
                this._view.ShowMessage($"[{serialNumber}]. {number}");
                serialNumber++;
            }
        }

        private void PerformMultiThreading()
        {
            MultiThreading operations = new MultiThreading();
            Thread thread1 = new Thread(operations.SortAList);
            Thread thread2 = new Thread(operations.CalculateSquareOfList);
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            this._view.ShowMessage("=== Sorted list ===\n");
            this._view.ShowMessage($"{string.Join(", ", operations.SortedList)}");
            this._view.ShowMessage("\n=== Squared list ===\n");
            this._view.ShowMessage($"{string.Join(", ", operations.SquaredList)}");
        }
    }
}
