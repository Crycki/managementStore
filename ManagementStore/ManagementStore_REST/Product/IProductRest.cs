using ManagementStore_DataModel.Product;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ManagementStore_REST.Product
{
    [ServiceContract]
    public interface IProductRest
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Products", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<ProductObject> GetProducts();
    }
}
