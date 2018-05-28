using System.Collections.Generic;

namespace CreateAndUseTypes.Abstracts
{
    interface IGenericRepository<T>
    {
        T FindById(int id);

        IEnumerable<T> All();
    }
}
