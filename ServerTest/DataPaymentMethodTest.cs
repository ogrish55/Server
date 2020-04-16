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
    }
}
