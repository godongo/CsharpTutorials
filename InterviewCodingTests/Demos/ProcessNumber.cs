using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCodingTests.Demos
{
    class ProcessNumber
    {
        internal static void Execute()
        {
            int[] numbers = { 65, 97, 97, 97, 97, 97};

            for (int i = 0; i < numbers.Length; i++)
            {
                //if (numbers[i] != numbers[i + 1])
                //{
                //    Console.Write(numbers[i] + " ");
                //}  
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
