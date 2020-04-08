using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    public interface IDataCustomerOrder
    {
        int DeleteOrder(int orderId);
        void InsertOrder(ServiceCustomerOrder order);
        void UpdateOrder(ServiceCustomerOrder order);
        IEnumerable<ServiceCustomerOrder> GetActiveOrders();
        IEnumerable<ServiceCustomerOrder> GetAllOrders();
        IEnumerable<ServiceCustomerOrder> GetCancelledOrders();
        ServiceCustomerOrder GetOrder(int customerOrderId);
    }
}
