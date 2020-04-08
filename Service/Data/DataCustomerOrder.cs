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
    public class DataCustomerOrder : IDataCustomerOrder
    {
        private string _connectionString;
        public DataCustomerOrder()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["WebshopDatabase"].ConnectionString;
        }
        public int DeleteOrder(int orderId)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdDeleteCustomerOrder = connection.CreateCommand())
                {
                    cmdDeleteCustomerOrder.CommandText = "DELETE FROM CustomerOrder WHERE orderId = @orderId";
                    cmdDeleteCustomerOrder.Parameters.AddWithValue("orderId", orderId);

                    rowsAffected = cmdDeleteCustomerOrder.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public IEnumerable<ServiceCustomerOrder> GetActiveOrders()
        {
            List<ServiceCustomerOrder> customerOrders = new List<ServiceCustomerOrder>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdGetActiveOrders = connection.CreateCommand())
                {
                    cmdGetActiveOrders.CommandText = "SELECT orderId, finalPrice, status, dateOrder, customerId, discountId, paymentMethod FROM CustomerOrder WHERE status = @Active";
                    SqlDataReader activeOrdersReader = cmdGetActiveOrders.ExecuteReader();

                    while (activeOrdersReader.Read())
                    {
                        ServiceCustomerOrder customerOrder = new ServiceCustomerOrder();


                        //product.Name = productsReader.GetString(productsReader.GetOrdinal("name"));
                        //product.Description = productsReader.GetString(productsReader.GetOrdinal("description"));
                        //product.Price = productsReader.GetDecimal(productsReader.GetOrdinal("price"));
                        //product.ProductId = productsReader.GetInt32(productsReader.GetOrdinal("productId"));

                        //products.Add(product);
                    }
                }
            }
            return null;
        }

        public IEnumerable<ServiceCustomerOrder> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceCustomerOrder> GetCancelledOrders()
        {
            throw new NotImplementedException();
        }

        public ServiceCustomerOrder GetOrder(int customerOrderId)
        {
            throw new NotImplementedException();
        }

        public void InsertOrder(ServiceCustomerOrder order)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(ServiceCustomerOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
