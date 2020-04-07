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
        void DeleteOrder(int orderId);
        void InsertOrder(ServiceCustomerOrder order);
        void UpdateOrder(ServiceCustomerOrder order);

    }
}
