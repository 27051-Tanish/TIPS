using ReflectionsProject.Plugins;

namespace Plugin2
{
    public class TimePlugin : IPlugin
    {
        /// <inheritdoc/>
        public void DisplayMessage()
        {
            Console.WriteLine($"Current time: {DateTime.UtcNow}");
        }
    }
}
