using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task8;

namespace Testing_MSUnit
{
    [TestClass]
    public class UnitTest1
    {
        private Order _order = new Order();
        private Service _service = new Service();

        [TestMethod]
        public void Returns0ForNoProductOrders()
        {
            _order.Id = 1;
            _order.ProductOrders = new List<ProductOrder>();
            Assert.AreEqual(0, _service.TotalPriceToPay(_order));
        }
        [TestMethod]
        public void OneProductOrders()
        {
            var product = new Product
            {
                Price = decimal.Parse("5.5")
            };
            var productOrder = new ProductOrder
            {
                Product = product,
                Quantity = 1
            };
            _order.ProductOrders = new List<ProductOrder>();
            _order.ProductOrders.Add(productOrder);
            Assert.AreEqual(decimal.Parse("5.5"), _service.TotalPriceToPay(_order));
        }

        [TestMethod]
        public void MultipleProductOrders()
        {
            var product1 = new Product
            {
                Price = decimal.Parse("5.5")
            };
            var product2 = new Product()
            {
                Price = decimal.Parse("10")
            };
            var productOrder1 = new ProductOrder
            {
                Product = product1,
                Quantity = 1
            };
            var productOrder2 = new ProductOrder
            {
                Product = product2,
                Quantity = 2
            };
            var productOrders = new List<ProductOrder>();
            productOrders.Add(productOrder1);
            productOrders.Add(productOrder2);
            _order.ProductOrders = productOrders;
            _order.Id = 1;
            Assert.AreEqual(decimal.Parse("25.5"), _service.TotalPriceToPay(_order));
        }
    }
}