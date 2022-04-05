namespace Task8
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public List<ProductOrder>? ProductOrders { get; set; }
        public int CoffeeIntensity { get; set; }
    }
}
