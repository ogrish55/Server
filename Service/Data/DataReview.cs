using Service.Model;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Service.Data
{
    public class DataReview : IDataReview
    {
        private string _connectionString;
        public DataReview()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["WebshopDatabase"].ConnectionString;
        }
        public IEnumerable<ServiceReview> GetAllReviewsByProductId(int productId)
        {
            List<ServiceReview> reviews = new List<ServiceReview>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdGetAllReviews = connection.CreateCommand())
                {
                    cmdGetAllReviews.CommandText = "SELECT reviewId, comment, rating FROM Review WHERE productId = @productId";
                    cmdGetAllReviews.Parameters.AddWithValue("productId", productId);
                    SqlDataReader reviewReader = cmdGetAllReviews.ExecuteReader();

                    while (reviewReader.Read())
                    {
                        ServiceReview review = new ServiceReview();
                        review.ReviewId = reviewReader.GetInt32(reviewReader.GetOrdinal("reviewId"));
                        review.Comment = reviewReader.GetString(reviewReader.GetOrdinal("comment"));
                        review.Rating = reviewReader.GetInt32(reviewReader.GetOrdinal("rating"));

                        reviews.Add(review);
                    }
                }
            }
            return reviews;
        }

        public int InsertReview(ServiceReview review)
        {
            //Test purposes
            int insertedReviewId = -1;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdInsertReview = connection.CreateCommand())
                {
                    cmdInsertReview.CommandText = "INSERT INTO Review (rating, comment) OUTPUT INSERTED.reviewId VALUES (@rating, @comment)";
                    cmdInsertReview.Parameters.AddWithValue("rating", review.Rating);
                    cmdInsertReview.Parameters.AddWithValue("comment", review.Comment);
                    insertedReviewId = (int)cmdInsertReview.ExecuteScalar();
                }
            }
            return insertedReviewId;
        }
    }
}