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

        public IEnumerable<ServiceProduct> GetAllProducts()
        {
            List<ServiceProduct> products = new List<ServiceProduct>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdGetAllProducts = connection.CreateCommand())
                {
                    cmdGetAllProducts.CommandText = "SELECT productId, name, price, description, amountOnStock FROM Product";
                    SqlDataReader productsReader = cmdGetAllProducts.ExecuteReader();

                    while (productsReader.Read())
                    {
                        ServiceProduct product = new ServiceProduct();
                        product.Name = productsReader.GetString(productsReader.GetOrdinal("name"));
                        product.Description = productsReader.GetString(productsReader.GetOrdinal("description"));
                        product.Price = productsReader.GetDecimal(productsReader.GetOrdinal("price"));
                        product.ProductId = productsReader.GetInt32(productsReader.GetOrdinal("productId"));
                        product.AmountOnStock = productsReader.GetInt32(productsReader.GetOrdinal("amountOnStock"));
                        product.Brand = productsReader.GetString(productsReader.GetOrdinal("brand"));

                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public ServiceProduct GetProductById(int productId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmdGetProductById = connection.CreateCommand())
                {
                    ServiceProduct product = new ServiceProduct();
                    cmdGetProductById.CommandText = "SELECT productId, name, price, description, amountOnStock FROM Product WHERE productId = @productId";
                    cmdGetProductById.Parameters.AddWithValue("productId", productId);
                    SqlDataReader productReader = cmdGetProductById.ExecuteReader();

                    while (productReader.Read())
                    {
                        product.Name = productReader.GetString(productReader.GetOrdinal("name"));
                        product.Description = productReader.GetString(productReader.GetOrdinal("description"));
                        product.Price = productReader.GetDecimal(productReader.GetOrdinal("price"));
                        product.ProductId = productReader.GetInt32(productReader.GetOrdinal("productId"));
                        product.AmountOnStock = productReader.GetInt32(productReader.GetOrdinal("amountOnStock"));
                        product.Brand = productReader.GetString(productReader.GetOrdinal("brand"));
                    }
                    return product;
                }
            }
        }

        public int InsertProduct(ServiceProduct product)
        {
            int insertedId = -1;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdInsertProduct = connection.CreateCommand())
                {
                    cmdInsertProduct.CommandText = "INSERT INTO Product (name, price, description, amountOnStock, brand) OUTPUT INSERTED.productId VALUES (@name, @price, @description, @amount, @brand)";
                    cmdInsertProduct.Parameters.AddWithValue("name", product.Name);
                    cmdInsertProduct.Parameters.AddWithValue("price", product.Price);
                    cmdInsertProduct.Parameters.AddWithValue("description", product.Description);
                    cmdInsertProduct.Parameters.AddWithValue("amount", product.AmountOnStock);
                    cmdInsertProduct.Parameters.AddWithValue("brand", product.Brand);

                    insertedId = (int)cmdInsertProduct.ExecuteScalar();
                }
            }
            return insertedId;
        }

        public int UpdateProduct(ServiceProduct product)
        {
            int rowsAffected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdUpdateProduct = connection.CreateCommand())
                {
                    cmdUpdateProduct.CommandText = "UPDATE Product SET name = @name, price = @price, description = @description, brand = @brand WHERE productId = @productId";
                    cmdUpdateProduct.Parameters.AddWithValue("name", product.Name);
                    cmdUpdateProduct.Parameters.AddWithValue("price", product.Price);
                    cmdUpdateProduct.Parameters.AddWithValue("description", product.Description);
                    cmdUpdateProduct.Parameters.AddWithValue("productId", product.ProductId);
                    cmdUpdateProduct.Parameters.AddWithValue("brand", product.Brand);

                    rowsAffected = cmdUpdateProduct.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
    }
}
