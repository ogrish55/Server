using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Data;
using Service.Model;

namespace ServerTest
{
    [TestClass]
    public class DataProductTest
    {
        [TestMethod]
        public void TestDatabaseAccess()
        {
            //Arrange
            var _connectionString = ConfigurationManager.ConnectionStrings["WebshopDatabase"].ConnectionString;
            bool check = false;

            //Act
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    check = true;
                }
            }
            catch
            {
                check = false;
            }

            //Assert
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void TestInsertProduct()
        {
            //Arrange
            DataProduct dataProduct = new DataProduct();
            ServiceProduct product = new ServiceProduct();
            product.Name = "Grafikkort";
            product.Price = 1998;
            product.Description = "For at få den bedste spiloplevelse er det vigtigt med et godt grafikkort";
            bool check = false;

            //Act
            try
            {
                dataProduct.InsertProduct(product);
                check = true;
            }
            catch
            {
                check = false;
            }

            //Assert
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void TestDeleteProduct()
        {
            //Arrange
            DataProduct dataProduct = new DataProduct();
            int rowsAffected;

            //Act
            rowsAffected = dataProduct.DeleteProduct(8);

            //Assert
            Assert.IsTrue(rowsAffected >= 1, "Rows affected " + rowsAffected);
        }

        [TestMethod]
        public void TestUpdateProdut()
        {
            //Arrange
            DataProduct dataProduct = new DataProduct();
            ServiceProduct product = dataProduct.GetProductById(6);
            int rowsAffected;

            //Act
            product.Name = "SSD harddisk";
            rowsAffected = dataProduct.UpdateProduct(product);

            //Assert
            Assert.IsTrue(rowsAffected >= 1, "Rows affected " + rowsAffected + product.Name);
        }

        [TestMethod]
        public void TestGetAllProducts()
        {
            //Arrange
            DataProduct dataProduct = new DataProduct();

            //Act
            List<ServiceProduct> products = (List<ServiceProduct>) dataProduct.GetAllProducts();

            //Assert
            Assert.IsTrue(products.Count >= 1, "Number of products in list: " + products.Count);
        }
    }
}
