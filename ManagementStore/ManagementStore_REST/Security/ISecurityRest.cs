using ManagementStore_DataModel.Security;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ManagementStore_REST.Security
{
    [ServiceContract]
    public interface ISecurityRest
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Session", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Session Login(Credentials sessionCredential);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Session", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool LogOut();
    }
}
}
