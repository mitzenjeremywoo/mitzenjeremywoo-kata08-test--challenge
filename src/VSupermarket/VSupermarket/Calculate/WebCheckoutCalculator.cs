using VSupermarket.Model;
using VSupermarket.Pricing;
using VSupermarket.Pricing.Checkout;
using VSupermarket.Pricing.Rules;

namespace VSupermarket.Calculate
{
    public class WebCheckoutCalculator : IWebCheckoutCalculator
    {
        public decimal Calculate(WebProductMessage products)
        {
            decimal total = 0m;

            var checkout = new CheckoutPricingService();

            foreach (var product in products.Items)
            {
                // Get the pricing rule 
                IList<IPricingRule> pricingRules = product.Special.Type switch
                {
                    var s when s.ToLowerInvariant().Equals(AppConstant.BulkBuyOfferType) => new List<IPricingRule>()
                                                       { new BulkBuyDiscountRule(product.Special.Quantity, product.Special.Price) },
                    var s when s.ToLowerInvariant().Equals(AppConstant.BuyXGetYFreeOfferType) => new List<IPricingRule>()
                                                       { new BuyXGetYFreeRule(product.Special.Quantity, product.Special.FreeQuantity) },
                    _ => new List<IPricingRule>() { new UnitPriceRule() }
                };

                // create the product 
                var storeProduct = new StoreProduct(product.Name, product.UnitPrice, pricingRules);
                // calculate total
                checkout.Scan(storeProduct);
            }

            return checkout.CalculatePrice();
        }
    }
}
