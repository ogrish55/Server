using Service.Model;
using System.Configuration;
using System.Data.SqlClient;

namespace Service.Data
{
    public class DataDiscount : IDataDiscount
    {
        private string _connectionString;
        public DataDiscount()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["WebshopDatabase"].ConnectionString;
        }

        public int DeleteDiscount(string discountCode)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdDeleteDiscount = connection.CreateCommand())
                {
                    cmdDeleteDiscount.CommandText = "DELETE FROM Discount WHERE discountCode = @discountCode";
                    cmdDeleteDiscount.Parameters.AddWithValue("discountCode", discountCode);
                    rowsAffected = cmdDeleteDiscount.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        //  If no discount with the given code exists, this method will return 0
        public int GetDiscountByCode(string code)
        {
            int discount = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdGetDiscountByCode = connection.CreateCommand())
                {
                    cmdGetDiscountByCode.CommandText = "SELECT discountAmount FROM Discount WHERE discountCode = @code";
                    cmdGetDiscountByCode.Parameters.AddWithValue("code", code);
                    SqlDataReader discountReader = cmdGetDiscountByCode.ExecuteReader();

                    discount = discountReader.GetInt32(discountReader.GetOrdinal("discountAmount"));
                }
            }
            return discount;
        }

        public void InsertDiscount(ServiceDiscount discount)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdInsertDiscount = connection.CreateCommand())
                {
                    cmdInsertDiscount.CommandText = "INSERT INTO Discount (discountCode, discountAmount) VALUES (@discountCode, @discountAmount)";
                    cmdInsertDiscount.Parameters.AddWithValue("name", discount.DiscountCode);
                    cmdInsertDiscount.Parameters.AddWithValue("price", discount.DiscountAmount);

                    cmdInsertDiscount.ExecuteNonQuery();
                }
            }
        }
    }
}
