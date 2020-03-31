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

        internal void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        internal void InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }

        internal void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
