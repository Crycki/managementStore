using System.Runtime.Serialization;

namespace ManagementStore_DataModel.Product
{
    [DataContract]
    public class TVA : BaseModel
    {
        [DataMember]
        public int Percent { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}