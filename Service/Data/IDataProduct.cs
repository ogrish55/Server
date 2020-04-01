using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    public interface IDataProduct
    {
        void InsertProduct(Product product);
        int DeleteProduct(int productId);
        int UpdateProduct(Product product);
        Product GetProductById(int productId);
    }
}
