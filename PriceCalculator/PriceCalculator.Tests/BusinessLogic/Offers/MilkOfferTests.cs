using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceCalculator.Interfaces;
using PriceCalculator.BusinessLogic.Offers;
using System.Collections.Generic;
using System.Linq;
using PriceCalculator.Dto;

namespace PriceCalculator.Tests.BusinessLogic.Offers
{
    [TestClass]
    public class MilkOfferTests
    {
        private IOffer offer;

        [TestInitialize]
        public void Setup()
        {
            offer = new MilkOffer();
        }

        [TestMethod]
        public void GetProductsWithOffersAttached_3Milk_Get4thFree()
        {
            //rrange
            var products = new List<BasketProduct>
            {
                new BasketProduct
                {
                    Id = 2,
                    Name = "Milk",
                    Price = 1
                },
                 new BasketProduct
                {
                    Id = 2,
                    Name = "Milk",
                    Price = 1
                },
                 new BasketProduct
                {
                    Id = 2,
                    Name = "Milk",
                    Price = 1
                },
                 new BasketProduct
                {
                    BasketProductId = "1-4",
                    Id = 2,
                    Name = "Milk",
                    Price = 1
                }
            };

            //act
            var result = offer.GetProductsWithOffersAttached(products);

            //act
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(3, result.Count(r => !r.OfferPrice.HasValue));
            Assert.AreEqual((decimal) 0, result[3].OfferPrice.Value);
            Assert.AreEqual(products[3].BasketProductId, result[3].BasketProductId);
            Assert.AreEqual(products[3].Name, result[3].Name);
            Assert.AreEqual(products[3].Price, result[3].Price);
            Assert.AreEqual(products[3].Id, result[3].Id);
        }
    }
}
