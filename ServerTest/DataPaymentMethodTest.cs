using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Data;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTest
{
    [TestClass]
    public class DataPaymentMethodTest
    {
        [TestMethod]
        public void GetPaymentMethodsTest()
        {
            //Arrange
            DataCustomerOrder dataCustomerOrder = new DataCustomerOrder();

            //Act
            List<ServicePaymentMethod> paymentMethods = (List<ServicePaymentMethod>) dataCustomerOrder.GetPaymentMethods();

            //Assert
            Assert.IsTrue(paymentMethods.Count() >= 1);
        }

        [TestMethod]
        public void SetPaymentMethodTest()
        {
            //Arrange
            ServiceCustomerOrder order = new ServiceCustomerOrder();
            DataCustomerOrder dco = new DataCustomerOrder();
            ServiceCustomerOrder testOrder;
            order.DateOrder = DateTime.Today;
            order.FinalPrice = 5000;
            order.Status = "Test Status";
            order.PaymentMethod = 1;
            order.CustomerId = 1;
            //Act
            int idOfTestOrder = dco.InsertOrder(order);
            testOrder = dco.GetOrder(idOfTestOrder);

            //Assert
            Assert.IsNotNull(testOrder.PaymentMethod);
        }
    }
}
