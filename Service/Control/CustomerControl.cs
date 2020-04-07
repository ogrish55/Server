using Service.Data;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Control
{
    public class CustomerControl
    {
        IDataCustomer dataCustomer;
        public CustomerControl()
        {
            dataCustomer = new DataCustomer();
        }
        public void DeleteCustomer(int customerId)
        {
            dataCustomer.DeleteCustomer(customerId);
        }

        public void InsertCustomer(ServiceCustomer customer)
        {
            dataCustomer.InsertCustomer(customer);
        }

        public void UpdateCustomer(ServiceCustomer customer)
        {
            dataCustomer.UpdateCustomer(customer);
        }
    }
}
