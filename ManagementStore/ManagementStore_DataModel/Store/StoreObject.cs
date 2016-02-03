using System;
using System.Runtime.Serialization;

namespace ManagementStore_DataModel.Store
{
    [DataContract]
    public class StoreObject : BaseModel
    {
        [DataMember]
        public string Name { get; set; }
    }
}
