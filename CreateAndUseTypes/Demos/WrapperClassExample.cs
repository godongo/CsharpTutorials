using System;
using System.IO;

namespace CreateAndUseTypes.Demos
{
    /// <summary>
    /// Wrapper class is a class which provides some additional features for a standard class. 
    /// </summary>
    class WrapperClassExample
    {
        // THIS IS JUST ANOTHER NESTED CLASS.
        public FileStream Stream { get; private set; }

        public WrapperClassExample()
        {
            this.Stream = File.Open("temp.dat", FileMode.Create);
        }

        // Add additional implementation to extend the FileStream class
        // The usual e.g class members properties and methods etc..

        class InnerClass //Inner Class
        {
            public Int32 ProcessData(int val)
            {
                return val + 1;
            }
        }
        
        internal static void CallRapper()
        {
            // Internally call to Wrapper class.
            WrapperClassExample.InnerClass wpe = new WrapperClassExample.InnerClass();

            //return wpe.ProcessData(100);
            Console.WriteLine($"Inner class returned value {wpe.ProcessData(100)}");
        }
    }
}
