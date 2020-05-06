using Service.Data;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Control
{
    public class CustomerOrderControl
    {
        DataCustomerOrder dataCustomerOrder;
        public CustomerOrderControl()
        {
            dataCustomerOrder = new DataCustomerOrder();
        }

        public bool finishCheckout(ServiceCustomerOrder order)
        {
            return dataCustomerOrder.FinishCheckout(order);
        }

        public void DeleteOrder(int orderId)
        {
            dataCustomerOrder.DeleteOrder(orderId);
        }

        public int InsertOrder(ServiceCustomerOrder order)
        {
            return dataCustomerOrder.InsertOrder(order);
        }

        public void UpdateOrder(ServiceCustomerOrder order)
        {
            dataCustomerOrder.UpdateOrder(order);
        }

        public IEnumerable<ServiceCustomerOrder> GetActiveOrders()
        {
            return dataCustomerOrder.GetActiveOrders();
        }

        public IEnumerable<ServiceCustomerOrder> GetAllOrders()
        {
            return dataCustomerOrder.GetAllOrders();
        }

        public IEnumerable<ServiceCustomerOrder> GetCancelledOrders()
        {
            return dataCustomerOrder.GetCancelledOrders();
        }

        public ServiceCustomerOrder GetOrder(int customerOrderId)
        {
            return dataCustomerOrder.GetOrder(customerOrderId);
        }

        public IEnumerable<ServicePaymentMethod> GetPaymentMethods()
        {
            return dataCustomerOrder.GetPaymentMethods();
        }
    }
}
