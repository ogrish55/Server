using Service.Model;
using System.ServiceModel;

namespace Service.Service
{
    [ServiceContract]
    public interface IDiscountService
    {
        [OperationContract]
        void InsertDiscount(ServiceDiscount discount);
        [OperationContract]
        int DeleteDiscount(int discountId);
        [OperationContract]
        int GetDiscountByCode(string code);
    }
}
