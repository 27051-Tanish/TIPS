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
        /// <returns>string</returns>
        public string? ShowMenu()
        {
            Console.WriteLine("Welcome to Console-based contact manager\n");

            Console.WriteLine("===========================================");
            Console.WriteLine("[1]. To Add New Contact: Press 'A' or 'a'");
            Console.WriteLine("[2]. To View Contact: Press 'V' or 'v'");
            Console.WriteLine("[3]. To Edit Contact: Press 'ED' or 'ed'");
            Console.WriteLine("[4]. To Delete Contact: Press 'D' or 'd'");
            Console.WriteLine("[5]. To Search Contact: Press 'S' or 's'");
            Console.WriteLine("[6]. To Exit: Press 'E' or 'e'");
            Console.WriteLine("===========================================");

            string? userChoice = Console.ReadLine();

            if (userChoice == null)
            {
                return null;
            }

            return userChoice;
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
            Console.WriteLine("Enter name of the contact :");
            contact.Name = Console.ReadLine();

            Console.WriteLine("Enter Phone Number :");
            contact.PhoneNumber = Console.ReadLine();
            bool isValidPhone = false;
            while (!isValidPhone)
            {
                if (!Helper.IsValidNumber(contact.PhoneNumber))
                {
                    Console.WriteLine("Invalid Phone Number");
                    Console.WriteLine("Enter Phone Number again:");
                    contact.PhoneNumber = Console.ReadLine();
                }
                else
                {
                    isValidPhone = true;
                }
            }

            Console.WriteLine("Enter email address :");
            contact.Email = Console.ReadLine();
            bool isValidEmail = false;
            while (!isValidEmail)
            {
                if (!Helper.IsValidEmail(contact.Email))
                {
                    Console.WriteLine("Invalid email");
                    Console.WriteLine("Enter email again");
                    contact.Email = Console.ReadLine();
                }
                else
                {
                    isValidEmail = true;
                }
            }

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
        /// shows all the contact information
        /// </summary>
        /// <param name="contacts">contacts</param>
        public void DisplayAll(List<ContactInfo> contacts)
        {
            foreach (var contact in contacts)
            {
                this.DisplayContact(contact);
            }
        }

        /// <summary>
        /// It shows all the message
        /// </summary>
        /// <param name="message">message</param>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// reads user input from console
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
