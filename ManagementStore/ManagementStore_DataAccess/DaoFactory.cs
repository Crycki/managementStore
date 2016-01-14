
using ManagementStore_DataAccess.Security;

namespace ManagementStore_DataAccess
{
    public static class DaoFactory
    {
        public static string DbConnectionString = null;

        private static ISessionDao _sessionDao;
        public static ISessionDao SessionDao
        {
            get { return _sessionDao ?? (_sessionDao = new SessionDao()); }
            set { _sessionDao = value; }
        }

        private static IUserDao _userDao;
        public static IUserDao UserDao
        {
            get { return _userDao ?? (_userDao = new UserDao()); }
            set { _userDao = value; }
        }

    }
