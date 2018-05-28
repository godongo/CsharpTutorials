using System;

namespace Debugging
{
    class Program
    {
        static string someVar = string.Empty;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Method1();

            Console.ReadKey();
        }

        private static void Method1()
        {
            someVar = "Executing in method 1";
            Console.WriteLine(someVar);

            Method2();
        }

        private static void Method2()
        {
            someVar = "Executing in method 2";

            Console.WriteLine(someVar);
        }
    }
}
