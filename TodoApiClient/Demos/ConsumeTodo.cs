using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Entities;

namespace WebApiClient.Demos
{
    class ConsumeWebApi
    {
        internal static void GetTodoItems()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57516/api/");

                //HTTP GET
                var responseTask = client.GetAsync("todo");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TodoItem[]>();
                    readTask.Wait();

                    var todoItems = readTask.Result;

                    foreach (var todo in todoItems)
                    {
                        Console.WriteLine($"{todo.Name}");
                    }
                }

                Console.ReadKey();
            }
        }
    }
}
