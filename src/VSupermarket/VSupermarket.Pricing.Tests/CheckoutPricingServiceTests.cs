using VSupermarket.Pricing.Checkout;

namespace VSupermarket.Pricing.Tests
{
    [TestClass]
    public class CheckoutPricingServiceTests :  BasePricingTest
    {
        [TestMethod]
        public void WhenCheckoutBulkItemCalculateTotalShouldBe20()
        {
            var checkout = new CheckoutPricingService();

            var orange = CreateOrangeBulkItemOfferTestCase(3, 1.0m);
            var mango = CreateMangoBuyXFreeXTestCase(0.5m, 2, 1);          

            checkout.Scan(orange);
            checkout.Scan(orange);
            checkout.Scan(orange);
            checkout.Scan(mango);
            checkout.Scan(mango);
            checkout.Scan(mango);

            // Calculate total
            var total = checkout.CalculatePrice();
            Assert.AreEqual(2.0m, total);            
        }
    }
}