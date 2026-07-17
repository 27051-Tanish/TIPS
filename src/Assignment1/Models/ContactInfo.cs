using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    /// <summary>
    /// Store contactInfo
    /// </summary>
    public class ContactInfo
    {
        /// <summary>
        /// Gets or sets GUID
        /// </summary>
        /// <param name = "GUID">GUID</param>
        /// <returns>returns guid</returns>
        /// <value>
        /// And sets GUID
        /// </value>
        public Guid? ID { get; set; }

        /// <summary>
        /// Gets or sets  Name
        /// </summary>
        /// <param name = "Name">GUID</param>
        /// <returns>returns name</returns>
        /// <value>
        /// gets and sets name
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets email
        /// </summary>
        /// <param name = "email">GUID</param>
        /// <returns>returns guid</returns>
        /// <value>
        /// sets email
        /// </value>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets phone
        /// </summary>
        /// <param name = "phone">GUID</param>
        /// <returns>returns phonenumber</returns>
        /// <value>
        /// sets phone
        /// </value>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets notes
        /// </summary>
        /// <param name = "notes">GUID</param>
        /// <returns>returns notes</returns>
        /// <value>
        /// notes
        /// </value>
        public string? Note { get; set; }
    }
}
