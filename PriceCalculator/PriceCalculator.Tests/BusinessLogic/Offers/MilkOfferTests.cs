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
            var products = new List<Product>
            {
                new Product
                {
                    Id = 2,
                    Name = "Milk",
                    Price = 1
                },
                 new Product
                {
                    Id = 2,
                    Name = "Milk",
                    Price = 1
                },
                 new Product
                {
                    Id = 2,
                    Name = "Milk",
                    Price = 1
                },
                 new Product
                {
                    Id = 2,
                    Name = "Milk",
                    Price = 1
                }
            };

            //act
            var result = offer.GetProductsWithOffersAttached(products);

            //act
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual(result.Count(r => !r.OfferPrice.HasValue), 3);
            Assert.AreEqual(result[3].OfferPrice.Value, (decimal) 0);
        }
    }
}
