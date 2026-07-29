using System;
using Assignment1.Models;

namespace Assignment1.Persistence
{
    /// <summary>
    /// In-memory repository stores the list of contacts.
    /// </summary>
    internal class Repository
    {
        private List<ContactInfo> _contacts = new List<ContactInfo>();

        /// <summary>
        /// Add new contact to the list.
        /// </summary>
        /// <param name="contact">Add new contact to the contact log</param>
        public void AddNewContact(ContactInfo contact)
        {
            this._contacts.Add(contact);
        }

        /// <summary>
        /// Remove contact from the list.
        /// </summary>
        /// <param name="contact">remove given contact from the contact log</param>
        public void RemoveContact(ContactInfo contact)
        {
            this._contacts.Remove(contact);
        }

        /// <summary>
        /// Copies the in-memory repository to a duplicate list.
        /// </summary>
        /// <returns>list of contacts from contact log</returns>
        public IEnumerable<ContactInfo> GetContacts()
        {
            List<ContactInfo> duplicate = new List<ContactInfo>();
            for (int i = 0; i < this._contacts.Count; i++)
            {
                ContactInfo copyInfo = new ()
                {
                    Name = this._contacts[i].Name,
                    Email = this._contacts[i].Email,
                    ID = this._contacts[i].ID,
                    PhoneNumber = this._contacts[i].PhoneNumber,
                    Note = this._contacts[i].Note,
                };
                duplicate.Add(copyInfo);
            }

            return duplicate;
        }

        /// <summary>
        /// Get contact information by the guid.
        /// </summary>
        /// <param name="id">Get the contact information from the id</param>
        /// <returns>Contact information with the mentioned id</returns>
        public ContactInfo GetById(Guid? id)
        {
            return this._contacts.Find(c => c.ID == id);
        }

        /// <summary>
        /// Checks whether a contact already exists based on Name, Phone Number, or Email Address.
        /// </summary>
        /// <param name="contact">The contact information to validate.</param>
        /// <returns>True if a contact with the same Name, Phone Number,Email already exists, otherwise false.</returns>
        public bool IsDuplicate(ContactInfo contact)
        {
            return this._contacts.Any(c =>
                c.Name.Equals(contact.Name, StringComparison.OrdinalIgnoreCase) ||
                c.PhoneNumber == contact.PhoneNumber ||
                c.Email.Equals(contact.Email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
