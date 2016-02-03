using ManagementStore_DataAccess.Utils;
using ManagementStore_DataModel.Product;
using System.Collections.Generic;
using System.Data;

namespace ManagementStore_DataAccess.Product
{
    public interface IProductDao
    {
        List<ProductObject> GetProducts();
    }

    public class ProductDao : IProductDao
    {
        private readonly SqlUtils SqlUtils = new SqlUtils();

        public List<ProductObject> GetProducts()
        {
            var sql = "exec Product_GetProducts";
            var dt = SqlUtils.FetchDataTable(sql);

            var products = new List<ProductObject>();
            foreach (DataRow trow in dt.Rows)
            {
                products.Add(FillProduct(trow));
            }
            return products;
        }


        private ProductObject FillProduct(DataRow trow)
        {
            return new ProductObject
            {
                Id = trow["Id_Produs"].ToString(),
                Name = trow["Nume_Produs"].ToString()
            };
        }
    }
}
