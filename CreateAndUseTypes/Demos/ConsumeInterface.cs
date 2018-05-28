using System;
using CreateAndUseTypes.Abstracts;
using CreateAndUseTypes.Concretes;

namespace CreateAndUseTypes.Demos
{
    class ConsumeInterface
    {
        private readonly ISample _sample;
        private readonly IInterfaceA _iInterfaceA;

        internal ConsumeInterface()
        {
            _sample = new Sample();
            _iInterfaceA = new ExplicitInterfaceImplementation();
        }

        internal static void Execute()
        {
            var result = new ConsumeInterface()._sample.MyDelegate(50);
            Console.WriteLine($"Result From Delegate: {result}");

            // Will not be able to access implemented methods
            //new ExplicitInterfaceImplementation().MyMethod();

            ExplicitInterfaceImplementation exp = new ExplicitInterfaceImplementation();
            // Will not be able to access implemented method.
            //exp.MyMethod() 

            ((IInterfaceA)exp).MyMethod();

            ((IInterfaceA)new ExplicitInterfaceImplementation()).MyMethod();

        }
    }
}
