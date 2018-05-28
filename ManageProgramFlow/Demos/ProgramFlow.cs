using System;

namespace ManageProgramFlow.Demos
{
    class ProgramFlow
    {
        internal static void OrShortCircuit()
        {
            bool x = true;
            // If x is true the right operand will not be evaluated.
            bool result = x || GetY();

            Console.WriteLine($"GetY() will not be called if x is TRUE");

        }

        internal static bool GetY()
        {
            Console.WriteLine("This method doesn’t get called");
            return true;
        }

        internal static void NullCheck()
        {
            string input = "value";

            bool result = (input != null) && (input.StartsWith("v"));

            Console.WriteLine($"Do something with the result = {result}");            
        }

        internal static void CodeBlockScoping()
        {
            bool b = true;
            if (b)
            {
                int r = 42;
                b = false;
            }
            // r is not accessible
            // b is now false

            Console.WriteLine($"The value of b has changed to {b}");
        }

        // ?? Provide a default value for nullable value types or for reference types.
        // The operator returns the left value if it’s not null; otherwise, the right operand.
        internal static void NullCoalescingOperator()
        {
            int? x = null;
            int y = x ?? -1;

            Console.WriteLine($"The value of y is {y} because x is null");
        }
        // ?: Returns one of two values depending on a Boolean expression.
        // If the expression is true, the first value is returned; otherwise, the second.
        internal static void ConditionalOperator()
        {
            var p = true;

            //if (p)
            //return 1;
            //else
            //return 0;

            // The above code can be replace with the one below

            var result = p ? 10 : 2;

            Console.WriteLine($"The value of result is {result}");
        }

        internal static void SwitchStatement()
        {
            char input = 'i';

            switch (input)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    {
                        Console.WriteLine($"Input is a vowel");
                        break;
                    }
                case 'y':
                    {
                        Console.WriteLine("Input is sometimes a vowel.");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Input is a consonant");
                        break;
                    }
            }
        }

        internal static void WhileLoop()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };

            // Extra parenthesis to restrict the scope of the loop variable.
            {
                int index = 0;
                while (index < values.Length)
                {
                    Console.WriteLine($"Index is {index} and Value at index is {values[index]}");
                    index++;
                }
            }
        }

        internal static void DoWhileLoop()
        {
            do
            {
                Console.WriteLine($"Executed once!");
            }
            while (false);
        }
    }
}
