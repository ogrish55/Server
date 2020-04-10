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
                    cmdGetActiveOrders.CommandText = "SELECT orderId, finalPrice, status, dateOrder, customerId, discountId, paymentMethodId FROM CustomerOrder WHERE status = @active";
                    cmdGetActiveOrders.Parameters.AddWithValue("@active", "active");
                    SqlDataReader activeOrdersReader = cmdGetActiveOrders.ExecuteReader();

                    while (activeOrdersReader.Read())
                    {
                        ServiceCustomerOrder customerOrder = new ServiceCustomerOrder();
                        customerOrder.FinalPrice = activeOrdersReader.GetDecimal(activeOrdersReader.GetOrdinal("finalPrice"));
                        customerOrder.Status = activeOrdersReader.GetString(activeOrdersReader.GetOrdinal("status"));
                        customerOrder.DateOrder = activeOrdersReader.GetDateTime(activeOrdersReader.GetOrdinal("dateOrder"));
                        customerOrder.CustomerId = activeOrdersReader.GetInt32(activeOrdersReader.GetOrdinal("customerId"));
                        customerOrder.DiscountId = activeOrdersReader.GetInt32(activeOrdersReader.GetOrdinal("discountId"));
                        customerOrder.PaymentMethod = activeOrdersReader.GetInt32(activeOrdersReader.GetOrdinal("paymentMethodId"));
                        customerOrder.OrderId = activeOrdersReader.GetInt32(activeOrdersReader.GetOrdinal("orderId"));
                    }
                }
            }
            return customerOrders;
        }

        public IEnumerable<ServiceCustomerOrder> GetAllOrders()
        {
            List<ServiceCustomerOrder> customerOrders = new List<ServiceCustomerOrder>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdGetAllOrders = connection.CreateCommand())
                {
                    cmdGetAllOrders.CommandText = "SELECT orderId, finalPrice, status, dateOrder, customerId, discountId, paymentMethodId FROM CustomerOrder";
                    SqlDataReader allOrdersReader = cmdGetAllOrders.ExecuteReader();

                    while (allOrdersReader.Read())
                    {
                        ServiceCustomerOrder customerOrder = new ServiceCustomerOrder();
                        customerOrder.FinalPrice = allOrdersReader.GetDecimal(allOrdersReader.GetOrdinal("finalPrice"));
                        customerOrder.Status = allOrdersReader.GetString(allOrdersReader.GetOrdinal("status"));
                        customerOrder.DateOrder = allOrdersReader.GetDateTime(allOrdersReader.GetOrdinal("dateOrder"));
                        customerOrder.CustomerId = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("customerId"));
                        customerOrder.DiscountId = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("discountId"));
                        customerOrder.PaymentMethod = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("paymentMethodId"));
                        customerOrder.OrderId = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("orderId"));
                    }
                }
            }
            return customerOrders;
        }

        public IEnumerable<ServiceCustomerOrder> GetCancelledOrders()
        {
            List<ServiceCustomerOrder> customerOrders = new List<ServiceCustomerOrder>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdGetCancelledOrders = connection.CreateCommand())
                {
                    cmdGetCancelledOrders.CommandText = "SELECT orderId, finalPrice, status, dateOrder, customerId, discountId, paymentMethodId FROM CustomerOrder  WHERE status = @cancelled ";
                    cmdGetCancelledOrders.Parameters.AddWithValue("@cancelled", "cancelled");
                    SqlDataReader allOrdersReader = cmdGetCancelledOrders.ExecuteReader();

                    while (allOrdersReader.Read())
                    {
                        ServiceCustomerOrder customerOrder = new ServiceCustomerOrder();
                        customerOrder.FinalPrice = allOrdersReader.GetDecimal(allOrdersReader.GetOrdinal("finalPrice"));
                        customerOrder.Status = allOrdersReader.GetString(allOrdersReader.GetOrdinal("status"));
                        customerOrder.DateOrder = allOrdersReader.GetDateTime(allOrdersReader.GetOrdinal("dateOrder"));
                        customerOrder.CustomerId = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("customerId"));
                        customerOrder.DiscountId = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("discountId"));
                        customerOrder.PaymentMethod = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("paymentMethodId"));
                        customerOrder.OrderId = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("orderId"));
                    }
                }
            }
            return customerOrders;
        }

        public ServiceCustomerOrder GetOrder(int customerOrderId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmdGetOrder = connection.CreateCommand())
                {
                    ServiceCustomerOrder customerOrder = null;
                    cmdGetOrder.CommandText = "SELECT finalPrice, status, dateOrder, customerId, discountId, paymentMethodId, orderId FROM CustomerOrder WHERE orderId = @orderId";
                    cmdGetOrder.Parameters.AddWithValue("orderId", customerOrderId);
                    SqlDataReader orderReader = cmdGetOrder.ExecuteReader();

                    while (orderReader.Read())
                    {
                        customerOrder = new ServiceCustomerOrder();
                        customerOrder.FinalPrice = orderReader.GetDecimal(orderReader.GetOrdinal("finalPrice"));
                        customerOrder.Status = orderReader.GetString(orderReader.GetOrdinal("status"));
                        customerOrder.DateOrder = orderReader.GetDateTime(orderReader.GetOrdinal("dateOrder"));
                        customerOrder.CustomerId = orderReader.GetInt32(orderReader.GetOrdinal("customerId"));
                        customerOrder.DiscountId = orderReader.GetInt32(orderReader.GetOrdinal("discountId"));
                        customerOrder.PaymentMethod = orderReader.GetInt32(orderReader.GetOrdinal("paymentMethhodId"));
                        customerOrder.OrderId = orderReader.GetInt32(orderReader.GetOrdinal("orderId"));
                    }
                    return customerOrder;
                }
            }
        }

        public void InsertOrder(ServiceCustomerOrder order)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdInsertOrder = connection.CreateCommand())
                {
                    cmdInsertOrder.CommandText = "INSERT INTO CustomerOrder (finalPrice, status, dateOrder, customerId, discountId, paymentMethodId) VALUES (@finalPrice, @status, @dateOrder, @customerId, @discountId, @paymentMethodId)";
                    cmdInsertOrder.Parameters.AddWithValue("finalPrice", order.FinalPrice);
                    cmdInsertOrder.Parameters.AddWithValue("status", order.Status);
                    cmdInsertOrder.Parameters.AddWithValue("dateOrder", order.DateOrder);
                    cmdInsertOrder.Parameters.AddWithValue("customerId", order.CustomerId);
                    cmdInsertOrder.Parameters.AddWithValue("discountId", order.DiscountId);
                    cmdInsertOrder.Parameters.AddWithValue("paymentMethodId", order.PaymentMethod);

                    cmdInsertOrder.ExecuteNonQuery();
                }
            }
        }

        public int UpdateOrder(ServiceCustomerOrder order)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdUpdateOrder = connection.CreateCommand())
                {
                    cmdUpdateOrder.CommandText = "UPDATE CustomerOrder SET finalPrice = @finalPrice, status = @status, dateOrder = @dateOrder, customerId = @customerId, discountId = @discountId, paymentMethodId = @paymentMethod WHERE orderId = @orderId";
                    cmdUpdateOrder.Parameters.AddWithValue("finalPrice", order.FinalPrice);
                    cmdUpdateOrder.Parameters.AddWithValue("status", order.Status);
                    cmdUpdateOrder.Parameters.AddWithValue("dateOrder", order.DateOrder);
                    cmdUpdateOrder.Parameters.AddWithValue("customerId", order.CustomerId);
                    cmdUpdateOrder.Parameters.AddWithValue("discountId", order.DiscountId);
                    cmdUpdateOrder.Parameters.AddWithValue("paymentMethod", order.PaymentMethod);
                    rowsAffected = cmdUpdateOrder.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
    }
}
