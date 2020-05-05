using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Service
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        int InsertCustomer(ServiceCustomer customer);
        [OperationContract]
        void UpdateCustomer(ServiceCustomer customer);
        [OperationContract]
        void DeleteCustomer(int customerId);
        [OperationContract]
        ServiceCustomer VerifyLogin(string enteredPassword, string email);
    }
}
