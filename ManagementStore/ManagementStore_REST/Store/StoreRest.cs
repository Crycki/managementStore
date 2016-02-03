using ManagementStore_DataModel.Store;
using ManagementStore_DomainLogic.Store;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;

namespace ManagementStore_REST.Store
{
    public class StoreRest : AbstractService, IStoreRest
    {
        private readonly StoreService _storeService = new StoreService();

        public List<StoreObject> GetStores()
        {
            try
            {
                return _storeService.GetStores();
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
