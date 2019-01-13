using static System.Console;

using CSharpVersions.Concretes;

namespace CSharpVersions.Demos
{
    class CSharp7
    {
        internal static void Execute()
        {
            //LocalFunctions.Execute();    
            BinaryLiterals();
        }

        /// <summary>
        /// Binary Literal  
        /// int x = 0B110010;
        /// or
        /// int x = 0b110010;
        /// </summary>
        private static void BinaryLiterals()
        {
            //Represent 50 in decimal, hexadecimal & binary  
            int a = 50; // decimal representation of 50  
            int b = 0X32; // hexadecimal representation of 50  
            int c = 0B110010; //binary representation of 50  
            //Represent 100 in decimal, hexadecimal & binary  
            int d = 50 * 2; // decimal represenation of 100   
            int e = 0x32 * 2; // hexadecimal represenation of 100  
            int f = 0b110010 * 2; //binary represenation of 100 
            
            WriteLine($"a: {a:0000} b: {b:0000} c: {c:0000}");
            WriteLine($"d: {d:0000} e: {e:0000} f: {f:0000}");
        }

        private static void DigitSeperators()
        {
        }

        private static void PatterMatching()
        {
        }


    }
}
