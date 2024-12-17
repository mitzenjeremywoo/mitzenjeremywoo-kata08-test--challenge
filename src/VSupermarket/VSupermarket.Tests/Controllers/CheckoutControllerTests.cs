using Moq;
using Moq.AutoMock;
using VSupermarket.Calculate;
using VSupermarket.Controllers;
using VSupermarket.Model;

namespace VSupermarket.Tests
{
    [TestClass]
    public class CheckoutControllerTests: BaseTests
    {
        [TestMethod]
        public void WhenCheckoutControllerGetTotalCalculateTotals()
        {
            const decimal total = 100m; 
            var mocker = new AutoMocker();
            var controller = mocker.CreateInstance<CheckoutController>();
            mocker.GetMock<IWebCheckoutCalculator>().Setup(x => x.Calculate(It.IsAny<WebProductMessage>())).Returns(total);

            // Act 
            var result = controller.Calculate(CreateMultipleWebProductMessage());
            // Assert
            Assert.AreEqual(result, total);
        }
    }
}