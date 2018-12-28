using System;
using System.Collections.Generic;

namespace CSharpKeywords.Demos
{
    /// <summary>
    /// 1. Custom iteration without a temp collection.
    /// 2. Stateful interation
    /// WHEN YIELD KEYWORD IS ENCOUNTERED CALL RETURNS TO CALLER.
    /// </summary>
    class UsingYield
    {
        static List<int> MyList = new List<int>();

        static UsingYield()
        {
            MyList.Add(1);
            MyList.Add(2);
            MyList.Add(3);
            MyList.Add(4);
            MyList.Add(5);
        }

        internal static void Execute()
        {
            //foreach (var i in MyList)
            //foreach (var i in FilterWithTempCollection())
            //foreach (var i in FilterWithYield())
            foreach (var i in RunningTotalStatefulIteration())
            {
                Console.WriteLine(i);
            }           
        }

        // Method returns once filtering is complete.
        static IEnumerable<int> FilterWithTempCollection()
        {
            List<int> temp = new List<int>();

            foreach (var i in MyList)
            {
                if (i > 3)
                {
                    temp.Add(i);
                }
            }

            return temp;
        }

        // Method returns for each element that meets condition.
        static IEnumerable<int> FilterWithYield()
        {
            foreach (var i in MyList)
            {
                if (i > 3)
                {
                    yield return i;
                }
            }
        }

        // Basically returning a collection of something else related to MyList.
        static IEnumerable<int> RunningTotalStatefulIteration()
        {
            int runningTotal = 0;

            // When call returns to caller runningTotal value is preserved.
            foreach (var i in MyList)
            {
                runningTotal += i;
                yield return (runningTotal);
            }
        }
    }
}
