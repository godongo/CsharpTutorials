using System.Runtime.Serialization;

namespace ImplementDataAccess.Entities
{
    [DataContract]
    public class PersonJson
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
