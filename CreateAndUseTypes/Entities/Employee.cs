using System;

namespace CreateAndUseTypes.Entities
{
    class Employee : Person1
    {
        public string ID { get; set; }
       
        internal void IntroduceSelf()
        {
            Console.WriteLine($"Hello my name is {Name} and my id is {ID}");
        }
    }
}
