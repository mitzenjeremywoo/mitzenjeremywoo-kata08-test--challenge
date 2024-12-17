using Moq.AutoMock;
using VSupermarket.Controllers;

namespace VSupermarket.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void GetProductsTest()
        {
            var mocker = new AutoMocker();
            var controller = mocker.CreateInstance<HomeController>();

            var result = controller.GetProducts();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 3);
        }
    }
}