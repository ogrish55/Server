﻿using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface ICustomerOrderService
    {
        [OperationContract]
        void DeleteOrder(int orderId);

        [OperationContract]
        void InsertOrder(ServiceCustomerOrder order);

        [OperationContract]
        void UpdateOrder(ServiceCustomerOrder order);

        [OperationContract]
        IEnumerable<ServiceCustomerOrder> GetAllOrders();

        [OperationContract]
        IEnumerable<ServiceCustomerOrder> GetCancelledOrders();

        [OperationContract]
        IEnumerable<ServiceCustomerOrder> GetActiveOrders();

        [OperationContract]
        ServiceCustomerOrder GetOrder(int customerOrderId);

    }
}