using System;
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
            Console.WriteLine("===========================================");
            Console.WriteLine("[1]. To Add New Contact");
            Console.WriteLine("[2]. To View Contact");
            Console.WriteLine("[3]. To Edit Contact");
            Console.WriteLine("[4]. To Delete Contact");
            Console.WriteLine("[5]. To Search Contact");
            Console.WriteLine("[6]. To Exit");
            Console.WriteLine("===========================================");
        }

        /// <summary>
        /// Shows a contact information in the contact manager
        /// </summary>
        /// <param name="contact">object with values of its properties</param>
        public void DisplayContact(ContactInfo contact)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Name : {contact.Name}");
            Console.WriteLine($"Phone Number : {contact.PhoneNumber}");
            Console.WriteLine($"Email : {contact.Email}");
            Console.WriteLine($"Note : {contact.Note}");
            Console.WriteLine("---------------------------------------");
        }

        /// <summary>
        /// Shows all the contact information.
        /// </summary>
        /// <param name="contacts">list of objects of the contactInfo class</param>
        public void DisplayAll(List<ContactInfo>? contacts)
        {
            if (contacts == null || contacts.Count == 0)
            {
                Console.WriteLine("No results found.");
                return;
            }

            int serialNumber = 1;

            foreach (var contact in contacts)
            {
                Console.WriteLine($"Serial Number : {serialNumber++}");
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
