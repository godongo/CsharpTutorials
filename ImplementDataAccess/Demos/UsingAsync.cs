using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ImplementDataAccess.Demos
{
    /// <summary>
    /// Gee Reminder: JUST SAMPLE CODE, NO NEED TO EXECUTE.
    /// </summary>
    class UsingAsync
    {
        // Remember this is similar to a void method.
        // When a method does have a return value, it returns Task<T>, where T is the type of the value that is returned.
        public async Task CreateAndWriteAsyncToFile()
        {
            string path = @"C:\GeeCentral\Dev\C#\TempFileTutorial\test.dat";

            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                byte[] data = new byte[100000];
                new Random().NextBytes(data);

                // CALLS A VOID METHOD.
                await stream.WriteAsync(data, 0, data.Length);
            }
        }

        public async Task ReadAsyncHttpRequest()
        {
            HttpClient client = new HttpClient();

            // CALLS A METHOD WITH A RETURN TYPE.
            string result = await client.GetStringAsync("http://www.microsoft.com");
        }

        // The amount of time the method takes is the sum of the three web requests.
        public async Task ExecuteMultipleRequests()
        {
            HttpClient client = new HttpClient();

            string microsoft = await client.GetStringAsync("http://www.microsoft.com");
            string msdn = await client.GetStringAsync("http://msdn.microsoft.com");
            string blogs = await client.GetStringAsync("http://blogs.msdn.com/");
        }

        /* If you would execute those requests in parallel, you would only have to wait as long 
           as the longest request takes (the other two will already be finished) */
        public async Task ExecuteMultipleRequestsInParallel()
        {
            HttpClient client = new HttpClient();

            Task microsoft = client.GetStringAsync("http://www.microsoft.com");
            Task msdn = client.GetStringAsync("http://msdn.microsoft.com");
            Task blogs = client.GetStringAsync("http://blogs.msdn.com/");

            await Task.WhenAll(microsoft, msdn, blogs);
        }
    }
}
