using ManagementStore_DataAccess;
using ManagementStore_DataAccess.Product;
using ManagementStore_DataModel.Product;
using System.Collections.Generic;

namespace ManagementStore_DomainLogic.Product
{
    public class ProductService
    {
        private readonly IProductDao _productDao = DaoFactory.ProductDao;

        public List<ProductObject> GetProducts()
        {
            return _productDao.GetProducts();
        }

        public string DeleteProduct(string productId)
        {
            _productDao.DeleteProduct(productId);
            return "Produsul a fost sters";
        }
    }
}
