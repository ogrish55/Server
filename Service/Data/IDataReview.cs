using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    interface IDataReview
    {
        IEnumerable<ServiceReview> GetAllReviewsByProductId(int productId);
        int InsertReview(ServiceReview review);

    }
}
