using System;

namespace CreateAndUseTypes.Demos
{
    class NamedAndOptionalArguments
    {
        // Page 95
        internal static void UsingNamedParameters()
        {
            Console.WriteLine($"Sum: {AddNumber1(firstNumber: 10, secondNumber: 5)}");
        }

        private static int AddNumber1(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        internal static void UsingOptionalParameter()
        {

            Console.WriteLine($"Sum1: {AddNumber2(12)}");
            Console.WriteLine($"Sum2: {AddNumber2(12, 13)}");
        }

        private static int AddNumber2(int firstNumber, int secondNumber = 0)
        {
            return firstNumber + secondNumber;
        }
    }
}
