namespace OopsAssignment
{
    /// <summary>
    /// Provides console-based UI methods for displaying menus, messages,
    /// and reading user input for various application modules.
    /// </summary>
    public class ProjectConsoleView
    {
        /// <summary>
        /// Provides different applications as a menu for user.
        /// </summary>
        public void ApplicationMenu()
        {
            this.EndLine();
            this.ShowMessage("[1]. Shape Hierarchy\n[2]. Employee Hierarchy\n[3]. Banking System\n[4]. Exit");
            this.EndLine();
        }

        /// <summary>
        /// Provides different account types as menu for performing banking operations.
        /// </summary>
        public void BankSystemMenu()
        {
            this.EndLine();
            this.ShowMessage("[1]. Savings Account\n[2]. Checking Account\n[3]. Exit");
            this.EndLine();
        }

        /// <summary>
        /// Provides different shape type as menu for performing area calculation.
        /// </summary>
        public void ShapeHierarchyMenu()
        {
            this.EndLine();
            this.ShowMessage("[1].Rectangle\n[2].Circle\n[3].Exit");
            this.EndLine();
        }

        /// <summary>
        /// Provides different employee type as menu for performing bonus calculation.
        /// </summary>
        public void EmployeeHierarchyMenu()
        {
            this.EndLine();
            this.ShowMessage("[1]. Manager\n[2]. Developer\n[3]. Exit");
            this.EndLine();
        }

        /// <summary>
        /// Writes a message to the console output.
        /// </summary>
        /// <param name="message">string message</param>
        public void ShowMessage(string? message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Writes a visual separator line to the console for improved readability.
        /// </summary>
        public void EndLine()
        {
            Console.WriteLine("===========================");
        }

        /// <summary>
        /// Reads a line of input from the console.
        /// </summary>
        /// <returns>The input entered by the user, or null, if no input is available.</returns>
        public string? ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
