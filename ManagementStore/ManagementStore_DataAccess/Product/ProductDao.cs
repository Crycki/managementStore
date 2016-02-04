using ManagementStore_DataAccess.Utils;
using ManagementStore_DataModel.Product;
using System;
using System.Collections.Generic;
using System.Data;

namespace ManagementStore_DataAccess.Product
{
    public interface IProductDao
    {
        List<ProductObject> GetProducts();
        void DeleteProduct(string productId);
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


        public void DeleteProduct(string productId)
        {
            var sql = "exec Product_DeleteProduct " + productId;

            SqlUtils.ExecuteDml(sql, 5);
        }

        private ProductObject FillProduct(DataRow trow)
        {
            return new ProductObject
            {
                Id = trow["Id_Produs"].ToString(),
                Name = trow["Nume_Produs"].ToString(),
                Amount = new Amount()
                {
                    Id = trow["Id_Cantitate"].ToString(),
                    Total = Convert.ToInt32(trow["Total_Cantitate"].ToString())
                },
                BarCode = new BarCode()
                {
                    Id = trow["Id_Cod"].ToString(),
                    NumberCode = Convert.ToInt32(trow["Numar_Cod"].ToString())
                },
                CurrencyProduct = new CurrencyProduct()
                {
                    Id = trow["Id_Moneda"].ToString(),
                    Name = trow["Nume_Moneda"].ToString()
                },
                Discount = new Discount()
                {
                    Id = trow["Id_Reducere"].ToString(),
                    Percent = Convert.ToInt32(trow["Procent_Reducere"].ToString())
                },
                ExpirationDate = new ExpirationDate()
                {
                    Id = trow["Data_Expirarii"].ToString(),
                    Date = DateTime.Parse(trow["Data_Expirarii"].ToString())
                },
                Price = new Price()
                {
                    Id = trow["Id_Pret"].ToString(),
                    CrudPrice = Convert.ToInt32(trow["Brut_Pret"].ToString())
                },
                Producer = new Producer()
                {
                    Id = trow["Id_Producator"].ToString(),
                    Name = trow["Nume_Producator"].ToString()
                },
                ProductType = new ProductType()
                {
                    Id = trow["Id_Tip"].ToString(),
                    Name = trow["Nume_Tip"].ToString()
                },
                TVA = new TVA()
                {
                    Id = trow["Id_TVA"].ToString(),
                    Percent = Convert.ToInt32(trow["Procent_TVA"].ToString())
                },
                Unit = new Unit()
                {
                    Id = trow["Id_Unitate"].ToString(),
                    Name = trow["Nume_Unitate"].ToString(),
                    Abbreviation = trow["Prescurtare_Unitate"].ToString()
                }
            };
        }
    }
}
