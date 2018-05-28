using System;

namespace CreateAndUseTypes.Concretes
{
    class Base 
    {
        // This method can be overriden by deriving types.
        protected virtual void Execute()
        {
            Console.WriteLine("Executing..........................base!");
        }
    }
}
