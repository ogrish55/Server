using Service.Data;
using Service.Model;

namespace Service.Control
{
    public class ProductLineControl
    {
        DataProductLine dataProductLine;

        public ProductLineControl()
        {
            dataProductLine = new DataProductLine();
        }
        public void UpdateProductProductLine(ServiceProductLine serviceProductLine)
        {
            dataProductLine.UpdateProductLine(serviceProductLine);
        }

        public void InsertProductLine(ServiceProductLine serviceProductLine)
        {
            dataProductLine.InsertProductLine(serviceProductLine);
        }

        public void DeleteProductLine(int productLineId)
        {
            dataProductLine.DeleteProductLine(productLineId);
        }
    }
}
