using System.Reflection;
using ReflectionsProject.View;

namespace ReflectionsProject.ReflectionTask
{
    /// <summary>
    /// Provides methods that inspects the metadata of an assembly
    /// </summary>
    public class InspectAssembly
    {
        private string _assemblyPath = @"C:\Users\Tanish.raffi\source\repos\TIPS\src\ReflectionAssignment\SampleProject\bin\Debug\net8.0\SampleProject.dll";

        /// <summary>
        /// Executes different methods for loading the assembly and getting the methods, events and properties and events.
        /// </summary>
        public void ExecuteInspectAssemblyTask()
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(this._assemblyPath);
                ConsoleView.ShowMessage($"Successfully loaded the assembly: {assembly.FullName}");
                ConsoleView.ShowMessage(new string('=', 80));

                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    ConsoleView.ShowMessage($"Type name: {type.FullName}");
                    ConsoleView.ShowMessage(new string('=', 40));

                    FieldInfo[] fields = type.GetFields();
                    ConsoleView.ShowMessage("Fields\n");
                    foreach (FieldInfo field in fields)
                    {
                        ConsoleView.ShowMessage($"{field.FieldType.Name}: {field.Name}");
                    }

                    PropertyInfo[] properties = type.GetProperties();
                    ConsoleView.ShowMessage("Properties\n");
                    foreach (PropertyInfo property in properties)
                    {
                        ConsoleView.ShowMessage($"{property.PropertyType.Name}: {property.Name}");
                    }

                    MethodInfo[] methods = type.GetMethods();
                    ConsoleView.ShowMessage("Methods\n");
                    foreach (MethodInfo method in methods)
                    {
                        ConsoleView.ShowMessage($"{method.ReturnType.Name}: {method.Name}");
                    }

                    EventInfo[] events = type.GetEvents();
                    ConsoleView.ShowMessage($"Events\n");
                    foreach (EventInfo eventInfo in events)
                    {
                        ConsoleView.ShowMessage($"{eventInfo.Name}");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                ConsoleView.ShowMessage($"Error: The file at '{this._assemblyPath}' could not be found.");
            }
            catch (Exception ex)
            {
                ConsoleView.ShowMessage($"An error occurred: {ex.Message}");
            }
        }
    }
}
