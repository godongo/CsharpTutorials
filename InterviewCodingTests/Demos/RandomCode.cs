using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewCodingTests.Demos
{
    class RandomCode
    {
        internal static void AnArrayOfLists()
        {
            string[] test = { "one", "two", "three" };

            List<string> countries = new List<string> { "UK", "USA", "France" };
            List<string> cities = new List<string> { "London", "Washington", "Paris" };

            List<string>[] names = new List<string>[2];
            names[0] = countries;
            names[1] = cities;

            foreach (var i in names)
            {
                Console.WriteLine(i.ElementAt(0));
            }                

            Console.ReadKey();

        }
    }
}
