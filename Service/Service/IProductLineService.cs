using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
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

        [OperationContract]
        void InsertProduct(ServiceProduct product);

        [OperationContract]
        void DeleteProduct(int productId);

        [OperationContract]
        void UpdateProduct(ServiceProduct product);

        [OperationContract]
        ServiceProduct GetProductById(int productId);

        [OperationContract]
        IEnumerable<ServiceProduct> GetAllProducts();

        [OperationContract]
        IEnumerable<ServiceReview> GetAllReviewsByProductId(int productId);

        [OperationContract]
        int InsertReview(ServiceReview review);
    }
}
