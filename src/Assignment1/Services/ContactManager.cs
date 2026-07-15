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
        private Repository _repo = new Repository();

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
            return _repo.GetContacts();
        }

        /// <summary>
        /// remove contact
        /// </summary>
        /// <param name="id">remove</param>
        /// <returns>bool</returns>
        public string RemoveContactInfo(Guid id)
        {
            ContactInfo contact = this._repo.GetById(id);

            if (id == null)
            {
                return "No contact present (or) Invalid id";
            }

            this._repo.Remove(contact);
            return "Contact deleted successfully";
        }

        /// <summary>
        /// edit contact
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="newContact">newContact</param>
        /// <returns>bool</returns>
        public string EditContactInfo(Guid id,  ContactInfo newContact)
        {
            ContactInfo contact = _repo.GetById(id);
            if (contact == null)
            {
                return "Invalid ID (or) Cannot edit";
            }

            if (newContact.Name != null)
            {
                contact.Name = newContact.Name;
            }

            if (contact.Email != null)
            {
                contact.Email = newContact.Email;
            }

            if (newContact.PhoneNumber != null)
            {
                contact.PhoneNumber = newContact.PhoneNumber;
            }

            if (newContact.Note != null)
            {
                contact.Note = newContact.Note;
            }

            return "Contact edited successfully";
        }

        /// <summary>
        /// Search value Contact From Manager
        /// </summary>
        /// <param name="searchValue">search</param>
        /// <returns>List of contacts</returns>
        public List<ContactInfo> SearchContactInfo(string searchValue)
        {
            return this._repo.GetContacts().Where(s=>s.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase)||
                s.PhoneNumber.Contains(searchValue)||s.Email.Contains(searchValue, StringComparison.OrdinalIgnoreCase)||s.Note.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
