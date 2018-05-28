using System;
using CreateAndUseTypes.Entities;

namespace CreateAndUseTypes.Demos
{
    class UsingTypes
    {
        internal static void ValueTypeDeclaration()
        {
            float f = 1.2f;
            double d = 1.2d;
            uint u = 2u;
            long l = 2L;
            ulong ul = 2UL;
            decimal m = 2m;

            Console.WriteLine($"Float: {f}");
            Console.WriteLine($"Double: {d}");
            Console.WriteLine($"Uint: {u}");
            Console.WriteLine($"Long: {l}");
            Console.WriteLine($"Ulong: {ul}");
            Console.WriteLine($"Decimal: {m}");
        }
        internal static void SimpeIndexer()
        {
            IndexedNames names = new IndexedNames();
            names[0] = "Zara";
            names[1] = "Riz";
            names[2] = "Nuha";
            names[3] = "Asif";
            names[4] = "Davinder";
            names[5] = "Sunil";
            names[6] = "Rubic";

            for (int i = 0; i < IndexedNames.size; i++)
            {
                Console.WriteLine(names[i]);
            }
        }

        internal static void GenericClass()
        {
            GenericClass<int> myInt = new GenericClass<int>(5);
            myInt.Write();

            GenericClass<string> myString = new GenericClass<string>("my string");
            myString.Write();
        }

        internal static void UserDefinedConversions()
        {
            Money m = new Money(42.42M);

            /* Assignment will automatically invoke implicit
               decimal conversion. */
            decimal amount = m;

            int truncatedAmount = (int)m;
        }

        internal static void TestClass()
        {
            //throw new NotImplementedException();

            TestClass t = new TestClass("TestClass");
            //t....the nested class : Not accessible
            //TestClass.TestClassNest : Accessing a nested class
        }

        internal static void NestedClass()
        {
            //throw new NotImplementedException();
            new OuterClass().Execute();

            // ALL CLASS MEMBERS ARE PRIVATE BY DEFAULT.
            //NestedClass nested = new NestedClass();
            

            OuterClass outer = new OuterClass();
            // MUST FULLY QUALIFY FROM OUTER TO ACCESS NESTED.
            OuterClass.NestedClass nested = outer.CreateObjectOfNestedClass();
            nested.Execute();
        }
    }
}
