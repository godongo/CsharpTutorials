using System;
using CreateAndUseTypes.Abstracts;

namespace CreateAndUseTypes.Concretes
{
    class Sample : ISample
    {
        //public Func<int, int> MyDelegate => throw new NotImplementedException();
        public Func<int, int> MyDelegate => x => x * 2;

        //public string SomeProperty => throw new NotImplementedException();
        public string SomeProperty
        {
            get
            {
                return "some value";
            }
        }
    }
}
