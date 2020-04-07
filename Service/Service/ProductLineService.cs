using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Control;
using Service.Model;

namespace Service
{
    public class ProductLineService : IProductLineService
    {
        ProductLineControl productLineControl;
        public ProductLineService()
        {
            productLineControl = new ProductLineControl();
        }

        public void DeleteProductLine(int productLineId)
        {
            productLineControl.DeleteProductLine(productLineId);
        }

        public void InsertProductLine(ServiceProductLine serviceProductLine)
        {
            productLineControl.InsertProductLine(serviceProductLine);
        }

        public void UpdateProductLine(ServiceProductLine serviceProductLine)
        {
            productLineControl.UpdateProductProductLine(serviceProductLine);
        }
    }
}
