using System.Text;
using System.Text.RegularExpressions;
using ReflectionsProject.Enums;
using ReflectionsProject.ReflectionTask;
using ReflectionsProject.SampleClasses;
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
                        this.PerformObjectInspector();
                        break;
                    case MainMenu.DynamicMethodInvoker:
                        this.PerformMethodInvoker();
                        break;
                    case MainMenu.DynamicTypeBuilder:
                        this.PerformTypeBuilder();
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

        private void PerformObjectInspector()
        {
            Student student = new Student()
            {
                Name = "Jonathan",
                Marks = 98,
                Department = "CSE",
            };
            ConsoleView.ShowTitle("TASK 2");
            DynamicObjectInspector dynObjectInspector = new DynamicObjectInspector();
            dynObjectInspector.InspectObject(student);
            ConsoleView.ConsoleClear();
        }

        private void PerformMethodInvoker()
        {
            Student student = new Student();
            ConsoleView.ShowTitle("TASK 3");
            DynamicMethodInvoker methodInvoker = new DynamicMethodInvoker();
            ConsoleView.ShowMessage("Enter the method name: ");
            string? methodName = ConsoleView.ReadInput();
            if (methodName != null)
            {
                methodInvoker.ExecuteMethodInvoker(student, methodName);
            }
            else
            {
                ConsoleView.ShowMessage("Method not found");
            }

            ConsoleView.ConsoleClear();
        }

        private void PerformTypeBuilder()
        {
            ConsoleView.ShowTitle("TASK 4");

            DynamicTypeBuilder dynamicTypeBuilder = new DynamicTypeBuilder();
            dynamicTypeBuilder.ExecuteDynamicTypeBuilder();
            ConsoleView.ConsoleClear();
        }
    }
}
