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
    public interface ICustomerOrderService
    {
        [OperationContract]
        void DeleteOrder(int orderId);

        [OperationContract]
        int InsertOrder(ServiceCustomerOrder order);

        [OperationContract]
        void UpdateOrder(ServiceCustomerOrder order);

        [OperationContract]
        IEnumerable<ServiceCustomerOrder> GetAllOrders();

        [OperationContract]
        IEnumerable<ServiceCustomerOrder> GetCancelledOrders();

        [OperationContract]
        IEnumerable<ServiceCustomerOrder> GetActiveOrders();

        [OperationContract]
        ServiceCustomerOrder GetOrder(int customerOrderId);

        [OperationContract]
        void InsertDeliveryDescription(ServiceDeliveryDescription deliveryDescription);

        [OperationContract]
        ServiceDeliveryDescription GetDeliveryDescriptionById(int deliveryId);

        [OperationContract]
        void UpdateDeliveryDescription(ServiceDeliveryDescription deliveryDescription);

        [OperationContract]
        void DeleteDeliveryDescription(int deliveryId);

        [OperationContract]
        void InsertDiscount(ServiceDiscount discount);
        [OperationContract]
        int DeleteDiscount(string discountCode);
        [OperationContract]
        int GetDiscountByCode(string code);
        [OperationContract]
        IEnumerable<ServicePaymentMethod> GetPaymentMethods();

        [OperationContract]
        bool FinishCheckout(ServiceCustomer customer, ServiceCustomerOrder order);

    }
}
