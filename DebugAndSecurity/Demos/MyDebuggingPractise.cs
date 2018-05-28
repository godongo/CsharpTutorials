using System;
using System.Collections.Generic;

namespace DebugAndSecurity.Demos
{
    class MyDebuggingPractise
    {
        private static string whereMI = "";
                
        internal static void MyCode_Example1()
        {
            Function1();
            Function2();            
        }



        private static void Function1()
        {
            whereMI = "I am in function1";
        }

        private static void Function2()
        {
            whereMI = "I am in function2";
        }

        // This based on a different tutorial on youtube
        internal static void MyCode_Example2()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            //var numbers = new List<int> { 1, 2 };
            var smallest = GetSmallest(numbers, 3);

            foreach (var number in smallest)
            {
                Console.WriteLine($"{number}");
            }
        }

        public static List<int> GetSmallest(List<int> list, int count)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            if (count > list.Count || count <= 0 )
                throw new ArgumentOutOfRangeException("count", 
                    "Count should be between 1 and the number of elements in the list.");

            // Copy original list int the buffer.
            var buffer = new List<int>(list);
            var smallest = new List<int>();

            while (smallest.Count < count)
            {

                //var min = GetSmallest(list);
                var min = GetSmallest(buffer);
                smallest.Add(min);

                //list.Remove(min);
                buffer.Remove(min);
            }
            return smallest;
        }

        public static int GetSmallest(List<int> list)
        {
            // Assume the first number is the smallest.
            var min = list[0];

            for (var i = 0; i < list.Count; i++)
            {
                if(list[i] < min) // First bug. list[i] > min
                {
                    min = list[i];
                }
            }

            return min;
        }
    }
}
