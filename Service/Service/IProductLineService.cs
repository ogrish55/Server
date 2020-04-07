using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    [ServiceContract]
    public interface IProductLineService
    {
        [OperationContract]
        void DeleteProductLine(int productLineId);

        [OperationContract]
        void InsertProductLine(ServiceProductLine serviceProductLine);

        [OperationContract]
        void UpdateProductLine(ServiceProductLine serviceProductLine);

    }
}
