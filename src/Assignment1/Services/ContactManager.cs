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
        /// <param name="contact">Contact information that needs to be added.</param>
        public void AddContactInfo(ContactInfo contact)
        {
            contact.ID = Guid.NewGuid();
            this._repo.AddNewContact(contact);
        }

        /// <summary>
        /// Gets all contact details from the list.
        /// </summary>
        /// <returns>List of contact details</returns>
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
        /// <returns>True, if contact removed.</returns>
        public bool RemoveContactInfo(Guid? id)
        {
            ContactInfo contact = this._repo.GetById(id);
            this._repo.RemoveContact(contact);
            return true;
        }

        /// <summary>
        /// Edit contact by id from the list.
        /// </summary>
        /// <param name="id">Id of the old contact and new contact information to edit.</param>
        /// <param name="newContact">New contact information.</param>
        public void EditContactInfo(Guid? id,  ContactInfo newContact)
        {
            ContactInfo contact = this._repo.GetById(id);

            if (newContact.Name != null)
            {
                contact.Name = newContact.Name;
            }

            if (newContact.Email != null)
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
        }

        /// <summary>
        /// Checks whether a contact already exists based on Name, Phone Number, or Email Address.
        /// </summary>
        /// <param name="contact">The contact information to validate.</param>
        /// <returns>True if a contact with the same Name, Phone Number,Email already exists, otherwise false</returns>
        public bool IsDuplicateContact(ContactInfo contact)
        {
            return this._repo.IsDuplicate(contact);
        }

        /// <summary>
        /// Search by keyword for a contact from contact manager.
        /// </summary>
        /// <param name="searchValue">search a contact</param>
        /// <returns>List of contacts</returns>
        public List<ContactInfo> SearchContactInfo(string? searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                return new List<ContactInfo>();
            }

            return this._repo.GetContacts()
                .Where(s =>
                    (s.Name?.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (s.PhoneNumber?.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (s.Email?.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (s.Note?.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ?? false))
                .ToList();
        }
    }
}
