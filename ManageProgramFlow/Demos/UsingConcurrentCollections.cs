using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow.Demos
{
    class UsingConcurrentCollections
    {
        /* YOU CAN EVEN REMOVE THE WHILE(TRUE) BY USING THE GetConsumingEnumerable method, 
         * YOU GET AN IENUMERABLE THAT BLOCKS UNTIL IT FINDS A NEW ITEM. THAT WAY, YOU CAN 
         * USE A FOREACH WITH YOUR BLOCKINGCOLLECTION TO ENUMERATE IT 
         */

        // Calling threads are blocked on read and write operations.
        internal static void BlockingCollection()
        {
            // Collection can be declared anywhere.
            BlockingCollection<string> col = new BlockingCollection<string>();            

            // We can reference a method anywhere.
            Task read = Task.Run(() =>
            {
                // Blocks if there is no items in the collection.
                while (true)
                {
                    // Some implementation......... 
                    // Ref to BlockingCollection.
                    Console.WriteLine(col.Take());
                }

                // Or we use the following code instead of the WHILE LOOP.
                //foreach (string v in col.GetConsumingEnumerable())
                //{
                //    Console.WriteLine(v);
                //}
                    
            });

            // We can reference a method anywhere.
            Task write = Task.Run(() =>
            {
                // Blocks if there is no room in the collection.
                while (true)
                {
                    // Some implementation.........                    
                    string s = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(s)) break;

                    // Ref to BlockingCollection.
                    col.Add(s);
                }
            });

            write.Wait();
        }

        /* One thing to keep in mind is that the TryPeek method is not very useful in a 
         * multithreaded environment. It could be that another thread removes the item 
         * before you can access it. 
         */
        internal static void ConcurrentBag()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(42);
            bag.Add(21);

            int result;
            if (bag.TryTake(out result))
                Console.WriteLine(result);

            if (bag.TryPeek(out result))
                Console.WriteLine($"There is a next item: {result}");
        }

        /* 
         * ConcurrentBag also implements IEnumerable<T>, so you can iterate over it. 
         * This operation is made thread-safe by making a snapshot of the collection 
         * when you start iterating it, so items added to the collection after you started 
         * iterating it won’t be visible.  
         */
        internal static void EnumeratingAConcurrentBag()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });

            Task.Run(() =>
            {
                foreach (int i in bag)
                {
                    Console.WriteLine($"{i}");
                }
                   
            }).Wait();
        }
    }
}
