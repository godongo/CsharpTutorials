using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAndUseTypes.Demos
{
    class TheObjectBaseClass
    {
        internal static void Execute()
        {
            object val = new StringBuilder();

            Console.WriteLine($"Reference still is an instance of the more-derived type: {val.GetType()}");
        }

        internal static void HowToUseObjectAsFunctionParameter()
        {
            // Use string type as object.
            string value = "Dot Net Perls";
            Test(value);
            Test((object)value);

            // Use integer type as object.
            int number = 100;
            Test(number);
            Test((object)number);

            // Use null object.
            Test(null);
        }

        static void Test(object value)
        {
            // Test the object.
            // ... Write its value to the screen if it is a string or integer.
            Console.WriteLine(value != null);

            if (value is string)
            {
                Console.WriteLine("String value: {0}", value);
            }
            else if (value is int)
            {
                Console.WriteLine("Int value: {0}", value);
            }
        }

        /*
         * This method compares the contents of objects. It first checks 
         * whether the references are equal. Object.Equals calls into derived Equals 
         * methods to test equality further.
         */
        // Remember -  object.ReferenceEquals the derived equality method is not used.
        internal static void ObjectDotEquals()
        {
            // Equals compares the contents (and references) of 2 objects.
            bool b = object.Equals("a", 'a'.ToString()); // Gee: Will also call String.Equals method to.
            Console.WriteLine(b);

            // ReferenceEquals compares the references of 2 objects.
            // This only compares the memory location of 2 objects but not the content.
            b = object.ReferenceEquals("a", 'a'.ToString());  
            Console.WriteLine(b);
        }
        
        // Dotnet Perls : 
        // Object class - stopped at (Equals, internals.)
    }
}
