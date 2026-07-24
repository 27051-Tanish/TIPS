using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsAssignment
{
    /// <summary>
    /// Enum for main menu used in switch case.
    /// </summary>
    public enum MainMenu
    {
        /// <summary>
        /// Number representing the function call of shape hierarchy.
        /// </summary>
        ShapeTask = 1,

        /// <summary>
        /// Number representing the function call of employee hierarchy.
        /// </summary>
        EmployeeTask,

        /// <summary>
        /// Number representing the function call of banking system.
        /// </summary>
        BankTask,

        /// <summary>
        /// Number representing exit operation.
        /// </summary>
        Exit,
    }
}
