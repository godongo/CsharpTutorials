using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKeywords.Entities
{
    class Person
    {
        public int Age { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

        public static Person operator +(Person obj1, Person obj2)
        {
            Person obj3 = new Person();
            obj3.Age = obj1.Age + obj2.Age;
            obj3.Name = obj1.Name + obj2.Name;

            return obj3;
        }
    }
}
