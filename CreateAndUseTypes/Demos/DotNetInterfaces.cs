using CreateAndUseTypes.Concretes;
using CreateAndUseTypes.Entities;
using System;
using System.Collections.Generic;

namespace CreateAndUseTypes.Demos
{
    class DotNetInterfaces
    {
        internal static void IComparableInterface()
        {
            List<OrderIComparable> orders = new List<OrderIComparable>
                {
                    new OrderIComparable { Created = new DateTime(2012, 12, 1 )},
                    new OrderIComparable { Created = new DateTime(2012, 1, 6 )},
                    new OrderIComparable { Created = new DateTime(2012, 7, 8 )},
                    new OrderIComparable { Created = new DateTime(2012, 2, 20 )},
                };

            orders.Sort();
        }

        /* 
         * Example: (Think of it this way)
         *  1. IEnumerable<T> is your table
         *  2. IEnumerator is a cursor that keeps track of where you are in the table. 
         *     It can only move to the next row.
         * */
        internal static void SyntacticSugarOfTheForeach()
        {            
            List<int> numbers = new List<int> { 1, 2, 3, 5, 7, 9 };

            // Internally how foreach loop works.
            using (List<int>.Enumerator enumerator = numbers.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine(enumerator.Current);
                }                    
            }
        }

        /* Whenever you do a lot of manual loops through the same data structure, 
         * think about the iterator pattern and how it can help you create way nicer code. */
        internal static void IEnumerableInterface()
        {
            Person[] people = 
                {
                    new Person { LastName = "Smith" },
                    new Person { LastName = "Jackson" },
                    new Person { LastName = "Doe" },
                    new Person { LastName = "Stevens" },
                    new Person { LastName = "Ross" }
                };

            var peopleEnumerable = new PeopleEnumerable(people);

            foreach(var person in peopleEnumerable)
            {
                Console.WriteLine(person.LastName);
            }                
        }
    }
}
