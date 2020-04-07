using Service.Control;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomerService : ICustomerService
    {
        CustomerControl customerControl;
        public CustomerService()
        {
            customerControl = new CustomerControl();
        }

        public void DeleteCustomer(int customerId)
        {
            customerControl.DeleteCustomer(customerId);
        }

        public void InsertCustomer(ServiceCustomer customer)
        {
            customerControl.InsertCustomer(customer);
        }

        public void UpdateCustomer(ServiceCustomer customer)
        {
            customerControl.UpdateCustomer(customer);
        }
    }
}
