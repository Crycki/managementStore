using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ManagementStore_DataAccess.Utils
{
    public class SqlUtils
    {
        private readonly SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["WebMenus"].ConnectionString);
        public DataRow FetchDataRow(string sql)
        {
            DataRow returnedValue;
            using (var conn = sqlConnection)
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = tran;
                        cmd.CommandText = sql;
                        cmd.CommandTimeout = 5;
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        returnedValue = dt.Rows[0];
                    }
                    tran.Commit();
                    conn.Close();
                }
            }
            return returnedValue;
        }

        public void ExecuteDml(string sql, int Timeout)
        {
            using (var conn = sqlConnection)
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = tran;
                        cmd.CommandText = sql;
                        cmd.CommandTimeout = Timeout;
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    conn.Close();
                }
            }
        }
    }
}
