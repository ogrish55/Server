using Service.Data;
using Service.Model;
using System.Collections.Generic;

namespace Service.Control
{
    public class BrandControl
    {
        DataBrand dataBrand;
        public BrandControl()
        {
            dataBrand = new DataBrand();
        }
        public IEnumerable<ServiceBrand> GetAllBrands()
        {
            return dataBrand.GetAllBrands();
        }
    }
}
