using Service.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    public class DataDiscount : IDataDiscount
    {
        private string _connectionString;
        public DataDiscount()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["WebshopDatabase"].ConnectionString;
        }

        public int DeleteDiscount(int discountId)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdDeleteDiscount = connection.CreateCommand())
                {
                    cmdDeleteDiscount.CommandText = "DELETE FROM Discount WHERE disocuntId = @discountId";
                    cmdDeleteDiscount.Parameters.AddWithValue("productId", discountId);

                    rowsAffected = cmdDeleteDiscount.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

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
