using System.Collections.Generic;
using Service.Control;
using Service.Model;

namespace Service
{
    public class ProductLineService : IProductLineService
    {
        ProductLineControl productLineControl;
        ProductControl productControl;
        ReviewControl reviewControl;
        public ProductLineService()
        {
            productLineControl = new ProductLineControl();
            productControl = new ProductControl();
        }

        public IEnumerable<ServiceCategory> GetAllCategories() 
        {
            CategoryControl categoryControl = new CategoryControl();
            return categoryControl.GetAllCategories();
        }

        public IEnumerable<ServiceBrand> GetAllBrands()
        {
            BrandControl brandControl = new BrandControl();
            return brandControl.GetAllBrands();
        }

        public void DeleteProduct(int productId)
        {
            productControl.DeleteProduct(productId);
        }

        public void DeleteProductLine(int productLineId)
        {
            productLineControl.DeleteProductLine(productLineId);
        }

        public IEnumerable<ServiceProduct> GetAllProducts()
        {
            return productControl.GetAllProducts();
        }

        public IEnumerable<ServiceReview> GetAllReviewsByProductId(int productId)
        {
            return reviewControl.GetAllReviewsByProductId(productId);
        }

        public ServiceProduct GetProductById(int productId)
        {
            return productControl.GetProductById(productId);
        }

        public void InsertProduct(ServiceProduct product)
        {
            productControl.InsertProduct(product);
        }

        public void InsertProductLine(ServiceProductLine serviceProductLine)
        {
            productLineControl.InsertProductLine(serviceProductLine);
        }

        public int InsertReview(ServiceReview review)
        {
            return reviewControl.InsertReview(review);
        }

        public void UpdateProduct(ServiceProduct product)
        {
            productControl.UpdateProduct(product);
        }

        public void UpdateProductLine(ServiceProductLine serviceProductLine)
        {
            productLineControl.UpdateProductProductLine(serviceProductLine);
        }
    }
}
