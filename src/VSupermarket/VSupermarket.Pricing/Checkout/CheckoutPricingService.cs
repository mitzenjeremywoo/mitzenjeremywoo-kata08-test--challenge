namespace VSupermarket.Pricing.Checkout
{
    public class CheckoutPricingService
    {
        private readonly Dictionary<string, IPricingRule> _pricingRules = new Dictionary<string, IPricingRule>();
        private readonly List<StoreProduct> _trolleyCheckoutItems = new List<StoreProduct>();

        public void AddPricingRule(string itemName, IPricingRule pricingRule)
        {
            _pricingRules[itemName] = pricingRule;
        }

        public void Scan(StoreProduct product)
        {
            _trolleyCheckoutItems.Add(product);
        }

        public decimal CalculatePrice()
        {
            return _trolleyCheckoutItems
                .GroupBy(item => item.Name)
                .Sum(productGroup =>
                {
                    var productName = productGroup.Key;
                    var products = productGroup.ToList();

                    var pricingRule = productGroup.First().GetPricingRule();
                    decimal subTotal = 0m;

                    if (pricingRule != null && pricingRule.Count() > 0)
                    {
                        foreach (var ruleItem in pricingRule)
                        {
                            subTotal =+ ruleItem.CalculatePrice(products);
                        }
                        return subTotal;
                    }

                    // additional discounts //                    
                    //if (_pricingRules.ContainsKey(productName))
                    //{
                    //    return _pricingRules[productName].CalculatePrice(products);
                    //}

                    return products.Sum(item => item.Price); 
                });
        }
    }
}
