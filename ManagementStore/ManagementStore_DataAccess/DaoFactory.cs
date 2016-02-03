
using ManagementStore_DataAccess.Security;
using ManagementStore_DataAccess.Store;

namespace ManagementStore_DataAccess
{
    public static class DaoFactory
    {
        private static IUserDao _userDao;
        public static IUserDao UserDao
        {
            get { return _userDao ?? (_userDao = new UserDao()); }
            set { _userDao = value; }
        }


        private static IStoreDao _storeDao;
        public static IStoreDao StoreDao
        {
            get { return _storeDao ?? (_storeDao = new StoreDao()); }
            set { _storeDao = value; }
        }
    }
}
