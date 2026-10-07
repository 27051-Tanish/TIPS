using System.Text;
using System.Text.RegularExpressions;
using ReflectionsProject.Enums;
using ReflectionsProject.View;

namespace ReflectionsProject.Controller
{
    /// <summary>
    /// Handles the data flow and communication between view and each tasks.
    /// </summary>
    public class TaskController
    {
        private readonly ConsoleView _consoleView;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="consoleView">The instance of the view class handling user interface input and output.</param>
        /// <param name="notifier">The notification system used to broadcast event messages.</param>
        public TaskController(ConsoleView consoleView)
        {
            this._consoleView = consoleView;
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
                StringBuilder menuBuilder = new StringBuilder();
                foreach (MainMenu menuOption in Enum.GetValues<MainMenu>())
                {
                    int optionNumber = (int)menuOption;
                    string readableName = Regex.Replace(menuOption.ToString(), "([a-z])([A-Z])", "$1 $2");
                    menuBuilder.AppendLine($"{optionNumber}. {readableName}");
                }

                this._consoleView.ShowMessage(menuBuilder.ToString().TrimEnd());
                choice = this._consoleView.GetIntInput("Enter your choice: ", "Please select from the menu [1 to 8]");
                menu = (MainMenu)choice;

                switch (menu)
                {
                    case MainMenu.InspectAssemblyMetadata:
                        break;
                    case MainMenu.DynamicObjectInspector:
                        break;
                    case MainMenu.DynamicMethodInvoker:
                        break;
                    case MainMenu.DynamicTypeBuilder:
                        break;
                    case MainMenu.PluginSystem:
                        break;
                    case MainMenu.MockingFramework:
                        break;
                    case MainMenu.SerializationAPI:
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
    }
}
