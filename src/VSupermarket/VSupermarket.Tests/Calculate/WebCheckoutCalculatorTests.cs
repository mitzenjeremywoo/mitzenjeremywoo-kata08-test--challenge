using VSupermarket.Calculate;

namespace VSupermarket.Tests.Calculate
{
    [TestClass]
    public class WebCheckoutCalculatorTests: BaseTests
    {
        [TestMethod]
        public void WhenBuy3For5DiscountDoesNotMeetCriteriaThenTotalCorrectCalculated()
        {
            var target = new WebCheckoutCalculator();

            var result = target.Calculate(CreateSingleAppleItem());
            // Assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void WhenBuy3For5DiscountThenEnsureTotalCorrect()
        {
            var target = new WebCheckoutCalculator();

            var result = target.Calculate(CreateThreeAppleItem());
            // Assert
            Assert.AreEqual(result, 5);
        }


        [TestMethod]
        public void WhenBuy2Free1ThenEnsureTotalCorrect()
        {
            var target = new WebCheckoutCalculator();

            var result = target.Calculate(CreateThreeAppleItem());
            // Assert
            Assert.AreEqual(result, 5);
        }
    }
}
