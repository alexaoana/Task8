namespace Task8
{
    public class Service
    {
        public decimal TotalPriceToPay(Order order)
        {
            decimal total = 0;
            foreach (var productOrder in order.ProductOrders)
                total += productOrder.Quantity * productOrder.Product.Price;
            return total;
        }
    }
}
