using Microsoft.AspNetCore.Mvc;
using VSupermarket.Model;
using VSupermarket.Pricing;

namespace VSupermarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<WebProductModel> GetProducts()
        {
            return new List<WebProductModel>
            {
                new WebProductModel {

                    Id = "Apple",
                    Name = "Apple",
                    UnitPrice = 1m,
                    Special = new DiscountType
                    {
                         FreeQuantity = 3,
                         Quantity = 3,
                         Type = AppConstant.BulkBuyOfferType,
                         Price = 5m
                    },
                },
                new WebProductModel {

                    Id = "Orange",
                    Name = "Orange", UnitPrice = 1.5m,
                    Special = new DiscountType
                    {
                         FreeQuantity = 1,
                         Quantity = 2,
                         Type = AppConstant.BuyXGetYFreeOfferType
                    },
                },
                new WebProductModel {
                    Id = "Banana",
                    Name = "Banana", UnitPrice = 1m,
                    Special = new DiscountType
                    {
                         Type = AppConstant.UnitPriceOfferType
                    },
                }
            };
        }
    }
}
