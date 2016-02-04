using System.Runtime.Serialization;

namespace ManagementStore_DataModel.Product
{
    [DataContract]
    public class CurrencyProduct : BaseModel
    {
        [DataMember]
        public string Name { get; set; }
    }
}