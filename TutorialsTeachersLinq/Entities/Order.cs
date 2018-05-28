using System.Collections.Generic;

namespace TutorialsTeachersLinq.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public List<OrderLine> Orders { get; set; }
    }
}
