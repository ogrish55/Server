using Service.Control;
using Service.Model;
using System.Collections.Generic;


namespace Service
{
    public class CustomerOrderService : ICustomerOrderService
    {
        CustomerOrderControl customerOrderControl;
        DeliveryDescriptionControl deliveryDescriptionControl;
        DiscountControl discountControl;

        public CustomerOrderService()
        {
            customerOrderControl = new CustomerOrderControl();
            deliveryDescriptionControl = new DeliveryDescriptionControl();
            discountControl = new DiscountControl();
        }

        public void DeleteDeliveryDescription(int deliveryId)
        {
            deliveryDescriptionControl.DeleteDeliveryDescription(deliveryId);
        }

        public int DeleteDiscount(string discountCode)
        {
            return discountControl.DeleteDiscount(discountCode);
        }

        public void DeleteOrder(int orderId)
        {
            customerOrderControl.DeleteOrder(orderId);
        }

        public IEnumerable<ServiceCustomerOrder> GetActiveOrders()
        {
            return customerOrderControl.GetActiveOrders();
        }

        public IEnumerable<ServiceCustomerOrder> GetAllOrders()
        {
            return customerOrderControl.GetAllOrders();
        }

        public IEnumerable<ServiceCustomerOrder> GetCancelledOrders()
        {
            return customerOrderControl.GetCancelledOrders();
        }

        public ServiceDeliveryDescription GetDeliveryDescriptionById(int deliveryId)
        {
            return deliveryDescriptionControl.GetDeliveryDescriptionById(deliveryId);
        }

        public decimal GetDiscountByCode(string code)
        {
            return discountControl.GetDiscountByCode(code);
        }

        public ServiceCustomerOrder GetOrder(int customerOrderId)
        {
            return customerOrderControl.GetOrder(customerOrderId);
        }

        public IEnumerable<ServicePaymentMethod> GetPaymentMethods()
        {
            return customerOrderControl.GetPaymentMethods();
        }

        public void InsertDeliveryDescription(ServiceDeliveryDescription deliveryDescription)
        {
            deliveryDescriptionControl.InsertDeliveryDescription(deliveryDescription);
        }

        public void InsertDiscount(ServiceDiscount discount)
        {
            discountControl.InsertDiscount(discount);
        }

        public int InsertOrder(ServiceCustomerOrder order)
        {
            return customerOrderControl.InsertOrder(order);
        }

        public void UpdateDeliveryDescription(ServiceDeliveryDescription deliveryDescription)
        {
            deliveryDescriptionControl.UpdateDeliveryDescription(deliveryDescription);
        }

        public void UpdateOrder(ServiceCustomerOrder order)
        {
            customerOrderControl.UpdateOrder(order);
        }

        public bool FinishCheckout(ServiceCustomerOrder order)
        {
            return customerOrderControl.finishCheckout( order);
        }
    }
}
