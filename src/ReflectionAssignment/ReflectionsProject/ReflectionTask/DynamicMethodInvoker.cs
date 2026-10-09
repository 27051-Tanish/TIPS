using System.Reflection;
using ReflectionsProject.View;

namespace ReflectionsProject.ReflectionTask
{
    /// <summary>
    /// Implement a method invoker that can call methods on an object dynamically, based on the method name provided as a string.
    /// </summary>
    public class DynamicMethodInvoker
    {
        /// <summary>
        /// Displays all public methods declared on the target object's class.
        /// </summary>
        /// <param name="obj">The object the class.</param>
        public void DisplayAvailableMethods(object obj)
        {
            if (obj == null)
            {
                return;
            }

            Type type = obj.GetType();

            // DeclaredOnly hides built-in methods like ToString() and Equals()
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            ConsoleView.ShowMessage($"--- Available Methods in {type.Name} ---");
            foreach (MethodInfo m in methods)
            {
                ConsoleView.ShowMessage($"{m.Name}");
            }

            ConsoleView.ShowMessage("---------------------------------------");
        }

        /// <summary>
        /// Creates a dynamic type builder that can define a new class at runtime, with properties and methods defined by the user.
        /// </summary>
        /// <param name="obj">The object of an class.</param>
        /// <param name="methodName">The name indicating the method name of that class.</param>
        public void ExecuteMethodInvoker(object obj, string methodName)
        {
            Type type = obj.GetType();
            MethodInfo? method = type.GetMethod(methodName);

            if (method is null)
            {
                ConsoleView.ShowMessage("Method not found");
                return;
            }

            method.Invoke(obj, null);
        }
    }
}
