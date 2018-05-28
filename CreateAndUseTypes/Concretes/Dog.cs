using CreateAndUseTypes.Abstracts;

namespace CreateAndUseTypes.Concretes
{
    class Dog : IAnimal
    {
        // Interface implementation
        public void Move()
        {
            throw new System.NotImplementedException();
        }

        // Dog specific implementation
        public void Bark()
        {
            throw new System.NotImplementedException();
        }
    }
}
