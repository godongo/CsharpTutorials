using CreateAndUseTypes.Abstracts;
using System;

namespace CreateAndUseTypes.Concretes
{
    class ExampleImplementation : IExample
    {
        public string GetResult()
        {
            return "result";
        }

        public int Value { get; set; }

        // If this class is called via interface only GET will be visible.
        // Direct users of this class will see both the GET and the SET accessors.
        public int ReadOnly { get; set; }

        public event EventHandler CalculationPerformed;

        public event EventHandler ResultRetrieved;

        public int this[string index]
        {
            get
            {
                return 42;
            }
            set { }
        }
    }
}
