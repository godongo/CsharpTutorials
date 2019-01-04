using System;
using System.Diagnostics;

namespace Debugging
{
    class Program
    {
        static string someVar = string.Empty;

        static void Main(string[] args)
        {           
            ReadDebugNotes();
            DebuggerDotBreak();

   
            Console.ReadKey();
        }

        private static void ReadDebugNotes()
        {
            /*
             * Demo#1
             * Project properties launch options.
             * Start with stepping (into/over)
             * Return values
             * Set next statement
             * Step into specific method (Specific method while skipping others)
             * Run to cursor 
             * Edit and continue
             * Step out
             * Run to cursor from Call Stack
             * Debug a method from immediate window
             */

            /*
             * Demo#2
             * Debugger.IsAttached
             * Debugger.Break() (Good for execution path not called frequently)
             * Visualizers 
             * Peek definition (Alt+F12)
             * DebuggerDisplay attribute 
             * DataTips (Pin data tip - in loops)
             * - Transparency
             * - Pinning
             * Make ObjectID
             */


        }

        // Use for execution path not frequently called.
        private static void DebuggerDotBreak()
        {
            if(Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }         
    }
}


