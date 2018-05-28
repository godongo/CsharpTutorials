using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProgramFlow.Demos
{
    // Declared at the namespace scope.
    public delegate int Calculate(int x, int y);

    class EventsAndCallBacks_Delegates
    {
        public delegate int CalculateInner(int x, int y);

        internal static int Add(int x, int y)
        {
            return x + y;
        }

        internal static int Multiply(int x, int y)
        {
            return x * y;
        }

        internal static void UseDelegate()
        {
            Calculate calc = Add;
            Console.WriteLine(calc(3, 4)); // Displays 7

            calc = Multiply;
            Console.WriteLine(calc(3, 4)); // Displays 12
        }

        internal delegate void Del();

        internal  static void MultiCastingDelegates()
        {
            Del d = MethodOne;
            // Add subsequent methods to invocation list. 
            d += MethodTwo;

            int invocationCount = d.GetInvocationList().GetLength(0);

            Console.WriteLine($"No. of methods in the invocationlist {invocationCount}");

            d();

        }

        internal static void MethodOne()
        {
            Console.WriteLine("MethodOne");
        }

        internal static void MethodTwo()
        {
            Console.WriteLine("MethodTwo");
        }


    }
}
