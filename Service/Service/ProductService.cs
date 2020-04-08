using Service.Control;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        ProductControl productControl;
        public ProductService()
        {
            productControl = new ProductControl();
        }

        public void DeleteProduct(int productId)
        {
            productControl.DeleteProduct(productId);
        }

        public void InsertProduct(ServiceProduct product)
        {
            productControl.InsertProduct(product);
        }

        public void UpdateProduct(ServiceProduct product)
        {
            productControl.UpdateProduct(product);
        }

        public ServiceProduct GetProductById(int productId)
        {
            ServiceProduct product = productControl.GetProductById(productId);
            return product;
        }

        public IEnumerable<ServiceProductLine> GetAllProducts()
        {
            IEnumerable<ServiceProductLine> products = productControl.GetAllProducts();
            return products;
        }

    }
}
