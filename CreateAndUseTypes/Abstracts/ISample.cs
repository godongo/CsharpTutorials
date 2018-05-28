using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAndUseTypes.Abstracts
{
    internal interface ISample
    {
        string SomeProperty { get; }
        Func<int, int> MyDelegate { get; }
    }
}
