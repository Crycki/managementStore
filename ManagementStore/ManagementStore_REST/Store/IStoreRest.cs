
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

    }
}
