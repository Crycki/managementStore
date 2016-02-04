using System.Runtime.Serialization;

namespace ManagementStore_DataModel.Product
{
    [DataContract]
    public class Discount : BaseModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Percent { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}