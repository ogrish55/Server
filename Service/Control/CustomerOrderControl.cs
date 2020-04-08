﻿using Service.Data;
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
        IDataCustomerOrder dataCustomerOrder;
        public CustomerOrderControl()
        {
            dataCustomerOrder = new DataCustomerOrder();
        }

        public void DeleteOrder(int orderId)
        {
            dataCustomerOrder.DeleteOrder(orderId);
        }

        public void InsertOrder(ServiceCustomerOrder order)
        {
            dataCustomerOrder.InsertOrder(order);
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
    }
}