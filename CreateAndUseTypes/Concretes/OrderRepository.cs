using System.Collections.Generic;

namespace CreateAndUseTypes.Concretes
{
    class OrderRepository : Repository<Order>
    {
        public OrderRepository(IEnumerable<Order> orders)
                : base(orders) { }

        // This is an order specific implementation.
        public IEnumerable<Order> FilterOrdersOnAmount(decimal amount)
        {
            List<Order> result = null;

            // Some filtering code
            return result;
        }
    }
}
