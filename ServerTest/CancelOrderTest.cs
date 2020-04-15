using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Data;
using Service.Model;

namespace ServiceTest
{
    [TestClass]
    public class CancelOrderTest
    {
        [TestMethod]
        public void TestCancelOrder()
        {
            //Arrange
            DataCustomerOrder dataOrder = new DataCustomerOrder();
            ServiceCustomerOrder order = new ServiceCustomerOrder();

            // Get the first order in the DB
            order = dataOrder.GetOrder(1);

            // Change the order status to Cancelled
            order.Status = "Cancelled";

            //Act
            dataOrder.UpdateOrder(order);  // Update the order and update the database

            //Assert
            Assert.AreEqual("Cancelled", dataOrder.GetOrder(1).Status);
        }

        [TestMethod]
        public void TestGetAllOrders()
        {
            // Arrange
            DataCustomerOrder dataOrder = new DataCustomerOrder();


            // Act
            List<ServiceCustomerOrder> orders = (List<ServiceCustomerOrder>)dataOrder.GetAllOrders();

            //Assert
            Assert.IsTrue(orders.Count >= 1);
        }
    }
}
