using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Assignments
{
    /// <summary>
    /// First Assignment
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args">Console-Based Contact Manager</param>
        public static void Main(string[] args)
        {
            List<List<string>> contacts = new List<List<string>>();

            Console.WriteLine("Console-Based Contact Manager");
            Console.WriteLine();
            bool stopLoop = false;
            while (!stopLoop)
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
                        AddContactInfo();
                        break;

                    case "V":
                    case "v":
                        ViewContactInfo();
                        break;

                    case "ED":
                    case "ed":
                        EditContactInfo();
                        break;

                    case "D":
                    case "d":
                        RemoveContactInfo();
                        break;

                    case "S":
                    case "s":
                        SearchContactInfo();
                        break;

                    case "E":
                    case "e":
                        stopLoop = true;
                        break;
                }
            }
            void AddContactInfo()
            {
                List<string> contact = new List<string>(); 
                Console.WriteLine("Add New Contact:");
                Console.WriteLine();
                Console.WriteLine("Enter name of the contact :");
                contact.Add(Console.ReadLine());

                Console.WriteLine("Enter Phone Number :");
                contact.Add(Console.ReadLine());

                Console.WriteLine("Enter email address :");
                contact.Add(Console.ReadLine());

                Console.WriteLine("Name :" + contact[0]);
                Console.WriteLine("Phone Number :" + contact[1]);
                Console.WriteLine("Email :" + contact[2]);
                Console.WriteLine();
                contacts.Add(contact);
                Console.WriteLine("Contact added successfully");
            }
            void ViewContactInfo()
            {
                if (contacts.Count == 0)
                {
                    Console.WriteLine("There is no contact present in the Contact Manager");
                }
                else
                {
                    contacts.Sort((a, b) => a[0].CompareTo(b[0]));
                    for (int i = 0; i < contacts.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.Name: {contacts[i][0]}");
                        Console.WriteLine($"{i + 1}.Phone: {contacts[i][1]}");
                        Console.WriteLine($"{i + 1}.Email: {contacts[i][2]}");
                        Console.WriteLine("--------------------------------");
                    }
                }
            }
            void EditContactInfo()
            {
                bool isEditable = false;
                while (!isEditable)
                {
                    if (contacts.Count <= 0)
                    {
                        Console.WriteLine("There is no contact in the manager");
                        continue;
                    }
                    Console.WriteLine("Enter the name of the contact to edit: ");
                    var userInput = Console.ReadLine();
                    foreach(List<string> c in contacts)
                    {
                        if (userInput.ToLower() == c[0].ToLower())
                        {
                            Console.WriteLine("Which contact info you need to edit: ");
                            Console.WriteLine();
                            Console.WriteLine("Name, Phone, Email");
                            var userOption = Console.ReadLine();
                            if (userOption == "Name")
                            {
                                Console.WriteLine("Enter new Name: ");
                                var newName = Console.ReadLine();
                                c[0] = newName;
                            }
                            else if (userOption == "Phone")
                            {
                                Console.WriteLine("Enter new number: ");
                                var newNumber = Console.ReadLine();
                                c[1] = newNumber;
                            }
                            else if(userOption == "Email")
                            {
                                Console.WriteLine("Enter new email: ");
                                var newEmail = Console.ReadLine();
                                c[2] = newEmail;
                            }
                            isEditable = true;
                            return;
                        }
                    } 
                }
                Console.WriteLine("There is no such contact");
            }
            void RemoveContactInfo()
            {
                if (contacts.Count <= 0)
                {
                    Console.WriteLine("No Contacts have been added yet");
                    return;
                }
                bool isIndexValid = false;

                while (!isIndexValid)
                {
                    Console.WriteLine("Enter the name of the contact to delete: ");
                    ViewContactInfo();
                    var removeName = Console.ReadLine();
                    if (removeName == "")
                    {
                        Console.WriteLine("Name field should not be empty");
                        continue;
                    }
                    for (int i = 0; i < contacts.Count(); i++)
                    {
                        if (removeName.ToLower() == contacts[i][0].ToLower())
                        {
                            contacts.RemoveAt(i);
                            Console.WriteLine("Contact deleted successfully");
                            isIndexValid = true;
                            ViewContactInfo();
                            return;
                        }
                    }
                    Console.WriteLine("There is no such contact");
                }
            }
            void SearchContactInfo()
            {
                bool isNameValid = false;
                while (!isNameValid)
                {
                    Console.WriteLine("Enter name to search: ");
                    var searchName = Console.ReadLine();
                    if (searchName.Length == 0)
                    {
                        Console.WriteLine("Not a valid input");
                        continue;
                    }

                    foreach (List<string> c in contacts)
                    {
                        if (searchName.ToLower() == c[0].ToLower())
                        {
                            isNameValid = true;
                            Console.WriteLine("Contact Found :" + c[0]);
                        }
                        else
                        {
                            Console.WriteLine("There is no such contact");
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}