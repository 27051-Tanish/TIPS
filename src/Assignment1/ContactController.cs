using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Services;

namespace Assignment1
{
    /// <summary>
    /// Contact controller acts as bridge between view and service
    /// </summary>
    public class ContactController
    {
        /// <summary>
        /// private objects for the view and service layer
        /// </summary>
        private readonly ConsoleActivity _view;
        private readonly ContactManager _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactController"/> class.
        /// Constructor to pass objects of manager and console
        /// </summary>
        /// <param name="view">view</param>
        /// <param name="manager">manager</param>
        public ContactController(ConsoleActivity view, ContactManager manager)
        {
            this._view = view;
            this._manager = manager;
        }

        /// <summary>
        /// Starts the execution of the program
        /// </summary>
        public void Run()
        {
            this._view.ShowMessage("Welcome to Console-based contact manager\n");
            do
            {
                int? choice = this._view.GetChoice();

                switch (choice)
                {
                    case 1:
                        ContactInfo newContact = this._view.AddContactInfo();
                        this._manager.AddContactInfo(newContact);
                        this._view.ShowMessage("Contact Added successfully");
                        break;

                    case 2:
                        this._view.DisplayAll(this._manager.ViewContactInfo());
                        break;

                    case 3:
                        EditContact();
                        break;

                    case 4:
                        DeleteContact();
                        break;

                    case 5:
                        SearchContact();
                        break;

                    case 6:
                        break;

                    default:
                        this._view.ShowMessage("Invalid choice");
                        break;
                }
            }
            while (this._view.GetChoice() != 6);

            void EditContact()
            {
                List<ContactInfo> contacts = this._manager.ViewContactInfo();
                this._view.ShowMessage("Enter serial number of the contact to edit: ");
                bool serialNumber = int.TryParse(this._view.ReadInput(), out int result);
                if (result <= 0)
                {
                    this._view.ShowMessage("Invalid serial number");
                }
                else
                {
                    ContactInfo newContact = new ContactInfo();
                    bool isEdit = false;
                    while (!isEdit)
                    {
                        this._view.ShowMessage("Which details you need to change: ");
                        this._view.ShowMessage("\n");
                        this._view.ShowMessage("[1]Name\n[2]Phone\n[3]Email\n[4]Note");
                        bool userChoice = int.TryParse(this._view.ReadInput(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                this._view.ShowMessage("Enter new Name: ");
                                newContact.Name = this._view.ReadInput();
                                isEdit = true;
                                break;
                            case 2:
                                this._view.ShowMessage("Enter new phone: ");
                                newContact.PhoneNumber = this._view.ReadInput();
                                isEdit = true;
                                break;
                            case 3:
                                this._view.ShowMessage("Enter new email: ");
                                newContact.Email = this._view.ReadInput();
                                isEdit = true;
                                break;
                            case 4:
                                this._view.ShowMessage("Enter new note: ");
                                newContact.Note = this._view.ReadInput();
                                isEdit = true;
                                break;
                        }
                    }

                    Guid? selectedId = (Guid?)contacts[result - 1].ID;
                    this._manager.EditContactInfo(selectedId, newContact);
                    this._view.ShowMessage("Updated successfully");
                }
            }

            void DeleteContact()
            {
                List<ContactInfo> contacts = this._manager.ViewContactInfo();
                if (contacts.Count == 0)
                {
                    this._view.ShowMessage("No contact available");
                }

                this._manager.ViewContactInfo();
                ContactInfo contact = new ContactInfo();
                this._view.ShowMessage("Enter delete ID of the cotact: ");
                bool deleteId = int.TryParse(this._view.ReadInput(), out int deleteNumber);
                Guid? selectedId = (Guid?)contacts[deleteNumber - 1].ID;
                this._manager.RemoveContactInfo(selectedId);
            }

            void SearchContact()
            {
                this._view.ShowMessage("---Search Here---");
                string? keyword = this._view.ReadInput();
                List<ContactInfo> contactInfos = this._manager.SearchContactInfo(keyword);
                this._view.DisplayAll(contactInfos);
            }
        }
    }
}
