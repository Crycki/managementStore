using System.Runtime.Serialization;

namespace ManagementStore_DataModel.Product
{
    [DataContract]
    public class Producer : BaseModel
    {
        [DataMember]
        public string Name { get; set; }

    }
}