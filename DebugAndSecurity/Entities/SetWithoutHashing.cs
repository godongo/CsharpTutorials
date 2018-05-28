using System.Collections.Generic;

namespace DebugAndSecurity.Entities
{
    class SetWithoutHashing<T>
    {
        private List<T> list = new List<T>();

        // GeeNote: Added this for fun :-)
        public List<T> SetList
        {
            get
            {
                return list;
            }
        }

        /* 
         * For each item that you add, you have to loop through all existing items. 
         * This doesn’t scale well and leads to performance problems when you have a large 
         * amount of items. It would be nice if you somehow needed to check only a small 
         * subgroup instead of all the items.
         * */
        /*
         * This is where a hash code can be used. HASHING IS THE PROCESS OF 
         * TAKING A LARGE SET OF DATA AND MAPPING IT TO A SMALLER DATA SET OF FIXED LENGTH.        
         */
        public void Insert(T item)
        {
            if (!Contains(item))
                list.Add(item);
        }
        public bool Contains(T item)
        {
            foreach (T member in list)
                if (member.Equals(item))
                    return true;
            return false;
        }
    }
}
