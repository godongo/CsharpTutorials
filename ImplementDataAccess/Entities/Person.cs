using System;

namespace ImplementDataAccess.Entities
{
    // Used for xml and binary serialization.
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }


    // The following are the important attributes that you will use most of the time.
    // For configuring xml serialization.
    /*
     * XmlIgnore
     * XmlAttribute
     * XmlElement
     * XmlArray
     * XmlArrayItem
     */
}
