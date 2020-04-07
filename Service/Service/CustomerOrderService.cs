using Service.Control;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomerOrderService : ICustomerOrderService
    {
        CustomerOrderControl customerOrderControl;

        public CustomerOrderService()
        {
            customerOrderControl = new CustomerOrderControl();
        }
        public void DeleteOrder(int orderId)
        {
            customerOrderControl.DeleteOrder(orderId);
        }

        public void InsertOrder(ServiceCustomerOrder order)
        {
            customerOrderControl.InsertOrder(order);
        }

        public void UpdateOrder(ServiceCustomerOrder order)
        {
            customerOrderControl.UpdateOrder(order);
        }
    }
}
