﻿using Service.Control;
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

        public ServiceCustomer GetCustomer(int id)
        {
            return customerControl.GetCustomer(id);
        }

        public int InsertCustomer(ServiceCustomer customer)
        {
            return customerControl.InsertCustomer(customer);
        }

        public void UpdateCustomer(ServiceCustomer customer)
        {
            customerControl.UpdateCustomer(customer);
        }

        public ServiceCustomer VerifyLogin(string enteredPassword, string email)
        {
            return customerControl.VerifyLogin(enteredPassword, email);
        }
    }
}
