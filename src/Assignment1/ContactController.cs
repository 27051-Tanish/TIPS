using Assignment1.Models;
using Assignment1.Services;

namespace Assignment1
{
    /// <summary>
    /// Contact controller acts as bridge between view and service.
    /// </summary>
    public class ContactController
    {
        /// <summary>
        /// Private objects for the view and service layer.
        /// </summary>
        private readonly ConsoleActivity _consoleView;
        private readonly ContactManager _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactController"/> class.
        /// Constructor to pass objects of manager and console.
        /// </summary>
        /// <param name="view">The console view instance used for user interaction.</param>
        /// <param name="manager">The manager instance responsible for business logic.</param>
        public ContactController(ConsoleActivity view, ContactManager manager)
        {
            this._consoleView = view;
            this._manager = manager;
        }

        /// <summary>
        /// Starts the execution of the program.
        /// </summary>
        public void Run()
        {
            this._consoleView.ShowMessage("Welcome to Console-based contact manager\n");
            int choiceValue;
            do
            {
                this._consoleView.ShowMenu();
                this._consoleView.ShowMessage("Enter your choice :");
                choiceValue = GetChoice();
                switch (choiceValue)
                {
                        case 1:
                            ContactInfo newContact = AddContact();
                            this._manager.AddContactInfo(newContact);
                            this._consoleView.ShowMessage("Contact Added successfully");
                            break;
                        case 2:
                            this._consoleView.DisplayAll(this._manager.GetAllContact());
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
                            this._consoleView.ShowMessage("Invalid choice, Enter your choice from menu.");
                            break;
                }
            }
            while (choiceValue != 6);
            /// <summary>
            /// Add new contact information.
            /// </summary>
            /// <returns>Contact information with values for all the properties.</returns>
            ContactInfo AddContact()
            {
                ContactInfo contact = new ContactInfo();

                this._consoleView.ShowMessage("Add New Contact:");
                Console.WriteLine();
                do
                {
                    this._consoleView.ShowMessage("Enter name of the contact:");
                    contact.Name = this._consoleView.ReadInput();

                    if (!InputValidater.IsValidName(contact.Name))
                    {
                        this._consoleView.ShowMessage("Invalid Name");
                    }
                    else if (this._manager.IsDuplicateContact(contact))
                    {
                        this._consoleView.ShowMessage("Contact name already exists");
                        contact.Name = string.Empty;
                    }
                }
                while (!InputValidater.IsValidName(contact.Name));

                do
                {
                    this._consoleView.ShowMessage("Enter Phone Number:");
                    contact.PhoneNumber = this._consoleView.ReadInput();

                    if (!InputValidater.IsValidNumber(contact.PhoneNumber))
                    {
                        this._consoleView.ShowMessage("Invalid Phone Number");
                    }
                    else if (this._manager.IsDuplicateContact(contact))
                    {
                        this._consoleView.ShowMessage("Phone Number already exists");
                        contact.PhoneNumber = string.Empty;
                    }
                }
                while (!InputValidater.IsValidNumber(contact.PhoneNumber));

                do
                {
                    this._consoleView.ShowMessage("Enter email address:");
                    contact.Email = this._consoleView.ReadInput();

                    if (!InputValidater.IsValidEmail(contact.Email))
                    {
                        this._consoleView.ShowMessage("Invalid Email");
                    }
                    else if (this._manager.IsDuplicateContact(contact))
                    {
                        this._consoleView.ShowMessage("Email already exists");
                        contact.Email = string.Empty;
                    }
                }
                while (!InputValidater.IsValidEmail(contact.Email));

                this._consoleView.ShowMessage("Enter a short note: ");
                contact.Note = this._consoleView.ReadInput();

                return contact;
            }

            /// <summary>
            /// Edit existing contact information.
            /// </summary>
            void EditContact()
            {
                List<ContactInfo> contacts = this._manager.GetAllContact();
                if (contacts.Count == 0)
                {
                    this._consoleView.ShowMessage("No contact available");
                    return;
                }

                this._consoleView.DisplayAll(contacts);
                this._consoleView.ShowMessage("Enter serial number of the contact to edit: ");
                int serialNumber = GetChoice();
                if (serialNumber <= 0 || serialNumber > contacts.Count)
                {
                    this._consoleView.ShowMessage("Invalid serial number.");
                    return;
                }
                else
                {
                    ContactInfo newContact = new ContactInfo();
                    bool isEdit = false;
                    while (!isEdit)
                    {
                        this._consoleView.ShowMessage("Which details you need to edit: ");
                        this._consoleView.ShowMessage("\n");
                        this._consoleView.ShowMessage("[1]Name\n[2]Phone\n[3]Email\n[4]Note");
                        int userChoice = GetChoice();
                        switch (userChoice)
                        {
                            case 1:
                                do
                                {
                                    this._consoleView.ShowMessage("Enter new name of the contact :");
                                    newContact.Name = this._consoleView.ReadInput();
                                    if (!InputValidater.IsValidName(newContact.Name))
                                    {
                                        this._consoleView.ShowMessage("Invalid Name");
                                    }
                                    else if (this._manager.IsDuplicateContact(newContact))
                                    {
                                        this._consoleView.ShowMessage("Contact name already exists");
                                        newContact.Name = string.Empty;
                                    }
                                }
                                while (!InputValidater.IsValidName(newContact.Name));
                                isEdit = true;
                                break;
                            case 2:
                                do
                                {
                                    this._consoleView.ShowMessage("Enter new phone number :");
                                    newContact.PhoneNumber = this._consoleView.ReadInput();
                                    if (!InputValidater.IsValidNumber(newContact.PhoneNumber))
                                    {
                                        this._consoleView.ShowMessage("Invalid Phone Number");
                                    }
                                    else if (this._manager.IsDuplicateContact(newContact))
                                    {
                                        this._consoleView.ShowMessage("Phone Number already exists");
                                        newContact.PhoneNumber = string.Empty;
                                    }
                                }
                                while (!InputValidater.IsValidNumber(newContact.PhoneNumber));
                                isEdit = true;
                                break;
                            case 3:
                                do
                                {
                                    this._consoleView.ShowMessage("Enter new email address :");
                                    newContact.Email = this._consoleView.ReadInput();
                                    if (!InputValidater.IsValidEmail(newContact.Email))
                                    {
                                        this._consoleView.ShowMessage("Invalid email");
                                    }
                                    else if (this._manager.IsDuplicateContact(newContact))
                                    {
                                        this._consoleView.ShowMessage("Email already exists");
                                        newContact.Email = string.Empty;
                                    }
                                }
                                while (!InputValidater.IsValidEmail(newContact.Email));
                                isEdit = true;
                                break;
                            case 4:
                                this._consoleView.ShowMessage("Enter new note: ");
                                newContact.Note = this._consoleView.ReadInput();
                                isEdit = true;
                                break;
                            default:
                                this._consoleView.ShowMessage("Invalid choice");
                                break;
                        }
                    }

                    Guid? selectedId = (Guid?)contacts[serialNumber - 1].ID;
                    this._manager.EditContactInfo(selectedId, newContact);
                    this._consoleView.ShowMessage("Updated successfully");
                }
            }

            /// <summary>
            /// Deletes existing contact information.
            /// </summary>
            void DeleteContact()
            {
                List<ContactInfo> contacts = this._manager.GetAllContact();
                if (contacts.Count == 0)
                {
                    this._consoleView.ShowMessage("No contact available");
                    return;
                }

                this._consoleView.DisplayAll(contacts);
                this._consoleView.ShowMessage("Enter serial number of the contact to delete: ");
                int deleteId = GetChoice();
                if (deleteId < 1 || deleteId > contacts.Count)
                {
                    this._consoleView.ShowMessage("Invalid selection. Please try again.");
                    return;
                }

                Guid? selectedId = (Guid?)contacts[deleteId - 1].ID;
                bool removed = this._manager.RemoveContactInfo(selectedId);

                if (removed)
                {
                    this._consoleView.ShowMessage("Contact deleted successfully.");
                }
                else
                {
                    this._consoleView.ShowMessage("Failed to delete contact. Please try again.");
                }
            }

            /// <summary>
            /// Search specific contact information from the contact log.
            /// </summary>
            void SearchContact()
            {
                List<ContactInfo> contacts = this._manager.GetAllContact();
                if (contacts == null || contacts.Count == 0)
                {
                    this._consoleView.ShowMessage("No contact available");
                    return;
                }

                this._consoleView.ShowMessage("---Search Here---");
                string? keyword = this._consoleView.ReadInput();

                if (InputValidater.IsValidSearchKey(keyword))
                {
                    List<ContactInfo>? contactInfos = this._manager.SearchContactInfo(keyword);
                    this._consoleView.DisplayAll(contactInfos);
                }
                else
                {
                    this._consoleView.ShowMessage("No results found.");
                }
            }

            int GetChoice()
            {
                while (true)
                {
                    if (int.TryParse(this._consoleView.ReadInput(), out int choiceValue))
                    {
                        return choiceValue;
                    }
                    else
                    {
                        this._consoleView.ShowMessage("Please enter valid choice");
                    }
                }
            }
        }
    }
}
