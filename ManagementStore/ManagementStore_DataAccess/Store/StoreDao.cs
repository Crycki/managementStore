
using ManagementStore_DataAccess.Utils;
using ManagementStore_DataModel.Store;
using System.Collections.Generic;
using System.Data;

namespace ManagementStore_DataAccess.Store
{
    public interface IStoreDao
    {
        List<StoreObject> GetStores();
    }

    public class StoreDao : IStoreDao
    {
        private readonly SqlUtils SqlUtils = new SqlUtils();

        public List<StoreObject> GetStores()
        {
            var sql = "exec Store_GetStores";
            var dt = SqlUtils.FetchDataTable(sql);

            var stores = new List<StoreObject>();
            foreach (DataRow trow in dt.Rows)
            {
                stores.Add(FillStore(trow));
            }
            return stores;
        }

        private StoreObject FillStore(DataRow trow)
        {
            return new StoreObject
            {
                Id = trow["Id_Magazin"].ToString(),
                Name = trow["Nume_Magazin"].ToString()
            };
        }

    }
}
