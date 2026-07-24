using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsAssignment.EmployeeHierarchy.EmployeeModel
{
    /// <summary>
    /// Enum for switch case in employee menu.
    /// </summary>
    public enum EmployeeMenu
    {
        /// <summary>
        /// Number representing display manager details.
        /// </summary>
        Manager = 1,

        /// <summary>
        /// Number representing display developer details.
        /// </summary>
        Developer,

        /// <summary>
        /// Number representing exit operation.
        /// </summary>
        Exit,
    }
}
