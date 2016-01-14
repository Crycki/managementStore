using System.Runtime.Serialization;

namespace ManagementStore_DataModel.Security
{
    [DataContract]
    public class Session : BaseModel
    {
        [DataMember]
        public string SessionId { get; set; }

        public string IsoDateStarted { get; set; }

        public string IsoDateEnded { get; set; }

        public string IsoDateRefreshed { get; set; }

    }
}
