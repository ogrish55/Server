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

        public void InsertProduct(Product product)
        {
            dataProduct.InsertProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            dataProduct.UpdateProduct(product);
        }

        public Product GetProductById(int productId)
        {
            Product product = dataProduct.GetProductById(productId);
            return product;
        }
    }
}
