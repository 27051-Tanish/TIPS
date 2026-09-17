using AdvancedCSharpConcepts.AdvancedTasks;
using AdvancedCSharpConcepts.Enum;
using AdvancedCSharpConcepts.View;

namespace AdvancedCSharpConcepts.Controller
{
    /// <summary>
    /// Handles the data flow and communication between view and each tasks.
    /// </summary>
    public class TaskController
    {
        private readonly ConsoleView _consoleView;
        private readonly Notifier _notifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="consoleView">The instance of the view class handling user interface input and output.</param>
        /// <param name="notifier">The notification system used to broadcast event messages.</param>
        public TaskController(ConsoleView consoleView, Notifier notifier)
        {
            this._consoleView = consoleView;
            this._notifier = notifier;
        }

        /// <summary>
        /// Provides the execution of each tasks from the user input.
        /// </summary>
        public void RunApplication()
        {
            int choice;
            MainMenu menu;

            do
            {
                this._consoleView.ShowTitle("MAIN MENU");
                this._consoleView.ShowMessage("[1]. Events and Delegate\n[2]. Dynamic and Var\n[3]. Anonymous methods\n[4]. Lambda expression\n" +
                    "[5]. Advance delegate\n[6]. Record task\n[7]. Pattern matching\n[8]. Exit");
                choice = this._consoleView.GetIntInput("Enter your choice: ");
                menu = (MainMenu)choice;

                switch (menu)
                {
                    case MainMenu.EventsAndDelegate:
                        this.PerformEventsTask();
                        break;
                    case MainMenu.DynamicAndVar:
                        break;
                    case MainMenu.AnonymousMethods:
                        break;
                    case MainMenu.LambdaExpression:
                        break;
                    case MainMenu.AdvanceDelegate:
                        break;
                    case MainMenu.RecordTask:
                        break;
                    case MainMenu.PatternMatching:
                        break;
                    case MainMenu.Exit:
                        break;
                    default:
                        this._consoleView.ShowMessage("Please select from the menu [1 to 8].");
                        break;
                }
            }
            while (menu != MainMenu.Exit);
        }

        private void PerformEventsTask()
        {
            Notifier notify = new Notifier();
            notify.OnAction += this.EventNotification;

            notify.CallEvent("This event is triggered...");
            this._consoleView.ConsoleClear();
        }

        private void EventNotification(string message)
        {
            this._consoleView.ShowMessage(message);
        }
    }
}
