using ManagementStore_DataAccess;
using ManagementStore_DataAccess.Security;
using ManagementStore_DataModel.Security;
using ManagementStore_DomainLogic.Utils;
using System.Security;

namespace ManagementStore_DomainLogic
{
    public class SecurityService
    {
        private readonly IUserDao _userDao = DaoFactory.UserDao;


        public User GetUser(string sessionid)
        {
            var user = (User)GetShortCache().GetValue("session", sessionid);
            if (user == null)
            {
                user = _userDao.GetUserFromSession(sessionid);
                GetShortCache().SetValue("session", sessionid, user);
            }
            return user;
        }

        public User Login(Credentials sessionCredential)
        {
            var existingUser = _userDao.GetUser(sessionCredential.UserName);

            if (existingUser == null)
            {
                throw new SecurityException("User doesn't exist!");
            }

            return existingUser;
        }

        private static FastCache _mcache;

        private readonly static object Obj = new object();

        protected FastCache GetShortCache()
        {
            lock ((Obj))
            {
                if (_mcache == null)
                {
                    _mcache = new FastCache(500);
                }
            }
            return _mcache;
        }
    }
}
