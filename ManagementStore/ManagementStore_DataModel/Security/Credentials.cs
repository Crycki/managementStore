using System.Runtime.Serialization;

namespace ManagementStore_DataModel.Security
{
  [DataContract]
    public class Credentials
    {
        [DataMember]
        public string UserName { get; set; }
        
        [DataMember]
        public string Password { get; set; }
    }
}
