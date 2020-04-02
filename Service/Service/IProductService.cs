﻿using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        void InsertProduct(ServiceProduct product);

        [OperationContract]
        void DeleteProduct(int productId);

        [OperationContract]
        void UpdateProduct(ServiceProduct product);

        [OperationContract]
        ServiceProduct GetProductById(int productId);

        [OperationContract]
        IEnumerable<ServiceProduct> GetAllProducts();
    }
}
