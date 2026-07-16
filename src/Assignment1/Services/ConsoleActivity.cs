using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Persistence;

namespace Assignment1.Services
{
    /// <summary>
    /// Set user values via console
    /// </summary>
    internal class ConsoleActivity
    {
        private ContactManager _manager = new ContactManager();

        /// <summary>
        /// runs the menu
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Console-Based Contact Manager");
            Console.WriteLine();
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("[1]. To Add New Contact: Press 'A' or 'a'");
                Console.WriteLine("[2]. To View Contact: Press 'V' or 'v'");
                Console.WriteLine("[3]. To Edit Contact: Press 'ED' or 'ed'");
                Console.WriteLine("[4]. To Delete Contact: Press 'D' or 'd'");
                Console.WriteLine("[5]. To Search Contact: Press 'S' or 's'");
                Console.WriteLine("[6]. To Exit: Press 'E' or 'e'");
                Console.WriteLine("===========================================");

                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "A":
                    case "a":
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

                        Console.WriteLine("Enter a short note: ");
                        contact.Note = Console.ReadLine();

                        this._manager.AddContactInfo(contact);
                        break;

                    case "V":
                    case "v":
                        DisplayAll(this._manager.ViewContactInfo());
                        break;

                    case "ED":
                    case "ed":
                        EditContact();
                        break;

                    case "D":
                    case "d":
                        DeleteContact();
                        break;

                    case "S":
                    case "s":
                        SearchContact();
                        break;

                    case "E":
                    case "e":
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }

            void DisplayContact(ContactInfo contact)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Name : {contact.Name}");
                Console.WriteLine($"Phone Number : {contact.PhoneNumber}");
                Console.WriteLine($"Email : {contact.Email}");
                Console.WriteLine($"Note : {contact.Note}");
                Console.WriteLine("---------------------------------------");
            }

            void DisplayAll(List<ContactInfo> contacts)
            {
                if (contacts.Count == 0)
                {
                    Console.WriteLine("No contact available");
                }

                foreach (var contact in contacts)
                {
                    DisplayContact(contact);
                }
            }

            void EditContact()
            {
                List<ContactInfo> contacts = this._manager.ViewContactInfo();
                if (contacts.Count == 0)
                {
                    Console.WriteLine("No contact available");
                }

                ContactInfo contact = new ContactInfo();
                Console.WriteLine("Enter serial number of the contact to edit: ");
                bool serialNumber = int.TryParse(Console.ReadLine(), out int result);
                if (result <= 0)
                {
                    Console.WriteLine("Invalid serial number");
                }
                else
                {
                    ContactInfo newContact = new ContactInfo();
                    bool isEdit = false;
                    while (!isEdit)
                    {
                        Console.WriteLine("Which details you need to change: ");
                        Console.WriteLine();
                        Console.WriteLine("[1]Name\n[2]Phone\n[3]Email\n[4]Note");
                        bool userChoice = int.TryParse(Console.ReadLine(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Enter new Name: ");
                                newContact.Name = Console.ReadLine();
                                isEdit = true;
                                break;
                            case 2:
                                Console.WriteLine("Enter new phone: ");
                                newContact.PhoneNumber = Console.ReadLine();
                                isEdit = true;
                                break;
                            case 3:
                                Console.WriteLine("Enter new email: ");
                                newContact.Email = Console.ReadLine();
                                isEdit = true;
                                break;
                            case 4:
                                Console.WriteLine("Enter new note: ");
                                newContact.Note = Console.ReadLine();
                                isEdit = true;
                                break;
                        }
                    }

                    Guid? selectedId = (Guid?)contacts[result - 1].ID;
                    this._manager.EditContactInfo(selectedId, newContact);
                }
            }

            void DeleteContact()
            {
                List<ContactInfo> contacts = this._manager.ViewContactInfo();
                if (contacts.Count == 0)
                {
                    Console.WriteLine("No contact available");
                }

                this._manager.ViewContactInfo();
                ContactInfo contact = new ContactInfo();
                Console.WriteLine("Enter delete ID of the cotact: ");
                bool deleteId = int.TryParse(Console.ReadLine(), out int deleteNumber);
                Guid? selectedId = (Guid?)contacts[deleteNumber - 1].ID;
                this._manager.RemoveContactInfo(selectedId);
            }

            void SearchContact()
            {
                Console.WriteLine("---Search Here---");
                string? keyword = Console.ReadLine();

                DisplayAll(this._manager.SearchContactInfo(keyword));
            }
        }
    }
}
