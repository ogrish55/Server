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
    public class DataCustomer
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

        public int InsertCustomer(ServiceCustomer customer)
        {
            int insertedId = -1;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdInsertCustomer = connection.CreateCommand())
                {
                    cmdInsertCustomer.CommandText = "INSERT INTO Customer (name, address, zipCode, phoneNo, passwordHash, salt, email) OUTPUT INSERTED.customerId VALUES (@name, @address, @zipCode, @phoneNo, @passwordHash, @salt, @email)";
                    cmdInsertCustomer.Parameters.AddWithValue("name", customer.Name);
                    cmdInsertCustomer.Parameters.AddWithValue("address", customer.Address);
                    cmdInsertCustomer.Parameters.AddWithValue("zipCode", customer.ZipCode);
                    cmdInsertCustomer.Parameters.AddWithValue("phoneNo", customer.PhoneNo);
                    cmdInsertCustomer.Parameters.AddWithValue("passwordHash", customer.Hash);
                    cmdInsertCustomer.Parameters.AddWithValue("salt", customer.Salt);
                    cmdInsertCustomer.Parameters.AddWithValue("email", customer.Email);

                    insertedId = (int)cmdInsertCustomer.ExecuteScalar();
                }
            }
            return insertedId;
        }

        public ServiceCustomer GetCustomerByEmail(string email)
        {
            ServiceCustomer serviceCustomer = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdGetCustomerByEmail = connection.CreateCommand())
                {
                    cmdGetCustomerByEmail.CommandText = "SELECT customerId, name, address, zipCode, phoneNo, passwordHash, salt, email FROM Customer WHERE email = @email";
                    cmdGetCustomerByEmail.Parameters.AddWithValue("email", email);

                    SqlDataReader customerReader = cmdGetCustomerByEmail.ExecuteReader();
                    if (customerReader.Read())
                    {
                        serviceCustomer = new ServiceCustomer();
                        serviceCustomer.CustomerId = customerReader.GetInt32(customerReader.GetOrdinal("customerId"));
                        serviceCustomer.Name = customerReader.GetString(customerReader.GetOrdinal("name"));
                        serviceCustomer.Address = customerReader.GetString(customerReader.GetOrdinal("address"));
                        serviceCustomer.ZipCode = customerReader.GetInt32(customerReader.GetOrdinal("zipCode"));
                        serviceCustomer.PhoneNo = customerReader.GetString(customerReader.GetOrdinal("phoneNo"));
                        serviceCustomer.Hash = customerReader.GetString(customerReader.GetOrdinal("passwordHash"));
                        serviceCustomer.Salt = customerReader.GetString(customerReader.GetOrdinal("salt"));
                        serviceCustomer.Email = customerReader.GetString(customerReader.GetOrdinal("email"));
                        serviceCustomer.City = GetCityFromZipCode(serviceCustomer.ZipCode);
                    }
                }
            }
            return serviceCustomer;
        }

        public ServiceCustomer GetCustomerById(int id)
        {
            ServiceCustomer serviceCustomer = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdGetCustomerByEmail = connection.CreateCommand())
                {
                    cmdGetCustomerByEmail.CommandText = "SELECT customerId, name, address, zipCode, phoneNo, passwordHash, salt, email FROM Customer WHERE customerId = @CustomerIDD";
                    cmdGetCustomerByEmail.Parameters.AddWithValue("CustomerIDD", id);

                    SqlDataReader customerReader = cmdGetCustomerByEmail.ExecuteReader();
                    if (customerReader.Read())
                    {
                        serviceCustomer = new ServiceCustomer();
                        serviceCustomer.CustomerId = customerReader.GetInt32(customerReader.GetOrdinal("customerId"));
                        serviceCustomer.Name = customerReader.GetString(customerReader.GetOrdinal("name"));
                        serviceCustomer.Address = customerReader.GetString(customerReader.GetOrdinal("address"));
                        serviceCustomer.ZipCode = customerReader.GetInt32(customerReader.GetOrdinal("zipCode"));
                        serviceCustomer.PhoneNo = customerReader.GetString(customerReader.GetOrdinal("phoneNo"));
                        serviceCustomer.Hash = customerReader.GetString(customerReader.GetOrdinal("passwordHash"));
                        serviceCustomer.Salt = customerReader.GetString(customerReader.GetOrdinal("salt"));
                        serviceCustomer.Email = customerReader.GetString(customerReader.GetOrdinal("email"));
                        serviceCustomer.City = GetCityFromZipCode(serviceCustomer.ZipCode);
                    }
                }
            }
            return serviceCustomer;
        }

        public int UpdateCustomer(ServiceCustomer customer)
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

        public string GetCityFromZipCode(int zipCode)
        {
            string city = string.Empty;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select city from ZipCity where zipCode = @zipCode";
                    cmd.Parameters.AddWithValue("zipCode", zipCode);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        city = reader.GetString(reader.GetOrdinal("city"));
                    }
                }
            }

            return city;

        }
    }
}
