using Service.Model;
using System.ServiceModel;


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
        [OperationContract]
        ServiceCustomer GetCustomer(int id);
    }
}
