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
    public class DataProductLine : IDataProductLine
    {
        private string _connectionString;
        public DataProductLine()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["WebshopDatabase"].ConnectionString;
        }

        public int DeleteProductLine(int productLineId)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdDeleteProductLine = connection.CreateCommand())
                {
                    cmdDeleteProductLine.CommandText = "DELETE FROM ProductLine WHERE productLineId = @productLineId";
                    cmdDeleteProductLine.Parameters.AddWithValue("productLineId", productLineId);

                    rowsAffected = cmdDeleteProductLine.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public void InsertProductLine(ServiceProductLine productLine)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdInsertProductLine = connection.CreateCommand())
                {
                    cmdInsertProductLine.CommandText = "INSERT INTO ProductLine (amount, subTotal, orderId, productId) VALUES (@amount, @subTotal, @orderId, @productId)";
                    cmdInsertProductLine.Parameters.AddWithValue("amount", productLine.Amount);
                    cmdInsertProductLine.Parameters.AddWithValue("subTotal", productLine.SubTotal);
                    cmdInsertProductLine.Parameters.AddWithValue("orderId", productLine.OrderId);
                    cmdInsertProductLine.Parameters.AddWithValue("productId", productLine.ProductId);

                    cmdInsertProductLine.ExecuteNonQuery();
                }
            }
        }

        public int UpdateProductLine(ServiceProductLine productLine)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdUpdateProductLine = connection.CreateCommand())
                {
                    cmdUpdateProductLine.CommandText = "UPDATE ProductLine SET amount = @amount, subTotal = @subTotal WHERE productLineId = @productLineId";
                    cmdUpdateProductLine.Parameters.AddWithValue("amount", productLine.Amount);
                    cmdUpdateProductLine.Parameters.AddWithValue("subTotal", productLine.SubTotal);
                    cmdUpdateProductLine.Parameters.AddWithValue("productLineId", productLine.ProductLineId);
                    rowsAffected = cmdUpdateProductLine.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
    }
}
