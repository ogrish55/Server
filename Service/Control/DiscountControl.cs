using Service.Data;
using Service.Model;

namespace Service.Control
{
    public class DiscountControl
    {
        IDataDiscount dataDiscount;

        public DiscountControl()
        {
            dataDiscount = new DataDiscount();
        }

        public void InsertDiscount(ServiceDiscount discount)
        {
            dataDiscount.InsertDiscount(discount);
        }

        public int DeleteDiscount(string discountCode)
        {
            return dataDiscount.DeleteDiscount(discountCode);
        }

        public int GetDiscountByCode(string code)
        {
            return dataDiscount.GetDiscountByCode(code);
        }

    }
    
}
