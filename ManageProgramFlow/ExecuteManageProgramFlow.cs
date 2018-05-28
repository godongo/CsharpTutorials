using System;
using ManageProgramFlow.Demos;

namespace ManageProgramFlow
{
    class ExecuteManageProgramFlow
    {
        static void Main(string[] args)
        {
            // OUTMOST CONFIGURATION WHEN DEALING WITH MULTI-THREADING.
            //UsingTheThreadsClass.ExecuteAMethodOnAnotherThread();
            //UsingTheThreadsClass.UsingABackgroundThread();
            //UsingTheThreadsClass.PassingDataToWorkerThreadUsing_ParameterizedThreadStart_Delegate();
            //UsingTheThreadsClass.StoppingAThreadUsingASharedVariable();
            //UsingTheThreadsClass.UsingThreadStaticAttribute();
            //UsingTheThreadsClass.UsingThreadLocalToIntializeDataForEachThread();
            //UsingTheThreadClass.QueuingSomeWorkToTheThreadpool();

            // HANDLING WITH LONG RUNNING CPU WORKLOAD AND ADDRESSES THREAD POOL SHORTCOMINGS.
            //UsingTasks.StartingANewTask();
            //UsingTasks.TaskWithReturnValue();
            //UsingTasks.TaskWithReturnValue_Adding_A_Continuation();
            //UsingTasks.TaskWithMultipleContinuationMethods();
            //UsingTasks.AttachingChildTasksToParentTask();
            //UsingTasks.UsingTaskFactoryToCreateChildTasks();
            //UsingTasks.UsingTaskWaitAll();
            //UsingTasks.UsingTaskWaitAny();

            // SPLITS TASKS INTO SMALL CHUNKS FOR CONCURRENT EXECUTION.
            //UsingTheParallelClass.Stopwatch();
            //UsingTheParallelClass.ParallelFor();
            //UsingTheParallelClass.ParallelForeach();

            // ALLOW REUSING UNUSED IDLE THREADS E.G DURING I/O OPERATIONS.  
            //UsingAsyncAndAwait.SimpleAsyncCall();

            //UsingPLINQ.AsParallelQuery();
            //UsingPLINQ.AsOrdered();
            //UsingPLINQ.AsSequential();
            //UsingPLINQ.CatchingAggregateException();

            //UsingConcurrentCollections.BlockingCollection();
            //UsingConcurrentCollections.ConcurrentBag();
            //UsingConcurrentCollections.EnumeratingAConcurrentBag();

            //ManageMultithreading.AccessingSharedData();
            //ManageMultithreading.AccessingSharedDataUsingLock();
            //ManageMultithreading.CreatingADeadlock();
            ManageMultithreading.UsingTheInterlockedClass();

            //ProgramFlow.OrShortCircuit();
            //ProgramFlow.SwitchStatement();
            //ProgramFlow.WhileLoop();   

            //EventsAndCallBacks_Delegates.UseDelegate();
            //UseDelegateFromAnotherClass();
            //EventsAndCallBacks_Delegates.MultiCastingDelegates();

            //EventsAndCallBacks_Lambdas.SimpleLambdas();
            //EventsAndCallBacks_Lambdas.LambdaExpressionWithMultipleStatements();
            //EventsAndCallBacks_Lambdas.UsingBuiltInDelegates();

            //EventsAndCallBacks_Events.CreateAndRaise();

            //ExceptionHandling.UnhandledException();
            //ExceptionHandling.HandleExeption();
            //ExceptionHandling.CatchingDifferentExceptionTypes();
            //ExceptionHandling.FinallyBlock();
            //ExceptionHandling.InspectException();

            Console.WriteLine($"Program exiting....");
            Console.ReadKey();
        } 
        
        static void UseDelegateFromAnotherClass()
        {
            // Defined in the namespace scope.
            Calculate calc = EventsAndCallBacks_Delegates.Add;
            Console.WriteLine($"Sum is { calc(3, 4)}"); 

            // Defined within(nested) in a class.
            // Note the delegate is accessed similar to a nested class.
            EventsAndCallBacks_Delegates.CalculateInner sum = Sum;
            Console.WriteLine($"Product is { sum(3, 4)}");
        }

        static int Sum(int a, int b)
        {
            return a * b;
        } 


    }    
}
