namespace VSupermarket.Pricing.Rules
{
    /// <summary>
    /// This is specifically for Bulk buy specials.
    /// 
    /// </summary>
    public class BulkBuyDiscountRule : IPricingRule
    {
        private readonly int _quantity;
        private readonly decimal _discountPrice;
        
        public BulkBuyDiscountRule(int quantity, decimal discountPrice)
        {
            _quantity = quantity;
            _discountPrice = discountPrice;
        }

        public decimal CalculatePrice(IEnumerable<StoreProduct> items)
        {
            var itemCount = items.Count();
            var discountBundles = itemCount / _quantity;
            var remainingItems = itemCount % _quantity;

            return (discountBundles * _discountPrice) + (remainingItems * items.First().Price);
        }
    }
}
