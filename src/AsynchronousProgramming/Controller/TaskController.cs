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
        private readonly MultiLayeredTasks _multiLayeredTasks = new MultiLayeredTasks();
        private readonly ConfigurationAwaitSample _configurationAwait = new ConfigurationAwaitSample();

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="view">The instance of the view.</param>
        public TaskController(ConsoleView view)
        {
            this._view = view;
            this._multiLayeredTasks.Notify += this.DisplayNotification;
            this._configurationAwait.ThreadNotifier += this.DisplayNotification;
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
                        await this.PerformMultiLayeredTask();
                        break;
                    case MainMenu.DebuggingDeadlockTask:
                        await this.PerformDeadlockSample();
                        break;
                    case MainMenu.ThreadTrackingTask:
                        await this.PerformConfigureAwaitTask();
                        break;
                    case MainMenu.ExceptionsInTask:
                        await this.PerformExceptionsInTask();
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

            this._view.ConsoleClear();
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

            this._view.ConsoleClear();
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

            this._view.ConsoleClear();
        }

        private async Task PerformMultiLayeredTask()
        {
            try
            {
                int keyCount = await this._multiLayeredTasks.PerformMethodC();
                this._view.ShowMessage($"\nFinal Result: The JSON response contains {keyCount} keys.");
            }
            catch (Exception ex)
            {
                this._view.ShowMessage($"An error occurred: {ex.Message}");
            }

            this._view.ConsoleClear();
        }

        private async Task PerformDeadlockSample()
        {
            DeadLockSample deadLock = new DeadLockSample();
            string result = await deadLock.DeadlockMethod();
            this._view.ShowMessage($"Waited for 1 second and prints the result: {result}");

            this._view.ConsoleClear();
        }

        private async Task PerformConfigureAwaitTask()
        {
            this._view.ShowMessage($"Starts with the [Thread id]: {Thread.CurrentThread.ManagedThreadId}");
            string result = await this._configurationAwait.PerformMethodB();
            this._view.ShowMessage($"The result from the method B is {result}");
            this._view.ShowMessage($"Finishes the execution with the [Thread id]: {Thread.CurrentThread.ManagedThreadId}");

            this._view.ConsoleClear();
        }

        private async Task PerformExceptionsInTask()
        {
            this._view.ShowMessage("Starting the exception handling.");
            ExceptionsInTaskTesting testing = new ExceptionsInTaskTesting();
            try
            {
                this._view.ShowMessage("Calling task method.");
                await testing.TaskMethod();
            }
            catch (Exception ex)
            {
                this._view.ShowMessage($"Exception caught: {ex.Message}");
            }

            try
            {
                this._view.ShowMessage("Calling void method.");
                testing.VoidMethod();
                await Task.Delay(500);
            }
            catch (Exception ex) // This catch block will never execute.
            {
                this._view.ShowMessage($"{ex.Message}");
            }

            this._view.ConsoleClear();
        }

        private void DisplayNotification(string obj)
        {
            this._view.ShowMessage(obj);
        }
    }
}
