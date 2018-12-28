using System;
using CSharpKeywords.Entities;

namespace CSharpKeywords.Demos
{
    /// <summary>
    /// Indexers simplifies the way we access a collection in a class.
    /// </summary>
    class UsingIndexer
    {
        internal static void Execute()
        {
            //GetAddressWithoutIndexer();
            GetAddressWithoutIndexer();

        }

        // Class exposes methods to access collection.
        private static void GetAddressWithoutIndexer()
        {
            Customer customer = new Customer();
            Address address = customer.GetAddress("SW1A 2AA");

            Console.WriteLine(address.Street);
        }

        private static void GetAddressWithIndexer()
        {
            Customer customer = new Customer();

            Address address = customer["SW1A 2AA"];

            Console.WriteLine(address.Street);
        }
    }
}
