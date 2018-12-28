using System;
using InterviewCodingTests.Demos;

namespace InterviewCodingTests
{
    // SHOULD ALSO INCLUDE C# KATAS IN THIS PROJECT.

    class ExecuteInterviewCodingTests
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 8; i++)
            {
                var check = i;
                                
                for (int x = 0; x < check; x++)
                {
                    Console.Write("#");
                }
                Console.WriteLine("");                
            }

            //UsingLogic.Swap();
            //UsingLogic.BubbleSort();
            //UsingLogic.FizzBuzz();

            //Console.WriteLine(UsingLogic.Factorial(5));

            //Console.WriteLine(UsingLogic.Fibonacci_Nth(6));
            
            //RandomCode.AnArrayOfLists();

            //ProcessNumber.Execute();

            Console.ReadKey();
        }
    }
}
