using System;

namespace CSharpVersions.Entities
{
    public class Customer
    {
        public Guid customerID { get; set; } = Guid.NewGuid();
    }
}
