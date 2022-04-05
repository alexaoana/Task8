using NUnit.Framework;
using System.Collections.Generic;
using Task8;

namespace Testing2
{
    public class Tests
    {
        private Service _service;
        private Order _order;
        [SetUp]
        public void Setup()
        {
            _service = new Service();
            _order = new Order();
        }

        [Test]
        public void TotalPriceFixture()
        {
            var product = new Product
            {
                Price = decimal.Parse("7.5")
            };
            var productOrder = new ProductOrder
            {
                Product = product,
                Quantity = 2
            };
            _order.ProductOrders = new List<ProductOrder>();
            _order.ProductOrders.Add(productOrder);
            Assert.AreEqual(15, _service.TotalPriceToPay(_order));
        }
    }
}