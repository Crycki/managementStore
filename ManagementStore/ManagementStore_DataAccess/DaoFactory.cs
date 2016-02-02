
using ManagementStore_DataAccess.Security;

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

    }
}
