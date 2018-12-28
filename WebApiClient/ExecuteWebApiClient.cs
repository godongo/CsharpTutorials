using System;
using System.Net.Http;
using WebApiClient.Entities;
using WebApiClient.Demos;

namespace WebApiClient
{
    class ExecuteWebApiClient
    {
        static void Main(string[] args)
        {
            ConsumeWebApi.GetTodoItems();

            

            Console.ReadKey();
        }
    }
}
