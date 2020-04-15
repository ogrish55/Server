using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Control;
using Service.Model;

namespace Service
{
    public class ProductLineService : IProductLineService
    {
        ProductLineControl productLineControl;
        ProductControl productControl;
        public ProductLineService()
        {
            productLineControl = new ProductLineControl();
            productControl = new ProductControl();
        }

        public void DeleteProduct(int productId)
        {
            productControl.DeleteProduct(productId);
        }

        public void DeleteProductLine(int productLineId)
        {
            productLineControl.DeleteProductLine(productLineId);
        }

        public IEnumerable<ServiceProduct> GetAllProducts()
        {
            return productControl.GetAllProducts();
        }

        public ServiceProduct GetProductById(int productId)
        {
            return productControl.GetProductById(productId);
        }

        public void InsertProduct(ServiceProduct product)
        {
            productControl.InsertProduct(product);
        }

        public void InsertProductLine(ServiceProductLine serviceProductLine)
        {
            productLineControl.InsertProductLine(serviceProductLine);
        }

        public void UpdateProduct(ServiceProduct product)
        {
            productControl.UpdateProduct(product);
        }

        public void UpdateProductLine(ServiceProductLine serviceProductLine)
        {
            productLineControl.UpdateProductProductLine(serviceProductLine);
        }
    }
}
