using CreateAndUseTypes.Abstracts;
using CreateAndUseTypes.Concretes;
using System;
using System.Collections.Generic;

namespace CreateAndUseTypes.Demos
{
    class Inheritance
    {
        internal static void InstantiateInterfaceConcreteType()
        {
            // We can only access members defined on the interface.
            IAnimal animal = new Dog();            
            animal.Move();

            // Cast to access both members of dog and interface.
            Dog dog = (Dog)animal;

            dog.Move();
            dog.Bark();            
        }

        internal static void CreatingBaseClasses()
        {
            IEnumerable<Order> orders = new List<Order>() { };

            // Using base
            Repository<Order> baseOrderRepo = new OrderRepository(orders);
            Order myOrder = baseOrderRepo.FindById(5);

            // Cast to use subType and access additional implementation.
            OrderRepository derivedOrderRepo = (OrderRepository)baseOrderRepo;
            IEnumerable<Order> filteredByAmount = derivedOrderRepo.FilterOrdersOnAmount(5m);

        }

        internal static void ChangingBehaviourUsingBaseAndDerivedTypes()
        {
            // GeeNote: Calling as an instance.
            //Derived.ExecuteDerived();

            // GeeNote: Calling as an instance.
            new Derived().ExecuteDerived();
        }       
    }
}
