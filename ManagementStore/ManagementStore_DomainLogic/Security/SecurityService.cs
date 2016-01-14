using ManagementStore_DataAccess;
using ManagementStore_DataAccess.Security;
using ManagementStore_DataModel.Security;
using ManagementStore_DomainLogic.Utils;
using System;
using System.Security;

namespace ManagementStore_DomainLogic
{
    public class SecurityService
    {
        private readonly ISessionDao _sessionDao = DaoFactory.SessionDao;
        private readonly IUserDao _userDao = DaoFactory.UserDao;

        public bool ValidateSession(string sessionid)
        {
            //Are we getting it from the minute cache?
            string rtn = (string)GetShortCache().GetValue("session_NOW" + DateTime.Now.ToString("yyyyMMddHHmm"), sessionid);
            if (rtn == null) rtn = string.Empty;

            //IF yes return true
            if (rtn == sessionid)
            {
                return true;
            }

            if (_sessionDao.IsSessionOk(sessionid))
            {
                //Store it in the cache.. lasting one minute..
                GetShortCache().SetValue("session_NOW" + DateTime.Now.ToString("yyyyMMddHHmm"), sessionid, sessionid);
                return true;
            }

            return false;

        }

        public User GetUser(string sessionid)
        {
            if (ValidateSession(sessionid))
            {
                var user = (User)GetShortCache().GetValue("session", sessionid);
                if (user == null)
                {
                    user = _userDao.GetUserFromSession(sessionid);
                    GetShortCache().SetValue("session", sessionid, user);
                }
                return user;
            }
            return null;
        }

        public Session Login(Credentials sessionCredential)
        {
            var existingUser = _userDao.GetUser(sessionCredential.UserName);

            if (existingUser == null)
            {
                throw new SecurityException("User doesn't exist!");
            }

            if (existingUser.LoginAttempts >= 5)
            {
                throw new SecurityException("Maximum login attempt reached!");
            }

            Session session;

            if (sessionCredential.Password == existingUser.Password)
            {
                _sessionDao.ClearLoginFailure(existingUser.UserName);
                session = _sessionDao.CreateSession(existingUser.Id);
            }
            else
            {
                _sessionDao.IncreaseLoginFailure(existingUser.UserName);
                throw new SecurityException("Incorrect password!");
            }

            return session;
        }

        public bool LogOut(string sessionId)
        {
            _sessionDao.DestroySession(sessionId);
            return true;
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
