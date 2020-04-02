using Service.Data;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Control
{
    public class ProductControl
    {
        IDataProduct dataProduct;
        public ProductControl()
        {
            dataProduct = new DataProduct();
        }

        public void DeleteProduct(int productId)
        {
            dataProduct.DeleteProduct(productId);
        }

        public void InsertProduct(ServiceProduct product)
        {
            dataProduct.InsertProduct(product);
        }

        public void UpdateProduct(ServiceProduct product)
        {
            dataProduct.UpdateProduct(product);
        }

        public ServiceProduct GetProductById(int productId)
        {
            ServiceProduct product = dataProduct.GetProductById(productId);
            return product;
        }

        public IEnumerable<ServiceProduct> GetAllProducts()
        {
            IEnumerable<ServiceProduct> products = dataProduct.GetAllProducts();
            return products;
        }
    }
}
