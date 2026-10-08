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
        /// Creates a dynamic type builder that can define a new class at runtime, with properties and methods defined by the user.
        /// </summary>
        /// <param name="obj">The object of an class.</param>
        /// <param name="methodName">The name indicating the method name of that class.</param>
        public void ExecuteMethodInvoker(object obj, string methodName)
        {
            Type type = obj.GetType();
            MethodInfo? method = type.GetMethod(methodName);

            if (method == null)
            {
                ConsoleView.ShowMessage("Method not found");
                return;
            }

            method.Invoke(obj, null);
        }
    }
}
