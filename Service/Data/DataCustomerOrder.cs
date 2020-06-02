using Service.Model;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Transactions;

namespace Service.Data
{
    public class DataCustomerOrder
    {
        private string _connectionString;
        private DataCustomer dataCustomer;
        private DataProductLine dataProductLine;
        private DataProduct dataProduct;

        public DataCustomerOrder()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["WebshopDatabase"].ConnectionString;
            dataCustomer = new DataCustomer();
            dataProductLine = new DataProductLine();
            dataProduct = new DataProduct();
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
                    cmdGetActiveOrders.CommandText = "SELECT orderId, finalPrice, orderStatus, dateOrder, customerId, paymentMethodId FROM CustomerOrder WHERE orderStatus = @active";
                    cmdGetActiveOrders.Parameters.AddWithValue("@active", "active");
                    SqlDataReader activeOrdersReader = cmdGetActiveOrders.ExecuteReader();

                    while (activeOrdersReader.Read())
                    {
                        ServiceCustomerOrder customerOrder = new ServiceCustomerOrder();
                        customerOrder.FinalPrice = activeOrdersReader.GetDecimal(activeOrdersReader.GetOrdinal("finalPrice"));
                        customerOrder.Status = activeOrdersReader.GetString(activeOrdersReader.GetOrdinal("orderStatus"));
                        customerOrder.DateOrder = activeOrdersReader.GetDateTime(activeOrdersReader.GetOrdinal("dateOrder"));
                        customerOrder.CustomerId = activeOrdersReader.GetInt32(activeOrdersReader.GetOrdinal("customerId"));
                        customerOrder.PaymentMethod = activeOrdersReader.GetInt32(activeOrdersReader.GetOrdinal("paymentMethodId"));
                        customerOrder.OrderId = activeOrdersReader.GetInt32(activeOrdersReader.GetOrdinal("orderId"));
                        customerOrders.Add(customerOrder);
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
                    cmdGetAllOrders.CommandText = "SELECT orderId, finalPrice, orderStatus, dateOrder, customerId, paymentMethodId FROM CustomerOrder";
                    SqlDataReader allOrdersReader = cmdGetAllOrders.ExecuteReader();

                    while (allOrdersReader.Read())
                    {
                        ServiceCustomerOrder customerOrder = new ServiceCustomerOrder();
                        customerOrder.FinalPrice = allOrdersReader.GetDecimal(allOrdersReader.GetOrdinal("finalPrice"));
                        customerOrder.Status = allOrdersReader.GetString(allOrdersReader.GetOrdinal("orderStatus"));
                        customerOrder.DateOrder = allOrdersReader.GetDateTime(allOrdersReader.GetOrdinal("dateOrder"));
                        customerOrder.CustomerId = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("customerId"));
                        customerOrder.PaymentMethod = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("paymentMethodId"));
                        customerOrder.OrderId = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("orderId"));
                        customerOrders.Add(customerOrder);
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
                    cmdGetCancelledOrders.CommandText = "SELECT orderId, finalPrice, orderStatus, dateOrder, customerId, paymentMethodId FROM CustomerOrder  WHERE orderStatus = @cancelled ";
                    cmdGetCancelledOrders.Parameters.AddWithValue("@cancelled", "Cancelled");
                    SqlDataReader allOrdersReader = cmdGetCancelledOrders.ExecuteReader();

