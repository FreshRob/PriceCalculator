using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PriceCalculator.Interfaces;
using PriceCalculator.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Dto;

namespace PriceCalculator.Tests.BusinessLogic
{
    [TestClass]
    public class PriceCalculatorTests
    {
        private IPriceCalculator priceCalculator;
        private Mock<IOffer> Offer1;
        [TestInitialize]
        public void Setup()
        {
            Offer1 = new Mock<IOffer>();            
            priceCalculator = new PriceCalculator.BusinessLogic.PriceCalculator(new List<IOffer> { Offer1.Object });
        }

        [TestMethod]
        public void GetPrice_NoOffersApplied_TotalSameAsProductValue()
        {
            //arrange
            var productsInBacket = new BasketProduct
            {
                BasketProductId = "1-1",
                Price = 10
            };
            
            Offer1.Setup(o => o.GetProductsWithOffersAttached(It.IsAny<IList<BasketProduct>>())).Returns(new List<BasketProductWithOffer>());

            //act
            var result = priceCalculator.GetPrice(new List<BasketProduct> { productsInBacket });

            //assert
            Assert.AreEqual(result, productsInBacket.Price);
        }

        [TestMethod]
        public void GetPrice_OfferApplied_SumWithDiscount()
        {
            //arrange
            var productsInBacket = new BasketProduct
            {
                BasketProductId = "1-1",
                Price = 10
            };

            var basketWithOffer = new BasketProductWithOffer
            {
                BasketProductId = "1-1",
                OfferPrice = 8
            };

            Offer1.Setup(o => o.GetProductsWithOffersAttached(It.IsAny<IList<BasketProduct>>())).Returns(new List<BasketProductWithOffer>
            {
                
            });

            //act
            var result = priceCalculator.GetPrice(new List<BasketProduct> { productsInBacket });

            //assert
            Assert.AreEqual(result, basketWithOffer);
        }
    }
}
