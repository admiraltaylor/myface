using System;
using System.Collections.Generic;
using System.Text;

namespace MyFace.Common
{
    /// <summary>
    /// A simple class that logs stuff to an external file. 
    /// </summary>
    public static class Logger
    {
        public static void Write(string message)
        {
            // write message to external file
        }

        public static void Write(Exception ex)
        {
            // Log exception in external file.
        }
    }
}
