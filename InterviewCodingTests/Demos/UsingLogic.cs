using System;

namespace InterviewCodingTests.Demos
{
    class UsingLogic
    {
        internal static void Swap()
        {
            var a = 10;
            var b = 22;
            int temp;

            temp = a;
            a = b;
            b = temp;

            Console.WriteLine($"Swapped values: a = {a} and b = {b}");
        }

        internal static void BubbleSort()
        {
            int[] numbers = { 101, 6, 51, 43, 99 };

            // This is just a wrapper that allows to manipulate the nested loop. 
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int x = 0; x < numbers.Length - 1; x++)
                {
                    if(numbers[x] > numbers[x + 1])
                    {
                        int temp = numbers[x];
                        numbers[x] = numbers[x + 1];
                        numbers[x + 1] = temp;
                    }
                }
            }

            foreach (var number  in numbers)
            {
                Console.Write(number + " ");
            }
        }
                
        internal static void FizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                if(i%15 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        internal static double Factorial(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * Factorial(number - 1);
        }

        internal static int Fibonacci_Nth(int number)
        {
            if ((number == 0) || (number == 1))
            {
                return number;
            }
            else
            {
                return Fibonacci_Nth(number - 1) + Fibonacci_Nth(number - 2);
            }
        }
    }
}
