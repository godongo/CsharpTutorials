using System;

namespace CreateAndUseTypes.Abstracts
{
    interface IExample
    {
        string GetResult();

        int Value { get; set; }

        // Can be implemented with Get and Set.
        // Any client code calling concretes via interface will only see Get.
        int ReadOnly { get; }

        event EventHandler ResultRetrieved;

        int this[string index] { get; set; }
    }
}
