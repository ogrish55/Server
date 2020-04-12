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

        public int DeleteDiscount(int discountId)
        {
            return dataDiscount.DeleteDiscount(discountId);
        }

        public int GetDiscountByCode(string code)
        {
            return dataDiscount.GetDiscountByCode(code);
        }

    }
    
}
