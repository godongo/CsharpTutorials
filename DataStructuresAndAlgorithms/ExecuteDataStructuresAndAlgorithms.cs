using System;
using DataStructuresAndAlgorithms.Demos;

namespace DataStructuresAndAlgorithms
{
    class ExecuteDataStructuresAndAlgorithms
    {
        public static object StringAlgorithims { get; private set; }

        static void Main(string[] args)
        {
            //StringAlgorithms.Remove_Duplicate_Characters();
            //StringAlgorithms.Check_Whether_Two_Strings_Are_Anagrams_Of_Each_Other();
            //StringAlgorithms.Reverse_String_Using_Iteration();
            //StringAlgorithms.Count_Words_In_String();
            StringAlgorithms.Palindrome();

            Console.ReadKey();
        }
    }
}
