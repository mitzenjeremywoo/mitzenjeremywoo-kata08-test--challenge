using VSupermarket.Model;
using VSupermarket.Pricing;

namespace VSupermarket.Tests
{
    public class BaseTests
    {
        public WebProductMessage CreateMultipleWebProductMessage()
        {
            return new WebProductMessage
            {
                Items = new List<WebProductModel>
                {
                    new WebProductModel {

                        Id = "Apple",
                        Name = "Apple",
                        UnitPrice = 1m,
                        OrderQuantity = 1,
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
                }
             };
        }

        public WebProductMessage CreateSingleAppleItem()
        {
            return new WebProductMessage
            {
                Items = new List<WebProductModel>
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
                    }
                }
            };
        }

        public WebProductMessage CreateSingleBuy3Free1Item()
        {
            return new WebProductMessage
            {
                Items = new List<WebProductModel>
                {
                    new WebProductModel {

                        Id = "Apple",
                        Name = "Apple",
                        UnitPrice = 1m,
                        Special = new DiscountType
                        {
                             FreeQuantity = 1,
                             Quantity = 3,
                             Type = AppConstant.BuyXGetYFreeOfferType,
                             Price = 5m
                        },
                    }
                }
            };
        }



        public WebProductMessage CreateThreeAppleItem()
        {
            return new WebProductMessage
            {
                Items = new List<WebProductModel>
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
                    }
                }
            };
        }
    }
}
