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
    }

    public class UserDao : IUserDao
    {
        private readonly SqlUtils SqlUtils = new SqlUtils();
        public User GetUser(string userName)
        {
            string sql = " SELECT * " +
                         " FROM UTILIZATORI " +
                         " WHERE Email_Utilizator = " + "\'" + userName + "\'";

            var trow = SqlUtils.FetchDataRow(sql);

            return trow == null ? null : FillUser(trow, true);
        }

        public User GetUserFromSession(string sessionId)
        {
            var sql = "exec User_FetchFromSession "
                    + "@sessionId = " + "\'" + sessionId + "\'";

            var trow = SqlUtils.FetchDataRow(sql);

            return trow == null ? null : FillUser(trow, false);
        }

        internal User FillUser(DataRow trow, bool password)
        {
            var user = new User
            {
                UserName = trow["Nume_Utilizator"].ToString(),
                Email = trow["Email_Utilizator"].ToString(),
                Id = trow["Id_Utilizator"].ToString()
            };

            if (password)
            {
                user.Password = trow["Parola_Utilizator"].ToString();             
            }

            return user;
        }
    }
}
