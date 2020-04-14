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
    public class DataDeliveryDescriptionTest
    {
        [TestMethod]
        public void TestInsertDeliveryDescription()
        {
            //Arrange
            DataDeliveryDescription dataDeliveryDescription = new DataDeliveryDescription();
            ServiceDeliveryDescription deliveryDescription = new ServiceDeliveryDescription();
            deliveryDescription.Name = "Scheelsminde Hotel";
            deliveryDescription.Address = "Scheelsmindevej 35";
            deliveryDescription.ZipCode = 9200;
            deliveryDescription.PhoneNo = "12345678";
            //deliveryDescription.CustomerId = 100;
            bool check = false;

            //Act
            try
            {
                dataDeliveryDescription.InsertDeliveryDescription(deliveryDescription);
                check = true;
            }
            catch
            {

                check = false;
            }

            //Assert
            Assert.IsTrue(check);
        }

    }
}
