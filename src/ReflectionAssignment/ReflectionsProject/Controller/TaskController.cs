using System.Text;
using System.Text.RegularExpressions;
using ReflectionsProject.Enums;
using ReflectionsProject.ReflectionTask;
using ReflectionsProject.View;

namespace ReflectionsProject.Controller
{
    /// <summary>
    /// Handles the data flow and communication between view and each tasks.
    /// </summary>
    public class TaskController
    {
        /// <summary>
        /// Provides the execution of each tasks from the user input.
        /// </summary>
        public void RunApplication()
        {
            int choice;
            MainMenu menu;

            do
            {
                ConsoleView.ShowTitle("MAIN MENU");
                StringBuilder menuBuilder = new StringBuilder();
                foreach (MainMenu menuOption in Enum.GetValues<MainMenu>())
                {
                    int optionNumber = (int)menuOption;
                    string readableName = Regex.Replace(menuOption.ToString(), "([a-z])([A-Z])", "$1 $2");
                    menuBuilder.AppendLine($"{optionNumber}. {readableName}");
                }

                ConsoleView.ShowMessage(menuBuilder.ToString().TrimEnd());
                choice = ConsoleView.GetIntInput("Enter your choice: ", "Please select from the menu [1 to 8]");
                menu = (MainMenu)choice;

                switch (menu)
                {
                    case MainMenu.InspectAssemblyMetadata:
                        this.PerformInspectMetadata();
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
                        ConsoleView.ShowMessage("Please select from the menu [1 to 8].");
                        break;
                }
            }
            while (menu != MainMenu.Exit);
        }

        private void PerformInspectMetadata()
        {
            InspectAssembly inspectAssembly = new InspectAssembly();
            ConsoleView.ShowTitle("TASK 1");
            inspectAssembly.ExecuteInspectAssemblyTask();
            ConsoleView.ConsoleClear();
        }
    }
}
