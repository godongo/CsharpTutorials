using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManageProgramFlow.Demos
{
    /* During I/O operations and other similar operations on the main thread.
     * 1. Windows can pause the thread while waiting for operation to finish.
     * 2. During this time the thread stays idle and other threads are created 
     * to service other incoming requests. 
     */

    /* Asynchronous code solves this problem. Instead of blocking your thread until 
     * the I/O operation finishes, you get back a Task object that represents the result
     * of the asynchronous operation. By SETTING A CONTINUATION ON THIS TASK, you can 
     * continue when the I/O is done. IN THE MEANTIME, YOUR THREAD IS AVAILABLE FOR OTHER WORK.
     * WHEN THE I/O OPERATION FINISHES, WINDOWS NOTIFIES THE RUNTIME AND THE CONTINUATION TASK 
     * IS SCHEDULED ON THE THREAD POOL. */

    /*
     * REMEMBER THE ENTRY METHOD(MAIN) OF AN APPLICATION CAN'T BE MARKED AS ASYNC.
     */

    class UsingAsyncAndAwait
    {         
        internal static void SimpleAsyncCall()
        {
            Console.WriteLine($"Result: {DownloadContent().Result}");
        }

        /* A method marked with async just starts running synchronously on the current thread. 
         * What it does is enable the method to be split into multiple pieces when await is applied. */
        private static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                // Basically a new thread is created at this point/ asynchronous call.
                // MAIN THREAD WILL CONTINUE TO SERVE OTHER REQUESTS UNTILL THIS HAS FINISHED EXECUTING.
                string result = await client.GetStringAsync("http://www.microsoft.com");

                //string result = await GetResult(client);

                return result;
            }
        }

        private static async Task<string> GetResult(HttpClient client)
        {
            return await client.GetStringAsync("http://www.microsoft.com");
        }
    }
}
