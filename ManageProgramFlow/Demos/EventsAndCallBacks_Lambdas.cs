using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProgramFlow.Demos
{
    class EventsAndCallBacks_Lambdas
    {
        public delegate int MyCalculate(int x, int y);

        internal static void SimpleLambdas()
        {
            MyCalculate calc = (x, y) => x + y;

            Console.WriteLine($"Sum is {calc(3, 4)}"); 

            // Redefine the same delegate with different lambda expression.
            calc = (x, y) => x * y;

            Console.WriteLine($"Product is {calc(3, 4)}");          
        }

        internal static void LambdaExpressionWithMultipleStatements()
        {
            MyCalculate calc = (x, y) =>
                                {
                                    Console.WriteLine("Adding numbers");
                                    return x + y;
                                };
            int result = calc(3, 4);
            // Displays
            // Adding numbers

            Console.WriteLine($"Product is {result}");           
        }

        internal static void UsingBuiltInDelegates()
        {
            // TAKES 0 TO 16 PARAMETERS.
            // Func<T>, Action<T>, Predicates.
            // Last parameter is the RETURN TYPE for Func<T>.

            Func<int,int,int> calc1 = (x, y) => x + y;

            Console.WriteLine($"Func Sum is {calc1(3, 4)}"); 

            // Redefine the same delegate.
            calc1 = (x, y) => x * y;

            Console.WriteLine($"Func Product is {calc1(3, 4)}");

            //========= NO RETURN TYPE OR VOID METHOD

            Action<int, int> calc2 = (x, y) =>
            {
                Console.WriteLine($"Action Sum is {x + y}");
            };

            calc2(3, 4); 

        }


    }
}
