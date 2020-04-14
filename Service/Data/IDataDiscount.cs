using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    public interface IDataDiscount
    {
        void InsertDiscount(ServiceDiscount discount);
        int DeleteDiscount(int discountId);
        int GetDiscountByCode(string code);
    }
}
