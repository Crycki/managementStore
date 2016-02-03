
using ManagementStore_DataAccess.Utils;
using ManagementStore_DataModel.Store;
using System;
using System.Collections.Generic;
using System.Data;

namespace ManagementStore_DataAccess.Store
{
    public interface IStoreDao
    {
        List<StoreObject> GetStores();
        void SaveStore(StoreObject store);
        void DeleteStore(string storeId);
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

        public void SaveStore(StoreObject store)
        {
            var sql = "exec Store_SaveStore " + ((String.IsNullOrEmpty(store.Id)) ? "NULL" : store.Id) + " , '" + store.Name + "'";
            SqlUtils.ExecuteDml(sql, 5);
        }

        public void DeleteStore(string storeId)
        {
            var sql = "exec Store_DeleteStore " + storeId;
            SqlUtils.ExecuteDml(sql, 5);
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
