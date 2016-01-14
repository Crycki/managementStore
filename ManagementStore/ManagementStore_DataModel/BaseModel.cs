using System.Runtime.Serialization;

namespace ManagementStore_DataModel
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public string Id { get; set; }
    }
}
