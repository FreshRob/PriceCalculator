﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceCalculator.Interfaces;
using PriceCalculator.BusinessLogic.Offers;
using System.Collections.Generic;
using System.Linq;
using PriceCalculator.Dto;

namespace PriceCalculator.Tests.BusinessLogic.Offers
{
    [TestClass]
    public class BreadOfferTests
    {
        private IOffer offer;

        [TestInitialize]
        public void Setup()
        {
            offer = new BreadOffer();
        }

        [TestMethod]
        public void GetProductsWithOffersAttached_2Butters1Bread_Bread50PercentOff()
        {
            //rrange
            var products = new List<BasketProduct>
            {
                new BasketProduct
                {
                    BasketProductId = "1-1",
                    Id = 1,
                    Name = "Butter",
                    Price = 1
                },
                 new BasketProduct
                {
                    BasketProductId = "1-1",
                    Id = 1,
                    Name = "Butter",
                    Price = 1
                },
                  new BasketProduct
                {
                    BasketProductId = "1-1",
                    Id = 3,
                    Name = "Bread",
                    Price = 1
                }
            };

            //act
            var result = offer.GetProductsWithOffersAttached(products);

            //act
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result.Count(r => !r.OfferPrice.HasValue), 2);
            Assert.AreEqual(result[2].OfferPrice.Value, products[2].Price / 2);
        }

        [TestMethod]
        public void GetProductsWithOffersAttached_1Butters1Bread_NoDiscount()
        {
            //rrange
            var products = new List<BasketProduct>
            {
                new BasketProduct
                {
                    BasketProductId = "1-1",
                    Id = 1,
                    Name = "Butter",
                    Price = 1
                },
                  new BasketProduct
                {
                    BasketProductId = "3-1",
                    Id = 3,
                    Name = "Bread",
                    Price = 1
                }
            };

            //act
            var result = offer.GetProductsWithOffersAttached(products);

            //act
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result.Count(r => !r.OfferPrice.HasValue));
            Assert.IsNull(result[1].OfferPrice);
        }
    }
}
