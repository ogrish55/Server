using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Data;
using Service.Model;
using System;

namespace ServiceTest
{
    [TestClass]
    public class DiscountTest
    {
        [TestMethod]
        public void OrderWithoutDiscount()
        {
            //ARRANGE
            ServiceCustomerOrder order = new ServiceCustomerOrder();
            DataCustomerOrder dco = new DataCustomerOrder();
            ServiceCustomerOrder testOrder = new ServiceCustomerOrder();
            //  Set all attributes except Discount
            order.DateOrder = DateTime.Today;
            order.FinalPrice = 1000;
            order.Status = "Test Status";
            order.PaymentMethod = 1;
            order.CustomerId = 1;
            
            //ACT
            int testId = dco.InsertOrder(order);
            testOrder = dco.GetOrder(testId);
            
            //ASSERT
            Assert.IsNotNull(testOrder);
        }

        [TestMethod]
        public void GetDiscountByCodeTest()
        {
            // Arrange
            DataDiscount dataDiscount = new DataDiscount();

            // Act
            decimal Amount = dataDiscount.GetDiscountByCode("acksyp");

            // Assert
            Assert.AreEqual(10, Amount);
        }
    }
}
