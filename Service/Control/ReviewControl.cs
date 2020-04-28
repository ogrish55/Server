using Service.Data;
using Service.Model;
using System.Collections.Generic;

namespace Service.Control
{
    public class ReviewControl
    {
        IDataReview dataReview;

        public ReviewControl()
        {
            dataReview = new DataReview();
        }

        public IEnumerable<ServiceReview> GetAllReviewsByProductId(int productId)
        {
            return dataReview.GetAllReviewsByProductId(productId);
        }

        public int InsertReview(ServiceReview review)
        {
            return dataReview.InsertReview(review);
        }
    }
}