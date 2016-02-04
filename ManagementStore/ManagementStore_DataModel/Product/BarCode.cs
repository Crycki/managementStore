using System.Runtime.Serialization;

namespace ManagementStore_DataModel.Product
{
    [DataContract]
    public class BarCode : BaseModel
    {
        [DataMember]
        public int NumberCode { get; set; }
    }
}