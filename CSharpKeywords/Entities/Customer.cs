using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpKeywords.Entities
{
    class Customer
    {
        // Aggregated collection.
        private List<Address> Addresses = new List<Address>();

        public Customer()
        {
            Addresses.Add(new Address { Street = "43 Skye Crescent", City = "Miton Keynes", Postcode = "MK3 5AY", MobileNumber = 223445 });
            Addresses.Add(new Address { Street = "10 Downing Street", City = "London", Postcode = "SW1A 2AA", MobileNumber = 128990 });
            Addresses.Add(new Address { Street = "63 Skye Crescent", City = "London", Postcode = "UB5 2XD", MobileNumber = 451608 });
        }
        
        // Prevent callers from accessing this method.
        public Address GetAddress(int mobileNumber)
        {
            return Addresses.FirstOrDefault(mn => mn.MobileNumber == mobileNumber);
        }

        // Prevent callers from accessing this method.
        public Address GetAddress(string postcode)
        {
            return Addresses.FirstOrDefault(pc => pc.Postcode == postcode);
        }

        // Remember indexers are properties with setters and getters
        public Address this[int mobileNumber]
        {
            get
            {
                return Addresses.FirstOrDefault(mn => mn.MobileNumber == mobileNumber);
            }
        }

        public Address this[string postcode]
        {
            get
            {
                return Addresses.FirstOrDefault(pc => pc.Postcode == postcode);
            }
        }
    }
}
