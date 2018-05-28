using static System.Console;

namespace CSharpVersions.Demos
{
    class CSharp7
    {
        /* Using nested functions inside a function is called local function. */
        internal static void Local_Functions()
        {
            void Add(int x, int y)
            {
                WriteLine($"Sum of {x} and {y} is : {x + y}");
            }

            void Multiply(int x, int y)
            {
                WriteLine($"Product of {x} and {y} is : {x * y}");
                Add(30, 10);
            }

            Add(20, 50);
            Multiply(20, 50);
        }
    }
}
