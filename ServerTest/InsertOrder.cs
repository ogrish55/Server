using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Model;
using Service.Data;

namespace ServiceTest
{
    /// <summary>
    /// Summary description for InsertOrder
    /// </summary>
    [TestClass]
    public class InsertOrder
    {
        [TestMethod]
        public void InsertOrderTest()
        {
            //Arrange
            DataProduct dataProduct = new DataProduct();
            DataCustomerOrder dataCustomerOrder = new DataCustomerOrder();

            ServiceCustomer customer = new ServiceCustomer();
            customer.Name = "Peter J.";
            customer.Address = "Sofiendalsvej";
            customer.ZipCode = 9000;
            customer.PhoneNo = 12345678;

            ServiceProduct product = new ServiceProduct();
            product = dataProduct.GetProductById(4);

            ServiceProductLine productLine = new ServiceProductLine();
            productLine.Amount = 1;
            productLine.SubTotal = product.Price;
            productLine.Product = product;

            ServiceCustomerOrder order = new ServiceCustomerOrder();
            order.FinalPrice = productLine.SubTotal;
            order.Status = "Active";
            order.DateOrder = DateTime.Now;
            order.PaymentMethod = 1;
            order.DiscountCode = null;
            List<ServiceProductLine> productLines = new List<ServiceProductLine>();
            productLines.Add(productLine);
            order.ShoppingCart = productLines;

            //Act
            bool success = dataCustomerOrder.FinishCheckout(customer, order);


            //Assert
            Assert.IsTrue(success);

        }
    }
}
