using ManagementStore_DataAccess.Utils;
using ManagementStore_DataModel.Security;
using System;
using System.Data;

namespace ManagementStore_DataAccess.Security
{
    public interface ISessionDao
    {
        Session CreateSession(string userId);
        void DestroySession(string sessionId);
        void IncreaseLoginFailure(string username);
        void ClearLoginFailure(string username);
        bool IsSessionOk(string sessionId);
    }

    public class SessionDao : ISessionDao
    {
        private readonly SqlUtils SqlUtils = new SqlUtils();

        public Session CreateSession(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("userId is empty");
            }

            var sql = " INSERT INTO GOT_SESSION(" +
                      "      GOT_SESSION_GUID " +
                      "     ,GOT_SESSION_DATE_STARTED " +
                      "     ,GOT_SESSION_DATE_ENDED " +
                      "     ,GOT_SESSION_DATE_REFRESHED " +
                      "     ,GOT_USER_ID " +
                      "     ) " +
                      " VALUES " +
                      "     (  " +
                      "      NEWID() " +
                      "     ,GETDATE() " +
                      "     ,NULL " +
                      "     ,GETDATE() " +
                      ",  " + userId;
            sql += " ) " +
                   "SELECT * FROM GOT_SESSION WHERE GOT_SESSION_ID = SCOPE_IDENTITY() ";

            var trow = SqlUtils.FetchDataRow(sql);

            return FillSession(trow);
        }

        public void DestroySession(string sessionId)
        {
            var sql = " UPDATE GOT_SESSION " +
                      " SET GOT_SESSION_DATE_ENDED = GETDATE() " + Environment.NewLine +
                      " WHERE GOT_SESSION_GUID = " + "\"" + sessionId + "\"" + Environment.NewLine;

            SqlUtils.ExecuteDml(sql, 5);
        }

        public void IncreaseLoginFailure(string username)
        {
            var sql = " UPDATE GOT_USER " +
                      " SET GOT_USER_FAILED_LOGINATTEMPTS = isnull(GOT_USER_FAILED_LOGINATTEMPTS,0) + 1 " +
                      " WHERE GOT_USER_USERNAME = " + "\"" + username + "\"";

            SqlUtils.ExecuteDml(sql, 3);
        }

        public void ClearLoginFailure(string username)
        {
            var sql = " UPDATE GOT_USER " +
                      " SET GOT_USER_FAILED_LOGINATTEMPTS = 0  " +
                      " WHERE GOT_USER_USERNAME = " + "\"" + username + "\"";

            SqlUtils.ExecuteDml(sql, 3);
        }

        public bool IsSessionOk(string sessionId)
        {
            var sql = " declare @gotSessionId as INT" +
                      " SELECT @gotSessionId = GOT_SESSION_ID " + Environment.NewLine +
                      " FROM GOT_SESSION " + Environment.NewLine + " WHERE ";

            sql += " GOT_SESSION_DATE_REFRESHED > GETDATE() - 0.07 " + Environment.NewLine + " AND ";

            sql += " GOT_SESSION_GUID = " + "\"" + sessionId + "\"" +
                   "   AND GOT_SESSION_DATE_ENDED IS NULL " + Environment.NewLine +
                   " IF @gotSessionId IS NOT NULL " + Environment.NewLine +
                   " BEGIN " + Environment.NewLine +
                   "    UPDATE GOT_SESSION SET GOT_SESSION_DATE_REFRESHED = GETDATE() " + Environment.NewLine +
                   "    WHERE  GOT_SESSION_ID = @gotSessionId " + Environment.NewLine +
                   " END " + Environment.NewLine +
                   " ELSE " + Environment.NewLine +
                   " BEGIN " + Environment.NewLine +
                   "    UPDATE GOT_SESSION SET GOT_SESSION_DATE_ENDED = GETDATE() " + Environment.NewLine +
                   "    WHERE  GOT_SESSION_GUID = " + "\"" + sessionId + "\"" + Environment.NewLine +
                   " END " + Environment.NewLine +
                   " SELECT @gotSessionId AS THESESSION ";

            var trow = SqlUtils.FetchDataRow(sql);

            if (trow == null)
            {
                return false;
            }

            return !string.IsNullOrEmpty(trow["THESESSION"].ToString());
        }

        public Session FillSession(DataRow trow)
        {
            var session = new Session
            {
                Id = trow["GOT_SESSION_ID"].ToString(),
                SessionId = trow["GOT_SESSION_GUID"].ToString(),
                IsoDateStarted = PerfectDate(trow["GOT_SESSION_DATE_STARTED"].ToString()),
                IsoDateEnded = PerfectDate(trow["GOT_SESSION_DATE_ENDED"].ToString()),
                IsoDateRefreshed = PerfectDate(trow["GOT_SESSION_DATE_REFRESHED"].ToString())
            };

            return session;
        }

        private static string PerfectDate(string date)
        {
            DateTime lDate;
            if (DateTime.TryParse(date, out lDate))
            {
                return lDate.ToString("yyyy-MM-dd HH:mm");
            }

            return "";
        }
    }
}
