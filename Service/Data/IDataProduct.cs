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
        void InsertProduct(ServiceProduct product);
        int DeleteProduct(int productId);
        int UpdateProduct(ServiceProduct product);
        ServiceProduct GetProductById(int productId);
        IEnumerable<ServiceProductLine> GetAllProducts();
    }
}
