using System;
using System.Collections.Generic;
using CreateAndUseTypes.Entities;

namespace CreateAndUseTypes.Demos
{

    class ObjectLifeCycle
    {
        internal static void CreateInsance()
        {
            Person p1 = new Person("George", 48);
            Console.WriteLine($"P1: {p1.ToString()}");

            Person p2 = new Person() { LastName = "John", Age = 29, Genre = "Male" };
            Console.WriteLine($"P2: {p2.LastName} {p2.Age} {p2.Genre}");

            Person p3 = new Person() { FirstName = "Beth" };
            Console.WriteLine($"P3: {p3.FirstName}");

            // Contains default name
            Person p4 = new Person();
            Console.WriteLine($"P4: {p4.FirstName}");
        }

        /* Allows to keep large objects in memory that can be reused and yet 
         * at the same time cannot  be cleared by the GARBAGE COLLECTOR.*/
        static WeakReference data;

        public static void Run()
        {
            object result = GetData();
            // GC.Collect(); Uncommenting this line will make data.Target null
            result = GetData();
        }

        static object GetData()
        {
            if (data == null)
            {
                data = new WeakReference(LoadLargeList());
            }

            if (data.Target == null)
            {
                data.Target = LoadLargeList();
            }

            return data.Target;
        }

        static List<string> LoadLargeList()
        {
            return new List<string>() { };
        }
    }
}
