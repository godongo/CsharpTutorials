using System.Collections.Generic;
using System.Linq;
using CreateAndUseTypes.Abstracts;

namespace CreateAndUseTypes.Concretes
{
    class Repository<T>
        // T should implement IEntity
        where T : IEntity
    {
        protected IEnumerable<T> _elements;

        public Repository(IEnumerable<T> elements)
        {
            _elements = elements;
        }

        /* This base class offers a method for finding entities by ID. 
         * This code is generic and can be used by all entities. */
        public T FindById(int id)
        {
            return _elements.SingleOrDefault(e => e.Id == id);
        }

        // Custom implementations can be added by subtypes.
        // EXAMPLE LOOK AT THE ORDER CLASS.
    }
}
