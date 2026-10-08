using System.Reflection;
using ReflectionsProject.View;

namespace ReflectionsProject.ReflectionTask
{
    /// <summary>
    /// Provides methods that will create a dynamic object inspector.
    /// This tool should take an object as input and display its properties and their current values.
    /// It should also allow the user to change these values at runtime.
    /// </summary>
    public class DynamicObjectInspector
    {
        /// <summary>
        /// Retrieves the properties the object and allows the user to change the values in the runtime.
        /// </summary>
        /// <param name="obj">The object to be modified.</param>
        public void InspectObject(object obj)
        {
            Type type = obj.GetType();
            ConsoleView.ShowMessage($"Object type: {type.Name}\n");
            ConsoleView.ShowMessage("Properties\n");
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                object? value = property.GetValue(obj);
                ConsoleView.ShowMessage($"{property.Name}: {value}");
            }

            ConsoleView.ShowMessage("Enter the property name which you want to change: ");
            string? propertyToChange = ConsoleView.ReadInput();

            PropertyInfo? selectedProperty = type.GetProperty(propertyToChange);

            if (selectedProperty == null)
            {
                ConsoleView.ShowMessage("Property not found.");
                return;
            }

            if (!selectedProperty.CanWrite)
            {
                ConsoleView.ShowMessage("Property cannot be modified.");
                return;
            }

            ConsoleView.ShowMessage("Enter new value to the property: ");
            string? newValue = ConsoleView.ReadInput();

            try
            {
                object? convertedValue = Convert.ChangeType(newValue, selectedProperty.PropertyType);
                selectedProperty.SetValue(obj, convertedValue);

                ConsoleView.ShowMessage("Property updated successfully.");
                foreach (PropertyInfo property in properties)
                {
                    object? value = property.GetValue(obj);
                    ConsoleView.ShowMessage($"{property.Name}: {value}");
                }
            }
            catch (Exception ex)
            {
                ConsoleView.ShowMessage(ex.Message);
            }
        }
    }
}
