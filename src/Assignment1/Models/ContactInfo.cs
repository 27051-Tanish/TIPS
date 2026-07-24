using System;

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
        /// <value>
        /// Id of the contact.
        /// </value>
        public Guid? ID { get; set; }

        /// <summary>
        /// Gets or sets  Name
        /// </summary>
        /// <value>
        /// Name of the contact.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets email
        /// </summary>
        /// <value>
        /// Email of the contact.
        /// </value>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets phone
        /// </summary>
        /// <value>
        /// Phone number of the contact.
        /// </value>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets notes
        /// </summary>
        /// <value>
        /// Notes of the contact.
        /// </value>
        public string? Note { get; set; }
    }
}
