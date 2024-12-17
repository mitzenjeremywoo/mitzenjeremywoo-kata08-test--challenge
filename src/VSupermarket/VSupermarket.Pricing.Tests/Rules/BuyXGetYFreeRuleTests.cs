using VSupermarket.Pricing.Rules;

namespace VSupermarket.Pricing.Tests.Rules
{
    [TestClass]
    public class BuyXGetYFreeRuleTests : BasePricingTest
    {
        [TestMethod]
        public void WhenOffterItemMeetCriteriaThenDiscountApplied()
        {
            var buy2Get1Free = new BuyXGetYFreeRule(2, 1);     // Buy 2, free 1 
            var products = CreateProduct(PizzaProduct, 1m, 3); // 3 item added into trolley

            var total = buy2Get1Free.CalculatePrice(products);
            Assert.AreEqual(2m, total);
        }

        [TestMethod]
        public void WhenOfferDoesNotMeetCriteria()
        {
            var buy2Get1Free = new BuyXGetYFreeRule(2, 1);     // Buy 2, free 1 
            var products = CreateProduct(PizzaProduct, 1m, 1); // 1 item added into trolley

            var total = buy2Get1Free.CalculatePrice(products);
            Assert.AreEqual(1m, total);
        }
    }
}
