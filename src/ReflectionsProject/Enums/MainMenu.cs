namespace ReflectionsProject.Enums
{
    /// <summary>
    /// Represents the main menu of the application.
    /// </summary>
    public enum MainMenu
    {
        /// <summary>
        /// Represents the task which inspects the assembly's metadata.
        /// </summary>
        InspectAssemblyMetadata = 1,

        /// <summary>
        /// Represent the task which creates a dynamic object inspector.
        /// </summary>
        DynamicObjectInspector,

        /// <summary>
        /// Represents the task which implements a method invoker.
        /// </summary>
        DynamicMethodInvoker,

        /// <summary>
        /// Represents the task which create a dynamic type builder that can define a new class at runtime.
        /// </summary>
        DynamicTypeBuilder,

        /// <summary>
        /// Represents the task which implements a plugin system for a simple application.
        /// </summary>
        PluginSystem,

        /// <summary>
        /// Represents the task which use Reflection to dynamically generate a mock object for unit testing.
        /// </summary>
        MockingFramework,

        /// <summary>
        /// Represents the task which implement a simple serialization API using Reflection and then identify its limitations and rewrite it using Reflection.Emit.
        /// </summary>
        SerializationAPI,

        /// <summary>
        /// Represents the exit operation from the main menu.
        /// </summary>
        Exit,
    }
}
