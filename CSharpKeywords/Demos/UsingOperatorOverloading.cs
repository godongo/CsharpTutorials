using System;
using CSharpKeywords.Entities;

namespace CSharpKeywords.Demos
{
    class UsingOperatorOverloading
    {
        internal static void Execute()
        {
            // Method overloading, executed method depends on parameters passed.
            Add(3, 5);
            Add(5, 4, 9);

            // Operation depends on data type used.
            // 1 + 2 = 3
            // obj1 + obj2 = obj3

            // Poly = Many
            // Morph = Changes with the situation

            Person obj1 = new Person()
            {
                Age = 10,
                Name = "George"
            };

            Person obj2 = new Person()
            {
                Age = 20,
                Name = "Odongo"
            };

            Person obj3 = new Person();
            obj3.Age = obj1.Age + obj2.Age;
            obj3.Name = obj1.Name + obj2.Name;

            Console.WriteLine($"Age = {obj3.Age} and Name = {obj3.Name}");
        }

        static void Add(int num1, int num2)
        {
        }

        static void Add(int num1, int num2, int num3)
        {
        }

    }
}
