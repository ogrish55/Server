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
    public class DataCustomer : IDataCustomer
    {
        private string _connectionString;
        public DataCustomer()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["WebshopDatabase"].ConnectionString;
        }
        public int DeleteCustomer(int customerId)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdDeleteCustomer = connection.CreateCommand())
                {
                    cmdDeleteCustomer.CommandText = "DELETE FROM Customer WHERE customerId = @customerId";
                    cmdDeleteCustomer.Parameters.AddWithValue("customerId", customerId);

                    rowsAffected = cmdDeleteCustomer.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public void InsertCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdInsertCustomer = connection.CreateCommand())
                {
                    cmdInsertCustomer.CommandText = "INSERT INTO Customer (name, address, zipCode, phoneNo) VALUES (@name, @address, @zipCode, @phoneNo)";
                    cmdInsertCustomer.Parameters.AddWithValue("name", customer.Name);
                    cmdInsertCustomer.Parameters.AddWithValue("address", customer.Address);
                    cmdInsertCustomer.Parameters.AddWithValue("zipCode", customer.ZipCode);
                    cmdInsertCustomer.Parameters.AddWithValue("phoneNo", customer.PhoneNo);

                    cmdInsertCustomer.ExecuteNonQuery();
                }
            }
        }

        public int UpdateCustomer(Customer customer)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdUpdateCustomer = connection.CreateCommand())
                {
                    cmdUpdateCustomer.CommandText = "UPDATE Customer SET name = @name, address = @address, zipCode = @zipCode, phoneNo = @phoneNo WHERE customerId = @customerId";
                    cmdUpdateCustomer.Parameters.AddWithValue("name", customer.Name);
                    cmdUpdateCustomer.Parameters.AddWithValue("address", customer.Address);
                    cmdUpdateCustomer.Parameters.AddWithValue("zipCode", customer.ZipCode);
                    cmdUpdateCustomer.Parameters.AddWithValue("phoneNo", customer.PhoneNo);
                    rowsAffected = cmdUpdateCustomer.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
    }
}
