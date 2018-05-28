using System;
using System.Globalization;

namespace DebugAndSecurity.Demos
{
    class StringParsing
    {
        // Parse should be used if you are certain the parsing will succeed.
        internal static void Parse()
        {
            string value = "true";
            bool b = bool.Parse(value);
            Console.WriteLine(b); // displays True
        }

        // TryParse can be used when you are parsing some user input.
        internal static void TryParse()
        {
            //string value = "a";
            string value = "48";

            int result;
            bool success = int.TryParse(value, out result);

            if (success)
            {
                // value is a valid integer, result contains the value
            }
            else
            {
                // value is not a valid integer
            }
        }

        // When using the bool.Parse or bool.TryParse methods, you don’t have any extra parsing options.
        internal static void ParsingNumbersWithExtraOptions()
        {
            CultureInfo english = new CultureInfo("En");
            CultureInfo dutch = new CultureInfo("Nl");

            // Input from UI etc....
            string value = "€19,95";

            // Parse input
            decimal d = decimal.Parse(value, NumberStyles.Currency, dutch);

            Console.WriteLine(d.ToString(english));
        }

        // Convert returns the default value for the supplied type
        // Parse takes a string only as input and will throw exception
        internal static void ConvertAndParse_Difference()
        {
            DateTime d = Convert.ToDateTime(null);
            Console.WriteLine($"Default value: {d}"); // Displays default for DateTime

            int i = Convert.ToInt32(null);
            Console.WriteLine($"Default value: {i}"); // Displays default for Integer
        }
    }
}