                    while (allOrdersReader.Read())
                    {
                        ServiceCustomerOrder customerOrder = new ServiceCustomerOrder();
                        customerOrder.FinalPrice = allOrdersReader.GetDecimal(allOrdersReader.GetOrdinal("finalPrice"));
                        customerOrder.Status = allOrdersReader.GetString(allOrdersReader.GetOrdinal("orderStatus"));
                        customerOrder.DateOrder = allOrdersReader.GetDateTime(allOrdersReader.GetOrdinal("dateOrder"));
                        customerOrder.CustomerId = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("customerId"));
                        customerOrder.PaymentMethod = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("paymentMethodId"));
                        customerOrder.OrderId = allOrdersReader.GetInt32(allOrdersReader.GetOrdinal("orderId"));
                        customerOrders.Add(customerOrder);
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
                    cmdGetOrder.CommandText = "SELECT finalPrice, orderStatus, dateOrder, customerId, paymentMethodId, orderId FROM CustomerOrder WHERE orderId = @orderId";
                    cmdGetOrder.Parameters.AddWithValue("orderId", customerOrderId);
                    SqlDataReader orderReader = cmdGetOrder.ExecuteReader();

                    while (orderReader.Read())
                    {
                        customerOrder = new ServiceCustomerOrder();
                        customerOrder.FinalPrice = orderReader.GetDecimal(orderReader.GetOrdinal("finalPrice"));
                        customerOrder.Status = orderReader.GetString(orderReader.GetOrdinal("orderStatus"));
                        customerOrder.DateOrder = orderReader.GetDateTime(orderReader.GetOrdinal("dateOrder"));
                        customerOrder.CustomerId = orderReader.GetInt32(orderReader.GetOrdinal("customerId"));
                        customerOrder.PaymentMethod = orderReader.GetInt32(orderReader.GetOrdinal("paymentMethodId"));
                        customerOrder.OrderId = orderReader.GetInt32(orderReader.GetOrdinal("orderId"));
                    }
                    return customerOrder;
                }
            }
        }

        public IEnumerable<ServicePaymentMethod> GetPaymentMethods()
        {
            List<ServicePaymentMethod> paymentMethods = new List<ServicePaymentMethod>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdGetPaymentMethods = connection.CreateCommand())
                {
                    cmdGetPaymentMethods.CommandText = "SELECT pMethodId, paymentMethod FROM PaymentMethods";
                    SqlDataReader paymentMethodReader = cmdGetPaymentMethods.ExecuteReader();

                    while (paymentMethodReader.Read())
                    {
                        ServicePaymentMethod pMethod = new ServicePaymentMethod();
                        pMethod.PMethodId = paymentMethodReader.GetInt32(paymentMethodReader.GetOrdinal("pMethodId"));
                        pMethod.PaymentMethodValue = paymentMethodReader.GetString(paymentMethodReader.GetOrdinal("paymentMethod"));
                        paymentMethods.Add(pMethod);
                    }
                }
            }
            return paymentMethods;
        }

        public int InsertOrder(ServiceCustomerOrder order)
        {
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int orderId = 0;
                using (SqlCommand cmdInsertOrder = connection.CreateCommand())
                {
                        //InsertsOrder (Regardless of discount)
                        cmdInsertOrder.CommandText = "INSERT INTO CustomerOrder (finalPrice, orderStatus, dateOrder, customerId, paymentMethodId) OUTPUT INSERTED.orderId VALUES (@finalPrice, @orderStatus, @dateOrder, @customerId, @paymentMethodId)";
                        cmdInsertOrder.Parameters.AddWithValue("finalPrice", order.FinalPrice);
                        cmdInsertOrder.Parameters.AddWithValue("orderStatus", order.Status);
                        cmdInsertOrder.Parameters.AddWithValue("dateOrder", order.DateOrder);
                        cmdInsertOrder.Parameters.AddWithValue("customerId", order.CustomerId);
                        cmdInsertOrder.Parameters.AddWithValue("paymentMethodId", order.PaymentMethod);
                        orderId = (int)cmdInsertOrder.ExecuteScalar();
                        
                }
                return orderId;
            }
            
        }

        public void InsertDiscountOrder(int orderId, string discountCode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                using(SqlCommand cmdInsertDiscountOrder = connection.CreateCommand())
                {
                    cmdInsertDiscountOrder.CommandText = "INSERT INTO DiscountOrder (orderId, discountCode) VALUES (@orderId, @discountCode)";
                    cmdInsertDiscountOrder.Parameters.AddWithValue("orderId", orderId);
                    cmdInsertDiscountOrder.Parameters.AddWithValue("discountCode", discountCode);
                    cmdInsertDiscountOrder.ExecuteNonQuery();
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
                    cmdUpdateOrder.CommandText = "UPDATE CustomerOrder SET orderStatus = @orderStatus, finalPrice = @finalPrice WHERE orderId = @orderId";
                    cmdUpdateOrder.Parameters.AddWithValue("orderStatus", order.Status);
                    cmdUpdateOrder.Parameters.AddWithValue("finalPrice", order.FinalPrice);
                    cmdUpdateOrder.Parameters.AddWithValue("orderId", order.OrderId);
                    rowsAffected = cmdUpdateOrder.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public bool FinishCheckout(ServiceCustomerOrder order)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        int orderID = InsertOrder(order);
                        order.OrderId = orderID;

                        if (order.DiscountCode != null)
                        {
                            InsertDiscountOrder(orderID, order.DiscountCode);
                        }

                        decimal totalPrice = -1;
                        foreach (var item in order.ShoppingCart)
                        {
                            item.OrderId = orderID;
                            totalPrice += item.SubTotal;
                            dataProductLine.InsertProductLine(item);

                            for (int i = 0; i < 5; i++)
                            {
                                ServiceProduct productFromDB = dataProduct.GetProductById(item.Product.ProductId);
                                int remainingAmountOnStock = productFromDB.AmountOnStock - item.Amount;
                                if (remainingAmountOnStock < 0)
                                {
                                    throw new TransactionAbortedException();
                                }
                                else
                                {
                                    productFromDB.AmountOnStock = remainingAmountOnStock;
                                    int affectedRows = dataProduct.UpdateProduct(productFromDB);
                                    if(affectedRows != 0)
                                    {
                                        break;
                                    }
                                }
                            }

                        }
                        order.FinalPrice = totalPrice;
                        UpdateOrder(order);
                        scope.Complete();
                        success = true;
                    }
                }

                catch (TransactionAbortedException ex)
                {
                    success = false;
                }
            }
            return success;
        }
    }
}
