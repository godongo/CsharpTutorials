using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAndUseTypes.Entities
{
    class TestClass
    {
        public TestClass(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public class TestClassNest { }
    }
}
