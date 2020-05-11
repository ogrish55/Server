using Service.Data;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
