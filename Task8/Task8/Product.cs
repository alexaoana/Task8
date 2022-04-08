namespace Task8
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public List<ProductOrder>? ProductOrders { get; set; }
    }
}
