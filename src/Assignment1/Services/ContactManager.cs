using System;
using Assignment1.Models;
using Assignment1.Persistence;

namespace Assignment1.Services
{
    /// <summary>
    /// Performs basic CRUD operations.
    /// </summary>
    public class ContactManager
    {
        private Repository _repo = new ();

        /// <summary>
        /// Add new contact details to contact log.
        /// </summary>
        /// <param name="contact">add new contact information</param>
        public void AddContactInfo(ContactInfo contact)
        {
            contact.ID = Guid.NewGuid();
            this._repo.AddNewContact(contact);
        }

        /// <summary>
        /// Gets all contact details from the list.
        /// </summary>
        /// <returns>list of contact details</returns>
        public List<ContactInfo> GetAllContact()
        {
            List<ContactInfo> contact = (List<ContactInfo>)this._repo.GetContacts();
            contact.Sort((a, b) => string.Compare(a.Name, b.Name));
            return contact;
        }

        /// <summary>
        /// Remove contact by id from the list.
        /// </summary>
        /// <param name="id">remove existing contact by id</param>
        public void RemoveContactInfo(Guid? id)
        {
            ContactInfo contact = this._repo.GetById(id);
            this._repo.RemoveContact(contact);
        }

        /// <summary>
        /// Edit contact by id from the list.
        /// </summary>
        /// <param name="id">id and new contact information to edit</param>
        /// <param name="newContact">newContact</param>
        /// <returns>bool</returns>
        public string EditContactInfo(Guid? id,  ContactInfo newContact)
        {
            ContactInfo contact = this._repo.GetById(id);
            if (contact == null)
            {
                return "Invalid ID (or) Cannot edit";
            }

            if (newContact.Name != null)
            {
                contact.Name = newContact.Name;
                return "Name edited successfully";
            }

            if (newContact.Email != null)
            {
                contact.Email = newContact.Email;
                return "Email edited successfully";
            }

            if (newContact.PhoneNumber != null)
            {
                contact.PhoneNumber = newContact.PhoneNumber;
                return "PhoneNumber edited successfully";
            }

            if (newContact.Note != null)
            {
                contact.Note = newContact.Note;
                return "Note edited successfully";
            }

            return "No update in contact log";
        }

        /// <summary>
        /// Search by keyword for a contact from contact manager.
        /// </summary>
        /// <param name="searchValue">search a contact</param>
        /// <returns>List of contacts</returns>
        public List<ContactInfo>? SearchContactInfo(string? searchValue)
        {
            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                return this._repo.GetContacts().Where(s => s.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                s.PhoneNumber.Contains(searchValue, StringComparison.OrdinalIgnoreCase) || s.Email.Contains(searchValue, StringComparison.OrdinalIgnoreCase) || s.Note.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return null;
        }
    }
}
