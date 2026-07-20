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
        /// <value>
        /// And sets GUID
        /// </value>
        public Guid? ID { get; set; }

        /// <summary>
        /// Gets or sets  Name
        /// </summary>
        /// <value>
        /// gets and sets name
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets email
        /// </summary>
        /// <value>
        /// sets email
        /// </value>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets phone
        /// </summary>
        /// <value>
        /// sets phone
        /// </value>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets notes
        /// </summary>
        /// <value>
        /// notes
        /// </value>
        public string? Note { get; set; }
    }
}
