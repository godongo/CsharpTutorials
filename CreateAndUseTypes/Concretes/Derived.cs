using System;

namespace CreateAndUseTypes.Concretes
{
    class Derived : Base
    {
        // GeeNote: Calling as a static.
        //internal static void ExecuteDerived()
        //{
        //    new Derived().Execute();
        //}

        // GeeNote: Calling as an instance.
        internal void ExecuteDerived()
        {
            Execute();
        }

        // GeeNote: NEW keyword hides member from base.
        //public new void Execute()
        protected override void Execute()
        {
            Log("Before execting base.");
            base.Execute();
            Log("After executing base.");
        }

        private void Log(string message)
        {
            Console.WriteLine(message); ;
        }
    }
}
