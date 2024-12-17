namespace VSupermarket.Pricing
{
    public interface IPricingRule
    {
        decimal CalculatePrice(IEnumerable<StoreProduct> items);
    }
}
