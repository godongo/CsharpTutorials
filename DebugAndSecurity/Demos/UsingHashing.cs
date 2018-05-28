using DebugAndSecurity.Concretes;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DebugAndSecurity.Demos
{
    class UsingHashing
    {
        internal static void ExampleWithoutHashing()
        {
            IntSet1 mySet = new IntSet1();
            mySet.Insert(11);
            mySet.Insert(3);
            mySet.Insert(14);
            mySet.Insert(12);

            foreach (var item in mySet.SetList)
            {
                Console.WriteLine($"{item}");
            }
        }

        internal static void ExampleWithHashing()
        {
            // Looks at the following classes.

            //IntSet2 mySet = new IntSet2();

            //implementation here.....
            // SetWithHashing<T>
        }

        internal static void UsingSHA256ManagedToCalculateHashCode()
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            SHA256 sha256 = SHA256.Create();

            string data = "A paragraph of text";
            byte[] hashA = sha256.ComputeHash(byteConverter.GetBytes(data));

            data = "A paragraph of changed text";
            byte[] hashB = sha256.ComputeHash(byteConverter.GetBytes(data));

            data = "A paragraph of text";
            byte[] hashC = sha256.ComputeHash(byteConverter.GetBytes(data));

            Console.WriteLine(hashA.SequenceEqual(hashB)); // Displays: false
            Console.WriteLine(hashA.SequenceEqual(hashC)); // Displays: true
        }
    }
}
