using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAndUseTypes.Concretes
{
    /* 
     * CompareTo method returns the following (In-terms of sorting).
     * 1. Less than zero        Current instance comes first.
     * 2. Zero                  They are both in the same position.
     * 3. Greater than zero     Current instance comse after.
     */
    class OrderIComparable : IComparable
    {
        internal DateTime Created { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            OrderIComparable o = obj as OrderIComparable;

            if (o == null)
            {
                throw new ArgumentException("Object is not an Order");
            }

            // Compare current instance to object pass
            return this.Created.CompareTo(o.Created);
        }
    }
}
