using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKeywords.Demos
{
    class UsingRefAndOut
    {
        internal static void Execute()
        {
            int normalNum = 20;            
            SomeFunction(normalNum);
            Console.WriteLine($"Normal: {normalNum}");

            int refNum = 20;
            RefFunction(ref refNum);
            Console.WriteLine($"Ref: {refNum}");

            //int outNum = 20;
            //OutFunction(out outNum); // This value will be discarded.
            OutFunction(out int outNum); // Better option.            
            Console.WriteLine($"Out: {outNum}");
        }

        // Values are lost when method exits.
        private static void SomeFunction(int insider)
        {            
            insider = insider + 10;
        }

        // Data moves both ways.
        private static void RefFunction(ref int insider)
        {            
            insider = insider + 10;
        }

        // Data moves from the method outwards
        // Out - Allows methods to return other values beside the return type where applicable.
        private static void OutFunction(out int insider)
        {
            // Parameter must be inialized.
            insider = 0;

            insider = insider + 40;
        }
    }
}
