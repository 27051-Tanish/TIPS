using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OopsAssignment.ShapeHierarchy.Controller;
using OopsAssignment.ShapeHierarchy.View;

namespace OopsAssignment
{
    /// <summary>
    /// Entry point of the program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args">string args</param>
        public static void Main(string[] args)
        {
            ShapeView view = new ShapeView();
            ShapeController controller = new ShapeController(view);
            controller.RunShape();
        }
    }
}
