using System;

namespace DataStructuresAndAlgorithms.Demos
{
    class StringAlgorithms
    {
        /*
         * 1. Input: Csharpstar
         *    Output: Csharpt
         * 
         * 2. Input: Google
         *    Output: Gogle
         */
        /* Loop through the input string while checking if its characters already exist in 
         * new variable. The new variable starts out as an empty string, if the CURRENT 
           character do not exist its added the the new variable*/
        internal static void Remove_Duplicate_Characters()
        {
            string value1 = RemoveDuplicateChars("Csharpstar");
            string value2 = RemoveDuplicateChars("Google");
            string value3 = RemoveDuplicateChars("Yahoo");
            string value4 = RemoveDuplicateChars("CNN");

            Console.WriteLine($"{value1}");
            Console.WriteLine($"{value2}");
            Console.WriteLine($"{value3}");
            Console.WriteLine($"{value4}");
        }

        private static string RemoveDuplicateChars(string str)
        {
            var noDuplicate = string.Empty;
            var result = string.Empty;

            foreach (var value in str)
            {
                // If a character is not found we add it to noDuplicate variable.
                if (noDuplicate.IndexOf(value) == -1)
                {
                    noDuplicate += value;
                    result += value;
                }
            }
            return result;
        }

        /* Two words are said to be Anagrams of each other if they share the same set of 
         * letters to form the respective words */
        /* 
         * 1. Silent: Listen
         * 2. post: opts
         */
        internal static void Check_Whether_Two_Strings_Are_Anagrams_Of_Each_Other()
        {
            string word1 = "Silent";
            string word2 = "Listen";

            // Step 1  
            char[] char1 = word1.ToLower().ToCharArray();
            char[] char2 = word2.ToLower().ToCharArray();

            // Step 2
            Array.Sort(char1);
            Array.Sort(char2);

            // Step 3
            string newWord1 = new string(char1);
            string newWord2 = new string(char2);

            //Step 4  
            //ToLower allows to compare the words in same case, in this case, lower case.  
            //ToUpper will also do exact same thing in this context  
            if(newWord1 == newWord2)
            {
                Console.WriteLine($"Yes! Words {word1} and {word2} are Anagrams");
            }
            else
            {
                Console.WriteLine($"No! Words {word1} and {word2} are not Anagrams");
            }
        }

        internal static void Reverse_String_Using_Iteration()
        {         
            // Option 1
            var str1 = "George";
            var result = string.Empty;

            for (int i = str1.Length - 1; i > -1; i--)
            {
                result += str1[i];
            }

            Console.WriteLine($"Option 1: Original is {str1} and the reverse is {result}");

            // Option 2
            var str2 = "Nairobi";
            
            var temp = str2.ToCharArray();
            Array.Reverse(temp);

            result = new string(temp);

            Console.WriteLine($"Option 2: Original is {str2} and the reverse is {result}");
        }

        internal static void Count_Words_In_String()
        {
            var str = "A frop of water in the ocean";

            // Split on empty with NULL or with a character array with empty value at firs index(0).
            string[] myStringArray = str.Split(null);
            //string[] myStringArray = str.Split(new char[0]);

            Console.WriteLine($"No of words: {myStringArray.Length}");
        }

        /* A word, line, verse, number, sentence, etc., reading the same backward as forward. */
        internal static void Palindrome()
        {
            string word = "Madam";
            var result = string.Empty;

            var temp = word.ToLower().ToCharArray();

            Array.Reverse(temp);
            result = new String(temp);

            if (word.ToLower().Equals(result))
            {
                Console.WriteLine($"Result: {word} is a palindrome");
            }
        }

        internal static void Return_Character_With_Highest_Occurrence()
        {
            var str= "Google";
            var temp = string.Empty;
        }
    }
}
