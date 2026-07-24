using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Persistence;

namespace Assignment1.Services
{
    /// <summary>
    /// Set user values via console
    /// </summary>
    public class ConsoleActivity
    {
        /// <summary>
        /// Shows menu to the user for selecting a operation
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
        /// Add new contact information
        /// </summary>
        /// <returns>list</returns>
        public ContactInfo AddContactInfo()
        {
            ContactInfo contact = new ContactInfo();

            Console.WriteLine("Add New Contact:");
            Console.WriteLine();
            do
            {
                Console.WriteLine("Enter name of the contact :");
                contact.Name = Console.ReadLine();
                if (!InputValidater.IsValidName(contact.Name))
                {
                    Console.WriteLine("Invalid Name");
                }
            }
            while (!InputValidater.IsValidName(contact.Name));

            do
            {
                Console.WriteLine("Enter Phone Number :");
                contact.PhoneNumber = Console.ReadLine();
                if (!InputValidater.IsValidNumber(contact.PhoneNumber))
                {
                    Console.WriteLine("Invalid Phone Number");
                }
            }
            while (!InputValidater.IsValidNumber(contact.PhoneNumber));

            do
            {
                Console.WriteLine("Enter email address :");
                contact.Email = Console.ReadLine();
                if (!InputValidater.IsValidEmail(contact.Email))
                {
                    Console.WriteLine("Invalid email");
                }
            }
            while (!InputValidater.IsValidEmail(contact.Email));

            Console.WriteLine("Enter a short note: ");
            contact.Note = Console.ReadLine();

            return contact;
        }

        /// <summary>
        /// Shows a contact information in the contact manager
        /// </summary>
        /// <param name="contact">contact</param>
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
        /// <param name="contacts">contacts</param>
        public void DisplayAll(List<ContactInfo> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Contact log is empty");
            }
            else
            {
                foreach (var contact in contacts)
                {
                    this.DisplayContact(contact);
                }
            }
        }

        /// <summary>
        /// Shows all the console messages
        /// </summary>
        /// <param name="message">message</param>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Reads user input from console.
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>string</returns>
        public string? ReadInput()
        {
           string? input = Console.ReadLine();
           if (input == null)
           {
                return null;
           }

           return input;
        }
    }
}
