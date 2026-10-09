using ReflectionsProject.Plugins;

namespace Plugin3
{
    public class MessagePlugin : IPlugin
    {
        /// <inheritdoc/>
        public void DisplayMessage()
        {
            Console.WriteLine("Message from the 'Message Plugin'...");
        }
    }
}
