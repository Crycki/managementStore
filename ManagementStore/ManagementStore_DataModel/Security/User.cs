using System.Runtime.Serialization;

namespace ManagementStore_DataModel.Security
{
    [DataContract]
    public class User : BaseModel
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public bool Active { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public int LoginAttempts { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}
    }
}
