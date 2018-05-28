using System;
using System.Collections.Generic;
using ImplementDataAccess.Entities.Dictionary;
using ImplementDataAccess.Helpers;

namespace ImplementDataAccess.Demos
{
    class UsingCollections
    {
        #region 1. Arrays
        internal static void Array()
        {
            // Initialization.
            int[] arrayOfInt = new int[10];
            //int[] arrayOfInt = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int x = 0; x < arrayOfInt.Length; x++)
            {
                // Populate each element with index value.
                arrayOfInt[x] = x;
            }

            foreach (int i in arrayOfInt)
            {
                Console.Write(i); // Displays 0123456789
            }
        }

        /* A two-dimensional array, for example, means that the array has a 
         * certain number of rows and columns. You declare it by using a comma (,) in 
         * your array declaration. The number of rows and columns can be different. 
         */
        internal static void Two_Dimensional_Array()
        {
            string[,] array2D = new string[3, 2] {{ "one", "two" }, { "three", "four" }, { "five", "six" }};

            Console.WriteLine(array2D[0, 0]); // one
            Console.WriteLine(array2D[0, 1]); // two
            Console.WriteLine(array2D[1, 0]); // three
            Console.WriteLine(array2D[1, 1]); // four
            Console.WriteLine(array2D[2, 0]); // five
            Console.WriteLine(array2D[2, 1]); // six
        }

        /* A jagged array is an array whose elements are arrays. Because arrays are reference 
         * types, the values of a jagged array have a default value of null. */
        internal static void Jagged_Array()
        {
            int[][] jaggedArray =
            {
                new int[] {1,3,5,7,9},
                new int[] {0,2,4,6},
                new int[] {42,21}
            };
        }

        /* THE BIGGEST PROBLEM WITH ARRAYS IS THAT THEY ARE OF FIXED SIZE. WHEN WORKING WITH GROUPS 
         * OF OBJECTS, YOU OFTEN WANT TO ADD OR REMOVE ITEMS FROM THE COLLECTION. THIS IS WHY THE .NET 
         * FRAMEWORK HAS SOME OTHER COLLECTION TYPES. */
        #endregion

        #region 2. Lists
        
        /* Remember that a list is just a wrapper around an array implementation. Zero base 
         * index, list count property is similar to array.length property. */
        internal static void List()
        {
            List<string> listOfStrings = new List<string> { "A", "B", "C", "D", "E" };

            Console.WriteLine($"Original list");
            PrintList(listOfStrings);

            listOfStrings.Remove("A");
            Console.WriteLine($"List after removing the first elemnt.");
            PrintList(listOfStrings);

            Console.WriteLine($"First element via index: {listOfStrings[0]}\n");

            // Remember the element is added at the end of the list.
            listOfStrings.Add("B");
            Console.WriteLine($"List after adding another element, REMEMBER LISTS ALLOWS DUPLICATES");
            PrintList(listOfStrings);

            Console.WriteLine($"Number of elements in the list: {listOfStrings.Count}.");

            bool hasC = listOfStrings.Contains("C");
            Console.WriteLine($"\nList contains C: {hasC}"); // Displays: true
        }

        private static void PrintList(List<string> list)
        {
            // List is zero based index just like an array.
            for (int x = 0; x < list.Count; x++)
            {
                Console.WriteLine($"{list[x]}");
            }

            Console.WriteLine("");
        }
        #endregion

        #region 3. Dicitionary

        internal static void Dictionary()
        {
            Person p1 = new Person { Id = 1, Name = "Name1" };
            Person p2 = new Person { Id = 2, Name = "Name2" };
            Person p3 = new Person { Id = 3, Name = "Name3" };

            var dict = new Dictionary<int, Person>();
            dict.Add(p1.Id, p1);
            dict.Add(p2.Id, p2);
            dict.Add(p3.Id, p3);
                  

            foreach (KeyValuePair<int, Person> v in dict)
            {
                Console.WriteLine($"{v.Key}: {v.Value.Name}");
            }

            dict[0] = new Person { Id = 4, Name = "Name4" };

            Person result;
            if (!dict.TryGetValue(5, out result))
            {                
                Console.WriteLine("No person with a key of 5 can be found");
            }

        }
        #endregion

        #region 4. Set

        /* In C#, a set is a reserved keyword, but you can use the HashSet<T> if you need one.
         * A set is a collection that contains no duplicate elements and has no particular order.
         */
        internal static void HashSet()
        {
            HashSet<int> oddSet = new HashSet<int>();
            HashSet<int> evenSet = new HashSet<int>();

            for (int x = 1; x <= 10; x++)
            {
                if (x % 2 == 0)
                    evenSet.Add(x);
                else
                    oddSet.Add(x);
            }

            DisplaySet(oddSet); 
            DisplaySet(evenSet);

            // Combines the two sets.
            oddSet.UnionWith(evenSet);
            DisplaySet(oddSet);
        }

        private static void DisplaySet(HashSet<int> set)
        {
            Console.Write("{");
            foreach (int i in set)
            {
                Console.Write($" {i} ");
            }
            Console.WriteLine("}");
        }
        #endregion

        #region 5. Queues and Stacks
        /*
         * Queue - FIFo
         * Stack - LIFO
         */
        internal static void Queue()
        {
            Queue<string> myQueue = new Queue<string>();
            myQueue.Enqueue("Hello");
            myQueue.Enqueue("World");
            myQueue.Enqueue("From");
            myQueue.Enqueue("A");
            myQueue.Enqueue("Queue");

            foreach (string s in myQueue)
            {
                 Console.Write($"{s} ");                
            }
        }

        internal static void Stack()
        {
            Stack<string> myStack = new Stack<string>();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push("From");
            myStack.Push("A");
            myStack.Push("Stack");

            foreach (string s in myStack)
            {
                Console.Write($"{s} ");
            }
        }
        #endregion

        #region 6. Custom Collection

        internal static void CustomCollection()
        {
            Entities.Custom_Collection.Person p1 = new Entities.Custom_Collection.Person { FirstName = "John", LastName = "Doe", Age = 42 };
            Entities.Custom_Collection.Person p2 = new Entities.Custom_Collection.Person { FirstName = "Jane", LastName = "Doe", Age = 21 };

            PeopleCollection people = new PeopleCollection { p1, p2 };
            people.RemoveByAge(42);

            Console.WriteLine($"{people.Count}");
        }
        #endregion
    }
}

