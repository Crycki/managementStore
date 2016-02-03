
using ManagementStore_DataModel.Store;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ManagementStore_REST.Store
{
    [ServiceContract]
    public interface IStoreRest
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Stores", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<StoreObject> GetStores();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Store", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string SaveStore(StoreObject store);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Store/{storeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string UpdateStore(string storeId, StoreObject store);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Store/{storeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string DeleteStore(string storeId);
    }
}
