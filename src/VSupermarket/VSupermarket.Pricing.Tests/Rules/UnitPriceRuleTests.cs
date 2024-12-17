using VSupermarket.Pricing.Rules;

namespace VSupermarket.Pricing.Tests.Rules
{
    [TestClass]
    public class UnitPriceRuleTests: BasePricingTest
    {
        [TestMethod]
        public void WhenUnitPriceThenTotalIsAccumulatedItemPrice()
        {
            var unitPricingRule = new UnitPriceRule();
            var products = CreateProduct(PizzaProduct, 1m, 2);

            var total = unitPricingRule.CalculatePrice(products);
            Assert.AreEqual(2m, total);
        }

        [TestMethod]
        public void WhenSingleItemPriceUnitThenTotalIsJustOneUnitPrice()
        {
            var unitPricingRule = new UnitPriceRule();
            var products = CreateProduct(PizzaProduct, 1, 1);

            var total = unitPricingRule.CalculatePrice(products);
            Assert.AreEqual(1m, total);
        }
    }
}
