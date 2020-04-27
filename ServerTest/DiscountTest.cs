using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Data;

namespace ServiceTest
{
    [TestClass]
    public class DiscountTest
    {
        [TestMethod]
        public void GetDiscountByCodeTest()
        {
            // Arrange
            DataDiscount dataDiscount = new DataDiscount();


            // Act
            int Amount = dataDiscount.GetDiscountByCode("acksyp");

            // Assert
            Assert.AreEqual(10, Amount);
        }
    }
}
