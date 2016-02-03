using ManagementStore_DataAccess;
using ManagementStore_DataAccess.Store;
using ManagementStore_DataModel.Store;
using System.Collections.Generic;

namespace ManagementStore_DomainLogic.Store
{

    public class StoreService
    {
        private readonly IStoreDao _storeDao = DaoFactory.StoreDao;

        public List<StoreObject> GetStores()
        {
            return _storeDao.GetStores();

        }

    }
}
