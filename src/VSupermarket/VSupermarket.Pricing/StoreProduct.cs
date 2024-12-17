namespace VSupermarket.Pricing
{
    public class StoreProduct
    {
        public string Name { get; }
        public decimal Price { get; }

        private readonly IList<IPricingRule>? _pricingRules;

        public StoreProduct(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public StoreProduct(string name, decimal price, IList<IPricingRule> pricingRules)
        {
            Name = name;
            Price = price;
            _pricingRules = pricingRules;
        }

        public decimal GetPrice() => Price;

        public string GetProductCode() => Name;

        public IList<IPricingRule> GetPricingRule() => _pricingRules;
    }
}
