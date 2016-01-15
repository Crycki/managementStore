using ManagementStore_DataAccess.Utils;
using ManagementStore_DataModel.Security;
using System;
using System.Data;

namespace ManagementStore_DataAccess.Security
{
    public interface IUserDao
    {
        User GetUser(string userName);
        User GetUserFromSession(string sesionId);
        User GetSmartAgentUser();
    }

    public class UserDao : IUserDao
    {
        private readonly SqlUtils SqlUtils = new SqlUtils();
        public User GetUser(string userName)
        {
            string sql = " SELECT * " +
                         " FROM GOT_USER " +
                         " WHERE GOT_USER_USERNAME = " + "\"" + userName + "\"";

            var trow = SqlUtils.FetchDataRow(sql);

            return trow == null ? null : FillUser(trow, true);
        }

        public User GetUserFromSession(string sessionId)
        {
            var sql = "exec User_FetchFromSession "
                    + "@sessionId = " + "\"" + sessionId + "\"";

            var trow = SqlUtils.FetchDataRow(sql);

            return trow == null ? null : FillUser(trow, false);
        }

        public User GetSmartAgentUser()
        {
            var sql = "exec User_GetSmartAgentUser";
            return FillUser(SqlUtils.FetchDataRow(sql), false);
        }

        internal User FillUser(DataRow trow, bool password)
        {
            var user = new User
            {
                FirstName = trow["GOT_USER_FIRSTNAME"].ToString(),
                LastName = trow["GOT_USER_LASTNAME"].ToString(),
                Active = Convert.ToBoolean(trow["GOT_USER_ACTIVE"].ToString()),
                UserName = trow["GOT_USER_USERNAME"].ToString(),
                Email = trow["GOT_USER_EMAIL"].ToString(),
                Id = trow["GOT_USER_ID"].ToString()
            };

            if (password)
            {
                user.Password = trow["GOT_USER_PASSWORD"].ToString();
                user.Salt = trow["GOT_USER_SALT"].ToString();
                user.LoginAttempts = int.Parse(trow["GOT_USER_FAILED_LOGINATTEMPTS"].ToString());
            }

            return user;
        }
    }
}
