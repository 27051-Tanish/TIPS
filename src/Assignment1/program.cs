using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Assignment1.Services;

namespace Assignment1
{
    /// <summary>
    /// First Assignment
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args">Console-Based Contact Manager</param>
        public static void Main(string[] args)
        {
            ConsoleActivity activity = new ConsoleActivity();
            activity.Run();
        }
    }
}