using System;

namespace CreateAndUseTypes.Entities
{
    class OuterClass
    {
        public void Execute()
        {
            Console.WriteLine("OuterClass");

            // We can access nested class with outer.
            //NestedClass nested = new NestedClass();
            //nested.Execute();

        }

        public NestedClass CreateObjectOfNestedClass()
        {
            NestedClass nested = new NestedClass();
            return nested;
        }

        public class NestedClass
        {
            public void Execute()
            {
                Console.WriteLine("NestedClass");
            }
        }
    }
}

/*
 * class Outer
    {
        void Foo() {}
        class Inner {}
    }

    THIS IS THE SAME AS:

    internal class Outer
    {
        private void Foo() {}
        private class Inner {}
    }

 */
