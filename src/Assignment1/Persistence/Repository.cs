using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Models;

namespace Assignment1.Persistence
{
    /// <summary>
    /// Repo for storing
    /// </summary>
    internal class Repository
    {
        private List<ContactInfo> _contacts = new List<ContactInfo>();

        /// <summary>
        /// Add new contact to the list
        /// </summary>
        /// <param name="contact">Add </param>
        public void Add(ContactInfo contact)
        {
            this._contacts.Add(contact);
        }

        /// <summary>
        /// Remove contact
        /// </summary>
        /// <param name="contact">remvove given contact</param>
        public void Remove(ContactInfo contact)
        {
            this._contacts.Remove(contact);
        }

        /// <summary>
        /// Gets all conatactInfo
        /// </summary>
        /// <returns>list</returns>
        public List<ContactInfo> GetContacts()
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
        /// get guid
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Id</returns>
        public ContactInfo GetById(Guid id)
        {
            return this._contacts.Find(c => c.ID == id);
        }
    }
}
