using System;
using System.Linq;

namespace ManageProgramFlow.Demos
{
    class UsingPLINQ
    {
        /* WITHEXECUTIONMODE METHOD:
         * You can specify that it should always execute the query in parallel.
         */

        /* WITHDEGREEOFPARALLELISM METHOD:
         * You can also limit the amount of parallelism that is used with this method.
         * */

        /* One thing to keep in mind is that parallel processing does not 
         * guarantee any particular order. */
        // RESULTS WILL DEPEND ON THE AMOUNT OF CPUS THAT ARE AVAILABLE.
        internal static void AsParallelQuery()
        {
            var numbers = Enumerable.Range(0, 100);

            // Gets even numbers only.
            var parallelResult = numbers.AsParallel()
            .Where(i => i % 2 == 0)
            .ToArray();

            foreach (var number in parallelResult)
            {
                Console.WriteLine($"{number}");
            }                         
        }

        internal static void AsOrdered()
        {
            var numbers = Enumerable.Range(0, 10);

            var parallelResult = numbers.AsParallel().AsOrdered()
            .Where(i => i % 2 == 0)
            .ToArray();

            foreach (var number in parallelResult)
            {
                Console.WriteLine($"{number}");
            }
        }

        /* Shows how you can use the AsSequential operator to make sure that the 
         * Take method doesn’t mess up your order. */
        internal static void AsSequential()
        {
            var numbers = Enumerable.Range(0, 20);

            var parallelResult = numbers.AsParallel().AsOrdered()
            .Where(i => i % 2 == 0).AsSequential();

            foreach (int number in parallelResult.Take(5))
            //foreach (var number in parallelResult)
            {
                Console.WriteLine($"{number}");
            }
        } 
        
        internal static void CatchingAggregateException()
        {
            var numbers = Enumerable.Range(0, 20);

            try
            {
                var parallelResult = numbers.AsParallel()
                .Where(i => IsEven(i));

                parallelResult.ForAll(e => Console.WriteLine($"{e}"));
            }
            catch (AggregateException e)
            {
                // For 0 and 10 catch block will be executed.
                Console.WriteLine($"There where {e.InnerExceptions.Count} exceptions");
            }
        }

        public static bool IsEven(int i)
        {
            // 0 and 10 will cause exception to be thrown.
            if (i % 10 == 0) throw new ArgumentException("i");

            return i % 2 == 0; 
        }
    }
}
