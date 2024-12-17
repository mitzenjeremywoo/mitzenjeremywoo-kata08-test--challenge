namespace VSupermarket.Model
{
    public class WebProductModel
    {
        public string Id { get; set; }
        public decimal UnitPrice { get; set; }
        public string Name { get; set; }
        public DiscountType Special { get; set; }
        public int OrderQuantity { get; set; }
    }
}
