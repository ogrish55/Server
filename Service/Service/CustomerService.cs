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


        public int InsertCustomer(ServiceCustomer customer)
        {
          return customerControl.InsertCustomer(customer);
        }

        public void UpdateCustomer(ServiceCustomer customer)
        {
            customerControl.UpdateCustomer(customer);
        }

        public bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
           return customerControl.VerifyPassword(enteredPassword, storedHash, storedSalt);
        }
    }
}
