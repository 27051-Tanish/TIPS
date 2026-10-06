using MathApp;
using UtilityApp;

namespace GreetingsApp
{
    /// <summary>
    /// Provides the main execution logic of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Provides the main entry point of the application.
        /// </summary>
        public static void Main()
        {
            UtilityApp.Program.ShowMessage("Hello, Tanish!");
            UtilityApp.Program.ShowMessage("Executing MathApp...");
            MathApp.Program.Main();
        }
    }
}
