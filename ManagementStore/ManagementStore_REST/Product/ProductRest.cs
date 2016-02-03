
using ManagementStore_DataModel.Product;
using ManagementStore_DomainLogic.Product;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;

namespace ManagementStore_REST.Product
{
    public class ProductRest : AbstractService, IProductRest
    {
        private readonly ProductService _productService = new ProductService();

        public List<ProductObject> GetProducts()
        {
            try
            {
                return _productService.GetProducts();
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
