namespace VSupermarket.Pricing.Rules
{
    /// <summary>
    /// Item are priced in their unit price.
    /// </summary>
    public class UnitPriceRule : IPricingRule
    {
        public decimal CalculatePrice(IEnumerable<StoreProduct> product)
        {
            return product.Count() * product.First().GetPrice();
        }
    }
}
