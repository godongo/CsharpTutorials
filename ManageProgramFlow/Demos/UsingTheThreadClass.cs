using System;
using System.Threading;

namespace ManageProgramFlow.Demos
{
    class UsingTheThreadClass
    {
        static internal void ExecuteAMethodOnAnotherThread()
        {
            // New thread.
            Thread t = new Thread(new ThreadStart(WorkerThread_1));
            t.Start();

            // Main thread.
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }
            
            // Tells main thread to wait till the other thread finishes execution.
            t.Join();
        }

        private static void WorkerThread_1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
            Thread.Sleep(0);
            }
        }

        // If there are only background threads application will terminate immediately.
        static internal void UsingABackgroundThread()
        {
            Thread t = new Thread(new ThreadStart(WorkerThread_2));

            // Application will terminate immediately.
            // GeeNote: BEHAVES DIFFERENTLY IN A MULTI-CORE MACHINE.
            //t.IsBackground = true; //(This is now a background thread).

            // Application will wait for this thread to finish executing.
            // GeeNote: BEHAVES DIFFERENTLY IN A MULTI-CORE MACHINE.
            t.IsBackground = false; //(This is now a foreground thread).

            t.Start();
        }

        private static void WorkerThread_2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(1000);
            }
        }

        /* Use Thread constructor overload that takes ParameterizedThreadStart 
         * delegate to pass data to worker method */
        static internal void PassingDataToWorkerThreadUsing_ParameterizedThreadStart_Delegate()
        {
            Thread t = new Thread(new ParameterizedThreadStart(WorkerThread_3));
            t.Start(5);
            t.Join();
        }

        private static void WorkerThread_3(object input)
        {
            for (int i = 0; i < (int)input; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(0);
            }
        }

        // Shared variable
        static bool stopped = false;

        static internal void StoppingAThreadUsingASharedVariable()
        {
            Thread t = new Thread(new ThreadStart(WorkerThread_4));
            t.Start();

            Console.WriteLine("Press any key to terminate worker thread.");
            Console.ReadKey();

            stopped = true;
            Console.WriteLine("Worker thread has been terminated.");
            t.Join();
        }

        private static void WorkerThread_4()
        {
            while (!stopped)
            {
                Console.WriteLine("Worker thread running...!!");
                Thread.Sleep(1000);
            }
        }

        /* GeeNote: A thread has its own call stack that stores all the methods that 
         * are executed. Local variables are stored on the call stack and are private 
         * to the thread. */
        // THREADSTATICATTRIBUTE ALLOWS EACH THREAD TO HAVE ITS OWN COPY OF THIS VARIABLE (_FIELD).
        [ThreadStatic]
        public static int _field1;

        static internal void UsingThreadStaticAttribute()
        {
            new Thread(new ThreadStart(WorkerThread_5)).Start();

            new Thread(new ThreadStart(WorkerThread_6)).Start();
        }

        private static void WorkerThread_5()
        {
            /* Local variables here are private and 
             * stored only on this thread's call stack. */
            for (int x = 0; x < 10; x++)
            {
                _field1++;
                Console.WriteLine($"Thread A: {_field1}");
            }
        }

        private static void WorkerThread_6()
        {
            /* Local variables here are private and 
             * stored only on this thread's call stack. */
            for (int x = 0; x < 10; x++)
            {
                _field1++;
                Console.WriteLine($"Thread B: {_field1}");
            }
        }

        /* GeeNote: Thread.CurrentThread class - Gives current thread's EXECUTION CONTEXT.
         * It gives you access to information about current thread.
         */ 
        public static ThreadLocal<int> _field2 =
                                    new ThreadLocal<int>(() =>
                                    {
                                        return Thread.CurrentThread.ManagedThreadId;
                                    });

        static internal void UsingThreadLocalToIntializeDataForEachThread()
        {
            new Thread(new ThreadStart(WorkerThread_7)).Start();

            new Thread(new ThreadStart(WorkerThread_8)).Start();
        }

        private static void WorkerThread_7()
        {
            for (int x = 0; x < _field2.Value; x++)
            {
                Console.WriteLine($"Thread A: {x}");
            }
        }

        private static void WorkerThread_8()
        {
            for (int x = 0; x < _field2.Value; x++)
            {
                Console.WriteLine($"Thread B: {x}");
            }
        }

        /* When you work with a thread pool from .NET, you queue a work item 
         * that is then picked up by an available thread from the pool. */
        internal static void QueuingSomeWorkToTheThreadpool()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");


                /* 
                 * Because the thread pool limits the available number of threads, 
                 * you do GET A LESSER DEGREE OF PARALLELISM than using the regular 
                 * Thread class
                 * */

                // Both of these methods will execute on the same thread.
                DoSomeWork1();
                DoSomeWork2();

                /* SHORT COMINGS OF THREAD POOL
                 * 1. No way of telling if a task is completed.
                 * 2. Not getting a result back.
                 * */

                // THESE SHORTCOMINGS ARE ADDRESSED THE TASKS.
            });
        }

        private static void DoSomeWork1()
        {
            Console.WriteLine($"DoSomeWork1: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        }

        private static void DoSomeWork2()
        {
            Console.WriteLine($"DoSomeWork2: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
