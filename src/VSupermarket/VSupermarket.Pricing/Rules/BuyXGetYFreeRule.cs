namespace VSupermarket.Pricing.Rules
{
    public class BuyXGetYFreeRule : IPricingRule
    {
        private readonly int _buyQuantity;
        private readonly int _freeProductQuantity;

        public BuyXGetYFreeRule(int buyQuantity, int freeProductQuantity)
        {
            _buyQuantity = buyQuantity;
            _freeProductQuantity = freeProductQuantity;
        }

        public decimal CalculatePrice(IEnumerable<StoreProduct> items)
        {
            var itemCount = items.Count();
            // this is integer so no fraction 
            var finalPriceWithDiscountApplied = itemCount - (itemCount / (_buyQuantity + _freeProductQuantity) * _freeProductQuantity);

            return finalPriceWithDiscountApplied * items.First().GetPrice();
        }
    }
}
