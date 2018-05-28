using CreateAndUseTypes.Entities;
using System.Collections;
using System.Collections.Generic;

namespace CreateAndUseTypes.Demos
{
    class PeopleEnumerable : IEnumerable<Person>
    {
        Person[] people;

        public PeopleEnumerable(Person[] people)
        {
            this.people = people;
        }

        public IEnumerator<Person> GetEnumerator()
        {
            for (int index = 0; index < people.Length; index++)
            {
                yield return people[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
