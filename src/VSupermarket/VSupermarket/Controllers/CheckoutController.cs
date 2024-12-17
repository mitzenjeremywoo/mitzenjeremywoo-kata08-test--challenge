using Microsoft.AspNetCore.Mvc;
using VSupermarket.Calculate;
using VSupermarket.Model;

namespace VSupermarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {        
        private readonly ILogger<CheckoutController> _logger;
        private readonly IWebCheckoutCalculator _service;
        public CheckoutController(ILogger<CheckoutController> logger, IWebCheckoutCalculator service)
        {
            _logger = logger;
            _service = service; 
        }

        [HttpPost("calculate")]
        public decimal Calculate(WebProductMessage products)
        {
            return _service.Calculate(products);
        }
    }
}