using InventoryManagement.Model;

namespace InventoryManagement.View
{
    /// <summary>
    /// Defines a contract for providing console based UI methods.
    /// </summary>
    public interface IInventoryConsole
    {
        /// <summary>
        /// Displays the main menu.
        /// </summary>
        void ShowMenu();

        /// <summary>
        /// Displays the product information from the records.
        /// </summary>
        /// <param name="items">The inventory details log.</param>
        void DisplayAll(List<InventoryInfo>? items);

        /// <summary>
        /// Display a particular product details from the inventory log.
        /// </summary>
        /// <param name="item">The product details that needs to be displayed.</param>
        void DisplayItem(InventoryInfo item);

        /// <summary>
        /// Writes the message to the UI.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        void ShowMessage(string message);

        /// <summary>
        /// Reads an user input from the UI.
        /// </summary>
        /// <returns>The input entered by the user, or null, if no input is available.</returns>
        string? ReadInput();

        /// <summary>
        /// Draws a visual separator line to improve the UI.
        /// </summary>
        void EndLine();
    }
}
