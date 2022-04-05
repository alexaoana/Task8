using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Task8;

namespace Testing
{
    public class Tests
    {
        [TestFixture]
        public class Testing
        {
            private Service _service;
            private Order _order;

            [SetUp]
            public void initialize()
            {
                _service = new Service();
                _order = new Order();
            }
            
            [TestCase(2)]
            public void Returns0ForNoProductOrders(int a)
            {
                _order.Id = a;
                _order.ProductOrders = new List<ProductOrder>();
                Assert.AreEqual(0, _service.TotalPriceToPay(_order));
            }
            [Test]
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
                Assert.AreEqual(5.5, _service.TotalPriceToPay(_order));
            }

            [Test]
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
                Assert.AreEqual(25.5, _service.TotalPriceToPay(_order));
            }
        }

        public class MockTesting
        {
            [Test]
            public void Returns0IfNoProductOrders()
            {
                var mockDataAccess = new Mock<Service>();
                var order = new Order
                {
                    Id = 1,
                    ProductOrders = new List<ProductOrder>()
                };
                mockDataAccess.Setup(m => m.TotalPriceToPay(order)).Returns(0);
                var service = new Service();
                
                service.TotalPriceToPay(order);
                mockDataAccess.Verify(m => m.TotalPriceToPay(order), Times.Once());
            }
        }
    }
}
