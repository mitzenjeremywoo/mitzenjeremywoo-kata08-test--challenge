using VSupermarket.Model;

namespace VSupermarket.Calculate
{
    public interface IWebCheckoutCalculator
    {
        decimal Calculate(WebProductMessage products);
    }
}
