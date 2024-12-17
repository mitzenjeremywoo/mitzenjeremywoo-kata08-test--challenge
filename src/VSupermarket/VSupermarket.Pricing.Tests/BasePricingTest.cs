using VSupermarket.Pricing.Rules;

namespace VSupermarket.Pricing.Tests
{
    public class BasePricingTest
    {
        public const string OrangeProduct = "Orange";
        public const string MangoProduct = "Mango";
        public const string PizzaProduct = "Pizza";
        
        public static IEnumerable<StoreProduct> CreateProduct(string productName, decimal price, int numberToCreate)
        {
            return Enumerable.Range(1, numberToCreate).Select(index => new StoreProduct(productName, price, null));
        }

        public static StoreProduct CreateOrangeBulkItemOfferTestCase(int qty, decimal price)
        {
            var apple = new StoreProduct(OrangeProduct, 1.00m, new List<IPricingRule>()
            {
                new BulkBuyDiscountRule(qty, price)
            });

            return apple;
        }

        public static StoreProduct CreateMangoBuyXFreeXTestCase(decimal price, int buyQty, int freeQty)
        {
            return new StoreProduct(MangoProduct, price, new List<IPricingRule>()
            {
                new BuyXGetYFreeRule(buyQty, freeQty)
            });
        }

        public static StoreProduct CreateUnitItemTestCase(decimal price)
        {
            return new StoreProduct(MangoProduct, price, new List<IPricingRule>()
            {
                new UnitPriceRule()
            });
        }
    }
}