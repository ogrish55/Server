using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    public interface IDataProductLine
    {
        int UpdateProductLine(ServiceProductLine serviceProductLine);
        void InsertProductLine(ServiceProductLine serviceProductLine);
        int DeleteProductLine(int productLineId);
    }
}
