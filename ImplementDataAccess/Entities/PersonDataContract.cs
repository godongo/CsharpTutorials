using System.Runtime.Serialization;

namespace ImplementDataAccess.Entities
{
    [DataContract]
    public class PersonDataContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        private bool isDirty = false;
    }
}
