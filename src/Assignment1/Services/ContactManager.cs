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
    /// CRUD operations
    /// </summary>
    internal class ContactManager
    {
        private Repository _repo = new ();

        /// <summary>
        /// add contact to manager
        /// </summary>
        /// <param name="contact">add feature</param>
        public void AddContactInfo(ContactInfo contact)
        {
            contact.ID = Guid.NewGuid();
            this._repo.Add(contact);
        }

        /// <summary>
        /// gets all values
        /// </summary>
        /// <returns>list</returns>
        public List<ContactInfo> ViewContactInfo()
        {
            List<ContactInfo> contact = this._repo.GetContacts();
            contact.Sort((a, b) => string.Compare(a.Name, b.Name));
            return contact;
        }

        /// <summary>
        /// remove contact
        /// </summary>
        /// <param name="id">remove</param>
        /// <returns>bool</returns>
        public string RemoveContactInfo(Guid? id)
        {
            ContactInfo? contact = this._repo.GetById(id);
            if (contact != null)
            {
                this._repo.Remove(contact);
            }

            return "Contact deleted successfully";
        }

        /// <summary>
        /// edit contact
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="newContact">newContact</param>
        /// <returns>bool</returns>
        public string EditContactInfo(Guid? id,  ContactInfo newContact)
        {
            ContactInfo? contact = this._repo.GetById(id);
            if (contact == null)
            {
                return "Invalid ID (or) Cannot edit";
            }

            if (newContact.Name != null)
            {
                contact.Name = newContact.Name;
                return "Name edited successfully";
            }

            if (contact.Email != null)
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

            return "Contact Updated";
        }

        /// <summary>
        /// Search value Contact From Manager
        /// </summary>
        /// <param name="searchValue">search</param>
        /// <returns>List of contacts</returns>
        public List<ContactInfo>? SearchContactInfo(string? searchValue)
        {
            if (searchValue != null)
            {
                return this._repo.GetContacts().Where(s => s.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                s.PhoneNumber.Contains(searchValue, StringComparison.OrdinalIgnoreCase) || s.Email.Contains(searchValue, StringComparison.OrdinalIgnoreCase) || s.Note.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return null;
        }
    }
}
