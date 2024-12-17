using VSupermarket.Pricing.Rules;

namespace VSupermarket.Pricing.Tests.Rules
{
    [TestClass]
    public class BulkDiscountRuleTests : BasePricingTest
    {
        [TestMethod]
        public void WhenBulkItemCalculateTotalThenPriceIs5()
        {
            var buy2Get1Free = new BulkBuyDiscountRule(3, 5);  // Buy 3 at 5.00 
            var products = CreateProduct(PizzaProduct, 5m, 3); // Create 3 item

            var total = buy2Get1Free.CalculatePrice(products);
            Assert.AreEqual(5m, total);
        }

        [TestMethod]
        public void WhenBulkItemWithOneExtraItemCalculateTotalThenPriceIs10()
        {
            var buy2Get1Free = new BulkBuyDiscountRule(3, 5);  // Buy 3 at 5.00
            var products = CreateProduct(PizzaProduct, 5m, 4); // Create 4 products

            var total = buy2Get1Free.CalculatePrice(products);
            Assert.AreEqual(10m, total);
        }

        [TestMethod]
        public void WhenBulkItemWithOneFreeDidnotMeetAmountCriteriaThenNoDiscount()
        {
            var buy2Get1Free = new BulkBuyDiscountRule(3, 5);  // Buy 3 at 5.00
            var products = CreateProduct(PizzaProduct, 3m, 2); // Create 2 products

            var total = buy2Get1Free.CalculatePrice(products);
            Assert.AreEqual(6m, total);
        }
    }
}
