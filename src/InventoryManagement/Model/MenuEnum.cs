using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model
{
    /// <summary>
    /// Enum for representing values for switch case.
    /// </summary>
    public enum MenuEnum
    {
        /// <summary>
        /// Number representing add function in menu.
        /// </summary>
        Insert = 1,

        /// <summary>
        /// Number representing view function in menu.
        /// </summary>
        View,

        /// <summary>
        /// Number representing edit function in menu
        /// </summary>
        Edit,

        /// <summary>
        /// Number representing remove function in menu
        /// </summary>
        Remove,

        /// <summary>
        /// Number representing search function in menu
        /// </summary>
        Search,

        /// <summary>
        /// Number representing exit function in menu
        /// </summary>
        Exit,
    }
}
