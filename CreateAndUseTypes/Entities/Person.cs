using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAndUseTypes.Entities
{
    class Person
    {
        private string _firstName;

        // Auto-implemented property
        // The compiler translates this into a property with a private, anonymous backing field.
        public string LastName { get; set; }

        public int Age { get; set; }

        public string Genre { get; set; }

        public string FirstName
        {
            get { return _firstName; }

            set
            {
                if (String.IsNullOrEmpty(_firstName))
                    throw new ArgumentException();
                _firstName = value;
            }
        }

        public Person()
        {
            _firstName = "Mary";
        }

        public Person(string name, int age)
        {
            LastName = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{LastName} and {Age}";
        }
    }
}
