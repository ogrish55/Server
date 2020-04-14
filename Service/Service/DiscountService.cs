using Service.Control;
using Service.Model;

namespace Service.Service
{
    class DiscountService : IDiscountService
    {
        DiscountControl discountControl;

        public DiscountService()
        {
            discountControl = new DiscountControl();
        }
        public int DeleteDiscount(int discountId)
        {
            return discountControl.DeleteDiscount(discountId);
        }

        public int GetDiscountByCode(string code)
        {
            return discountControl.GetDiscountByCode(code);
        }

        public void InsertDiscount(ServiceDiscount discount)
        {
            discountControl.InsertDiscount(discount);
        }
    }
}
