using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow.Demos
{
    /* Parallelism involves taking a certain task and SPLITTING IT INTO 
     * A SET OF RELATED TASKS THAT CAN BE EXECUTED CONCURRENTLY. 
     * You should use the parallel class only when your code 
     * doesn’t have to be executed sequentially. */

    /* THE BEST WAY TO KNOW WHETHER PARALLELISM WILL WORK IN YOUR SITUATION 
     * IS TO MEASURE THE RESULTS. */
    class UsingTheParallelClass
    {
        internal static void Stopwatch()
        {
            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();

            // Do something.
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(1);
            }

            // Stop timing.
            stopwatch.Stop();

            // Write result.
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
        }

        internal static void ParallelFor()
        {
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"{i}");
            });            
        }

        internal static void ParallelForeach()
        {
            var numbers = Enumerable.Range(0, 10);

            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"{i}");
            });
        }

        /* PARALLELLOOPSTATE OBJECT
         * You can cancel the loop by using the ParallelLoopState object. You have two 
         * options to do this: Break or Stop. 
         * 1. Break ensures that all iterations that are currently running will be finished. 
         * 2. Stop just terminates everything. */
        
        internal static void UsingParallelBreak()
        {
            ParallelLoopResult result = Parallel.
            For(0, 1000, (int i, ParallelLoopState loopState) =>
            {
                if (i == 500)
                {
                    Console.WriteLine("Breaking loop");
                    loopState.Break();
                }
                return;
            });
        }

        /* When breaking the parallel loop, the result variable has an IsCompleted value 
         * of false and a LowestBreakIteration of 500. When you use the Stop method, the 
         * LowestBreakIteration is null. */
    }
}
