// Must come first in the file
#define MySymbol

using System;

namespace DebugAndSecurity.Demos
{
    class DebugApplication
    {


        /* The output of this method depends on the build configuration you use. If you have set your 
         * build configuration to Debug, it outputs “Debug mode”; otherwise, it shows “Not debug”. */
        internal static void DebugDirective()
        {
            #if DEBUG
                        Console.WriteLine($"Debug mode");
            #else
                        Console.WriteLine($"Not debug");
            #endif
        }

        internal static void UseCustomSymbol()
        {
            #if MySymbol
                Console.WriteLine($"Custom symbol is defined");
            #endif
        }
    }
}
