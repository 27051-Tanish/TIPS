using System.Reflection;
using ReflectionsProject.Plugins;
using ReflectionsProject.View;

namespace ReflectionsProject.ReflectionTask
{
    /// <summary>
    /// Provides method for implementing the plugin system in simple application.
    /// </summary>
    public class PluginSystem
    {
        /// <summary>
        /// Execute operations that load plugins (assemblies) at runtime, and call methods on these plugins using Reflection.
        /// </summary>
        public void ExecutePluginTask()
        {
            string pluginDirectory = Path.Combine(AppContext.BaseDirectory, "Plugins");

            if (!Directory.Exists(pluginDirectory))
            {
                ConsoleView.ShowMessage("Directory not found");
                return;
            }

            string[] dllFiles = Directory.GetFiles(pluginDirectory, "*.dll");
            List<Type> plugins = new List<Type>();

            foreach (string dllFile in dllFiles)
            {
                string absolutePath = Path.GetFullPath(dllFile);
                Assembly assembly = Assembly.LoadFile(absolutePath);
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                    {
                        plugins.Add(type);
                    }
                }
            }

            if (plugins.Count == 0)
            {
                ConsoleView.ShowMessage("No plugin found.");
                return;
            }

            ConsoleView.ShowMessage("Available plugins");
            for (int i = 0; i < plugins.Count; i++)
            {
                ConsoleView.ShowMessage($"{i + 1}. {plugins[i].Name}");
            }

            int selectedPlugin = ConsoleView.GetIntInput("Select a plugin you want to execute: ", "Please select serial number from the list of plugins");
            Type pluginToExecute = plugins[selectedPlugin - 1];
            IPlugin pluginObject = (IPlugin)Activator.CreateInstance(pluginToExecute) !;
            MethodInfo? method = pluginToExecute.GetMethod("DisplayMessage");
            if (method != null)
            {
                method.Invoke(pluginObject, null);
            }
        }
    }
}
