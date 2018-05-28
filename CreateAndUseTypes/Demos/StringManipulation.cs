using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CreateAndUseTypes.Demos
{
    class StringManipulation
    {

    #region Search for strings
        // string: Use when referring to an object eg. string place = "world"; 
        // String: Use when referring to the class eg. string greet = String.Format("Hello {0}!", place);
        // == : Use to compare value.
        // REMEMBER STRING IMMUTABILITY - Any string re-assignment creates a new string
        internal static void StringBuilder()
        {
            //string s = string.Empty;
            //for (int i = 0; i < 10000; i++)
            //{
            //    // EACH ITERATION WILL CREATE A NEW STRING.
            //    s += "x";  
            //}

            // Use a StringBuilder for efficiency.
            StringBuilder sb = new StringBuilder("A initial value");
            // Change first character
            sb[0] = 'B';

            Console.WriteLine($"Result:{sb}");

            // Rewrite previous code with string builder for efficiency.
            StringBuilder sb1 = new StringBuilder(string.Empty);

            for (int i = 0; i < 10000; i++)
            {
                sb1.Append("x");
            }
        }
        
        internal static void IndexOfAndLastIndexOf()
        {
            string value = "My Sample Value";
            int indexOfp = value.IndexOf('p'); // returns 6
            int lastIndexOfm = value.LastIndexOf('m'); // returns 5

            Console.WriteLine($"IndexOf: {indexOfp}");
            Console.WriteLine($"lastIndexOfm: {lastIndexOfm}");
        }

        internal static void StartsWithAndEndsWith()
        {
            string value = "<mycustominput>";

            if (value.StartsWith("<"))
            {
                Console.WriteLine($"True starts with <");
            }

            if (value.EndsWith(">"))
            {
                Console.WriteLine($"True ends with >");
            }
        }

        // If necessary, you can calculate indexes passed to substring 
        // by using IndexOf or LastIndexOf
        internal static void Substring()
        {
            string value = "My Sample Value";

            string subString = value.Substring(3, 6); // Returns ‘Sample’

            Console.WriteLine($"The substring: {subString}");
        }

        // Regular expressions can be useful when validating user input.
        // PLEASE REFER TO: Objective 3.1: Validate application input.
        // Under Regular Expressions.
        internal static void RegularExpression()
        {
            string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";

            string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels", "Abraham Adams", "Ms. Nicole Norris" };

            foreach (string name in names)
            {
                // Removes titles by replacing them with an empty string.
                Console.WriteLine(Regex.Replace(name, pattern, String.Empty));
            }
        }
        #endregion

        #region Enumerate strings
        internal static void LoopThrough()
        {
            string value = "My Custom Value";

            foreach (char c in value)
            {
                Console.WriteLine(c);
            }               
        }

        internal static void Split()
        {
            string value = "My sentence separated by spaces";

            foreach (var word in value.Split(' '))
            {
                Console.WriteLine(word);
            }

        }
        #endregion

        #region Formatting strings

        internal static void Execute()
        {
            //string value = "My Custom Value";           
        }
        #endregion
    }
}
