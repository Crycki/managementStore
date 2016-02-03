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

        public string SaveStore(StoreObject store)
        {
            _storeDao.SaveStore(store);
            return "Magazinul a fost salvat";
        }

        public string DeleteStore(string storeId)
        {
            _storeDao.DeleteStore(storeId);
            return "Magazinul a fost sters";
        }
    }
}
