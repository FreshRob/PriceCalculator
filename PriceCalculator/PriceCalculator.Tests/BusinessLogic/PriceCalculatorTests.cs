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
        private Mock<IOfferRepository> offerRepository;
        private Mock<IOffer> offer1;
        [TestInitialize]
        public void Setup()
        {
            offer1 = new Mock<IOffer>();
            offerRepository = new Mock<IOfferRepository>();
            priceCalculator = new PriceCalculator.BusinessLogic.PriceCalculator(offerRepository.Object);
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

            offerRepository.Setup(o => o.GetOffers()).Returns(new List<IOffer> { offer1.Object });

            offer1.Setup(o => o.GetProductsWithOffersAttached(It.IsAny<IList<BasketProduct>>())).Returns(new List<BasketProductWithOffer>());

            //act
            var result = priceCalculator.GetPrice(new List<BasketProduct> { productsInBacket });

            //assert
            Assert.AreEqual(productsInBacket.Price, result);
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

            offerRepository.Setup(o => o.GetOffers()).Returns(new List<IOffer> { offer1.Object });

            offer1.Setup(o => o.GetProductsWithOffersAttached(It.IsAny<IList<BasketProduct>>())).Returns(new List<BasketProductWithOffer>
            {
               basketWithOffer
            });

            //act
            var result = priceCalculator.GetPrice(new List<BasketProduct> { productsInBacket });

            //assert
            Assert.AreEqual(basketWithOffer.OfferPrice, result);
        }
    }
}
