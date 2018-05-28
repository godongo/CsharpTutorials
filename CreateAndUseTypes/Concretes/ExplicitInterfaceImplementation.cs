using CreateAndUseTypes.Abstracts;

namespace CreateAndUseTypes.Concretes
{
    class ExplicitInterfaceImplementation : IInterfaceA
    {
        // You can create an explicit interface implementation by adding the 
        // interface name and a period to the implementation.       
        void IInterfaceA.MyMethod()
        {
            throw new System.NotImplementedException();
        }
    }
}
