using Service.Model;

namespace Service.Data
{
    public interface IDataDiscount
    {
        void InsertDiscount(ServiceDiscount discount);
        int DeleteDiscount(string code);
        decimal GetDiscountByCode(string code);
    }
}