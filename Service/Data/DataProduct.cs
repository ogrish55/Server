﻿using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Service.Data
{
    public class DataProduct : IDataProduct
    {
        private string _connectionString;
        public DataProduct()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["WebshopDatabase"].ConnectionString;
        }

        public int DeleteProduct(int productId)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdDeleteProduct = connection.CreateCommand())
                {
                    cmdDeleteProduct.CommandText = "DELETE FROM Product WHERE productId = @productId";
                    cmdDeleteProduct.Parameters.AddWithValue("productId", productId);

                    rowsAffected = cmdDeleteProduct.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public Product GetProductById(int productId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdGetProductById = connection.CreateCommand())
                {
                    Product product = new Product();
                    cmdGetProductById.CommandText = "SELECT productId, name, price, description FROM Product WHERE productId = @productId";
                    cmdGetProductById.Parameters.AddWithValue("productId", productId);
                    SqlDataReader productReader = cmdGetProductById.ExecuteReader();

                    while (productReader.Read())
                    {
                        product.Name = productReader.GetString(productReader.GetOrdinal("name"));
                        product.Description = productReader.GetString(productReader.GetOrdinal("description"));
                        product.Price = productReader.GetDecimal(productReader.GetOrdinal("price"));
                        product.ProdutId = productReader.GetInt32(productReader.GetOrdinal("productId"));
                    }

                    return product;
                }
            }
        }

        public void InsertProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdInsertProduct = connection.CreateCommand())
                {
                    cmdInsertProduct.CommandText = "INSERT INTO Product (name, price, description) VALUES (@name, @price, @description)";
                    cmdInsertProduct.Parameters.AddWithValue("name", product.Name);
                    cmdInsertProduct.Parameters.AddWithValue("price", product.Price);
                    cmdInsertProduct.Parameters.AddWithValue("description", product.Description);

                    cmdInsertProduct.ExecuteNonQuery();
                }
            }
        }

        public int UpdateProduct(Product product)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdUpdateProduct = connection.CreateCommand())
                {
                    cmdUpdateProduct.CommandText = "UPDATE Product SET name = @name, price = @price, description = @description WHERE productId = @productId";
                    cmdUpdateProduct.Parameters.AddWithValue("name", product.Name);
                    cmdUpdateProduct.Parameters.AddWithValue("price", product.Price);
                    cmdUpdateProduct.Parameters.AddWithValue("description", product.Description);
                    cmdUpdateProduct.Parameters.AddWithValue("productId", product.ProdutId);

                    rowsAffected = cmdUpdateProduct.ExecuteNonQuery();
                }
                return rowsAffected;
            }
        }
    }
}
