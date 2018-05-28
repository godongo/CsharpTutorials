using CreateAndUseTypes.Abstracts;
using CreateAndUseTypes.Entities;

namespace CreateAndUseTypes.Concretes
{
    class ProductRepository : IProductRepository<Product>
    {
        public System.Collections.Generic.IEnumerable<Product> All()
        {
            throw new System.NotImplementedException();
        }

        public Product FindById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
