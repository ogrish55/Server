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
    public class DataDeliveryDescription : IDataDeliveryDescription
    {
        private string _connectionString;
        public DataDeliveryDescription()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["WebshopDatabase"].ConnectionString;
        }

        public void InsertDeliveryDescription(ServiceDeliveryDescription deliveryDescription)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                using (SqlCommand cmdInsertDeliveryDescription = connection.CreateCommand())
                {
                    cmdInsertDeliveryDescription.CommandText = "INSERT INTO DeliveryDescription (name, address, zipCode, phoneNo, customerId) VALUES (@name, @address, @zipCode, @phoneNo, @customerId)";
                    cmdInsertDeliveryDescription.Parameters.AddWithValue("name", deliveryDescription.Name);
                    cmdInsertDeliveryDescription.Parameters.AddWithValue("address", deliveryDescription.Address);
                    cmdInsertDeliveryDescription.Parameters.AddWithValue("zipCode", deliveryDescription.ZipCode);
                    cmdInsertDeliveryDescription.Parameters.AddWithValue("phoneNo", deliveryDescription.PhoneNo);
                    cmdInsertDeliveryDescription.Parameters.AddWithValue("customerId", deliveryDescription.CustomerId);

                    cmdInsertDeliveryDescription.ExecuteNonQuery();
                }
            }
        }

        public ServiceDeliveryDescription GetDeliveryDescriptionById(int deliveryId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmdGetDeliveryDescription = connection.CreateCommand())
                {
                    ServiceDeliveryDescription deliveryDescription = new ServiceDeliveryDescription();
                    cmdGetDeliveryDescription.CommandText = "SELECT deliveryId, name, address, zipCode, phoneNo, customerId FROM DeliveryDescription WHERE deliveryId = @deliveryId";
                    cmdGetDeliveryDescription.Parameters.AddWithValue("deliveryId", deliveryId);
                    SqlDataReader deliveryDescriptionReader = cmdGetDeliveryDescription.ExecuteReader();

                    while (deliveryDescriptionReader.Read())
                    {
                        deliveryDescription.DeliveryId = deliveryDescriptionReader.GetInt32(deliveryDescriptionReader.GetOrdinal("deliveryId"));
                        deliveryDescription.Name = deliveryDescriptionReader.GetString(deliveryDescriptionReader.GetOrdinal("name"));
                        deliveryDescription.Address = deliveryDescriptionReader.GetString(deliveryDescriptionReader.GetOrdinal("address"));
                        deliveryDescription.ZipCode = deliveryDescriptionReader.GetInt32(deliveryDescriptionReader.GetOrdinal("zipCode"));
                        deliveryDescription.PhoneNo = deliveryDescriptionReader.GetString(deliveryDescriptionReader.GetOrdinal("phoneNo"));
                        deliveryDescription.CustomerId = deliveryDescriptionReader.GetInt32(deliveryDescriptionReader.GetOrdinal("customerId"));
                    }
                    return deliveryDescription;
                }
            }
        }

        public int UpdateDeliveryDescription(ServiceDeliveryDescription deliveryDescription)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdUpdateDeliveryDescription = connection.CreateCommand())
                {
                    cmdUpdateDeliveryDescription.CommandText = "UPDATE DeliveryDescription SET name = @name, address = @address, zipCode = @zipCode, phoneNo = @phoneNo, customerId = @customerId WHERE deliveryId = @deliveryId";
                    cmdUpdateDeliveryDescription.Parameters.AddWithValue("name", deliveryDescription.Name);
                    cmdUpdateDeliveryDescription.Parameters.AddWithValue("address", deliveryDescription.Address);
                    cmdUpdateDeliveryDescription.Parameters.AddWithValue("zipCode", deliveryDescription.ZipCode);
                    cmdUpdateDeliveryDescription.Parameters.AddWithValue("phoneNo", deliveryDescription.PhoneNo);
                    cmdUpdateDeliveryDescription.Parameters.AddWithValue("customerId", deliveryDescription.CustomerId);
                    cmdUpdateDeliveryDescription.Parameters.AddWithValue("deliveryId", deliveryDescription.DeliveryId);

                    rowsAffected = cmdUpdateDeliveryDescription.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public int DeleteDeliveryDescription(int deliveryId)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdDeleteDeliveryDescription = connection.CreateCommand())
                {
                    cmdDeleteDeliveryDescription.CommandText = "DELETE FROM DeliveryDescription WHERE deliveryId = @deliveryId";
                    cmdDeleteDeliveryDescription.Parameters.AddWithValue("deliveryId", deliveryId);

                    rowsAffected = cmdDeleteDeliveryDescription.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

    }
}
