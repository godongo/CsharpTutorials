using System;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow.Demos
{
    /* 
 * IMPORTANT NOTES ABOUT LOCKS
1. It’s important to use the lock statement with a reference object that is private to the class. 
A public object could be used by other threads to acquire a lock without your code knowing.
2. It should also be a reference type because a value type would get boxed each time you acquired 
a lock. In practice, this generates a completely new lock each time, losing the locking mechanism. 
Fortunately, the compiler helps by raising an error when you accidentally use a value type for 
the lock statement.
3. You should also avoid locking on the THIS variable because that variable could be used by other code 
to create a lock, causing deadlocks.
4. For the same reason, you should not lock on a string. Because of string-interning (the process in which 
the compiler creates one object for several strings that have the same content) you could suddenly be 
asking for a lock on an object that is used in multiple places. 
 */
    class ManageMultithreading
    {
        // Shared resource accessed by two threads
        static int sharedData1 = 0;
        
        /* When you run this application, you get a different output each time. */
        internal static void AccessingSharedData()
        {
            // Tasks are just wrappers for thread from the thread pool.
            var up = Task.Run(() => WorkerThread_1());

            // This is executing on the main thread.
            for (int i = 0; i < 1000000; i++)
            {
                sharedData1--;
            }

            // Correct output should be zero(0)
            // We end with up inconsistent data upon each execution.
            Console.WriteLine($"Result: {sharedData1}");
        }

        private static void WorkerThread_1()
        {
            for (int i = 0; i < 1000000; i++)
            {
                sharedData1++;
            }
        }

        // This should be private to containing class.
        private object _lockDataAccess = new object();

        static int sharedData2 = 0;

        /* lock operator is a syntactic sugar that the compiler translates in a 
         * call to System.Thread.Monitor. 
         * System.Threading.Monitor.Enter() and System.Threading.Monitor.Exit() calls
         */
        internal static void AccessingSharedDataUsingLock()
        {            
            var up = Task.Run(() => WorkerThread_2());
                        
            for (int i = 0; i < 1000000; i++)
            {
                lock (new ManageMultithreading()._lockDataAccess)
                {
                    sharedData2--;
                }                    
            }

            // NEED TO RESEARCH MORE HOW TO IMPLEMENT ON LOCK ON A MULTICORE MACHINE.
            
            /* GeeNote: Correct implementation but answer not correct because 
             * machine is multicore. */
            Console.WriteLine($"Result: {sharedData2}");
        }

        private static void WorkerThread_2()
        {
            for (int i = 0; i < 1000000; i++)
            {
                lock (new ManageMultithreading()._lockDataAccess)
                {
                    sharedData2++;
                }                
            }
        }

        // GeeNoet 
        private static object lockA = new object();
        private static object lockB = new object();
                      
        internal static void CreatingADeadlock()
        {

            var up = Task.Run(() => WorkerThread_3());

            // Executing on the main thread. 
            lock (lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("Locked A and B");
                }
            }

            up.Wait();
        }

        private static void WorkerThread_3()
        {
            lock (lockA)
            {
                Thread.Sleep(1000);
                lock (lockB)
                {
                    Console.WriteLine("Locked A and B");
                }
            }
        }

        static int n = 0;

        // INTERLOCKED CLASS MAKES OPERATIONS ATOMIC.
        /* Interlocked guarantees that the increment and decrement operations 
         * are executed atomically. No other thread will see any intermediate results. 
         */
        internal static void UsingTheInterlockedClass()
        {
            // Worker thread.
            var up = Task.Run(() => WorkerThread_4());

            // Main thread.
            for (int i = 0; i < 1000000; i++)
            {
                Interlocked.Decrement(ref n);
            }

            up.Wait();
            Console.WriteLine(n);
        }

        private static void WorkerThread_4()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Interlocked.Increment(ref n);
            }                
        }
    }
}
