using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow.Demos
{
    /* 
     * TASK ESSENTIALLY ADDRESSES SHORTCOMINGS OF THREAD POOL.
     * Queuing a work item to a thread pool can be useful, but it has its shortcomings. 
     * 1. There is no built-in way to know when the operation has finished.
     * 2. What the return value is. 
     * TASK IS AN OBJECT THAT REPRESENTS SOME WORK THAT SHOULD BE DONE.
     * 
     * REMEMBER THAT TASK DOESN'T HELP WITH SCALABILITY.
     */
    class UsingTasks
    {
        internal static void StartingANewTask()
        {
            Task t = Task.Run(() => Task1());

            // This is similar to call t.Join()
            // It waits till the Task is finished before exiting the application.
            t.Wait();            
        }
        
        private static void Task1()
        {
            for (int x = 0; x < 100; x++)
            {
                Console.WriteLine($"*");
            }

            Console.WriteLine($"End of task!");
        }
        
        internal static void TaskWithReturnValue()
        {
            Task<int> t = Task.Run(() => Task2());

            /* Attempting to read the Result property on a Task will force 
             * the thread that’s trying to read the result to wait until the 
             * Task is finished before continuing. */
            // IF THE TASK IS NOT FINISHED, THIS CALL WILL BLOCK THE CURRENT THREAD.
            Console.WriteLine($"Task return value: {t.Result}");
        }

        private static int Task2()
        {
            return 42;
        }

        internal static void TaskWithReturnValue_Adding_A_Continuation()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });

            Console.WriteLine($"Task return value: {t.Result}");
        }

        /* Use differenct continuation methods for different scenarios, 
         * for example when an exception happens, the Task is canceled, 
         * or the Task completes successfully. */
        /* THE CONTINUEWITH METHOD HAS A COUPLE OF OVERLOADS 
         * THAT YOU CAN USE TO CONFIGURE WHEN THE CONTINUATION WILL RUN. */
        internal static void TaskWithMultipleContinuationMethods()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine($"Task return value: {t.Result}");
                Console.WriteLine("Completed");

            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            completedTask.Wait();
        }

        internal static void AttachingChildTasksToParentTask()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];

                // Instead of creating these task manually you can use a TASKFACTORY instead.
                new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();

                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();

                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();

                return results;
            });

            // The finalTask runs only after the parent Task is finished.
            // The parent Task finishes when all three children are finished.
            var finalTask = parent.ContinueWith(
                parentTask => 
                {
                    foreach (int i in parentTask.Result)
                    {
                        Console.WriteLine($"{i}");
                    }
                });

            finalTask.Wait();
            Console.WriteLine($"Completed!");
        }

        internal static void UsingTaskFactoryToCreateChildTasks()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];

                // TaskFactory for child tasks with the same configurations.
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => results[0] = 0);
                tf.StartNew(() => results[1] = 1);
                tf.StartNew(() => results[2] = 2);

                return results;
            });

            var finalTask = parent.ContinueWith(
                parentTask => {
                    foreach (int i in parentTask.Result)
                    {
                        Console.WriteLine($"{i}");
                    }                      
                });

            finalTask.Wait();
        }

        internal static void UsingTaskWaitAll()
        {
            Task[] tasks = new Task[3];

            /* All three Tasks are executed simultaneously, and the whole run 
             * takes approximately 1000ms instead of 3000. */
            tasks[0] = Task.Run(() => {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });

            tasks[1] = Task.Run(() => {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });

            tasks[2] = Task.Run(() => {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });

            Task.WaitAll(tasks);            
        }

        internal static void UsingTaskWaitAny()
        {
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);

                Task<int> completedTask = tasks[i];

                Console.WriteLine(completedTask.Result);

                // Convert to list then remove executed task.
                var temp = tasks.ToList();
                temp.RemoveAt(i);

                tasks = temp.ToArray();
            }
        }
    }
}
