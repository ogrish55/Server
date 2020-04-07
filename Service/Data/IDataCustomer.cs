using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    public interface IDataCustomer
    {
        void InsertCustomer(ServiceCustomer customer);
        int DeleteCustomer(int customerId);
        int UpdateCustomer(ServiceCustomer customer);
    }
}
