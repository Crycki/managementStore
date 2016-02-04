using System.Runtime.Serialization;

namespace ManagementStore_DataModel.Product
{
    [DataContract]
    public class ProductType : BaseModel
    {
        [DataMember]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}