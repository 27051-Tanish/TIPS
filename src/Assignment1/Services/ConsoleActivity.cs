using Assignment1.Models;
using Assignment1.Persistence;

namespace Assignment1.Services
{
    /// <summary>
    /// Set user values via console.
    /// </summary>
    public class ConsoleActivity
    {
        /// <summary>
        /// Shows menu to the user for selecting a operation.
        /// </summary>
        public void ShowMenu()
        {
            this.ShowMessage("===========================================");
            this.ShowMessage("[1]. To Add New Contact");
            this.ShowMessage("[2]. To View Contact");
            this.ShowMessage("[3]. To Edit Contact");
            this.ShowMessage("[4]. To Delete Contact");
            this.ShowMessage("[5]. To Search Contact");
            this.ShowMessage("[6]. To Exit");
            this.ShowMessage("===========================================");
        }

        /// <summary>
        /// Shows a contact information in the contact manager
        /// </summary>
        /// <param name="contact">object with values of its properties</param>
        public void DisplayContact(ContactInfo contact)
        {
            this.ShowMessage("---------------------------------------");
            this.ShowMessage($"Name : {contact.Name}");
            this.ShowMessage($"Phone Number : {contact.PhoneNumber}");
            this.ShowMessage($"Email : {contact.Email}");
            this.ShowMessage($"Note : {contact.Note}");
            this.ShowMessage("---------------------------------------");
        }

        /// <summary>
        /// Shows all the contact information.
        /// </summary>
        /// <param name="contacts">list of objects of the contactInfo class</param>
        public void DisplayAll(List<ContactInfo>? contacts)
        {
            if (contacts == null || contacts.Count == 0)
            {
                this.ShowMessage("No results found.");
                return;
            }

            int serialNumber = 1;

            foreach (var contact in contacts)
            {
                this.ShowMessage($"Serial Number : {serialNumber++}");
                this.DisplayContact(contact);
            }
        }

        /// <summary>
        /// Shows all the console messages.
        /// </summary>
        /// <param name="message">message that should be displayed</param>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Reads user input from console.
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>the value read from the console</returns>
        public string? ReadInput()
        {
           return Console.ReadLine();
        }
    }
}
