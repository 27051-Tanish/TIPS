using ReflectionsProject.Plugins;

namespace Plugin1
{
    public class WelcomePlugin : IPlugin
    {
        /// <inheritdoc/>
        public void DisplayMessage()
        {
            Console.WriteLine("This message is from 'Welcome Plugin'...");
        }
    }
}
