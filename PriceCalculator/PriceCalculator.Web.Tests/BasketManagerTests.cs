using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PriceCalculator.Dto;
using PriceCalculator.Interfaces;
using PriceCalculator.Web.Businesslogic;
using PriceCalculator.Web.Interfaces;
using PriceCalculator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator.Web.Tests
{
    [TestClass]
    public class BasketManagerTests
    {
        private Mock<IPriceCalculator> priceCalculator;
        private Mock<IProductRepository> productRepository;
        private IBasketManager basketManager;

        [TestInitialize]
        public void Setup()
        {
            priceCalculator = new Mock<IPriceCalculator>();
            productRepository = new Mock<IProductRepository>();
            basketManager = new BasketManager(priceCalculator.Object, productRepository.Object);
        }

        [TestMethod]
        public void GetTotal_NoProducts_0()
        {
            //act
            var result = basketManager.GetTotal(new Models.BasketViewModel());

            //assert
            Assert.AreEqual(0, result);
            productRepository.VerifyAll();
            priceCalculator.VerifyAll();
        }

        [TestMethod]
        public void GetTotal_ProductsWithValidId_Total()
        {
            //arrange
            const decimal price = (decimal)10.1;
            const decimal calculatedPrice = (decimal)11.1;
            const int productId = 1;
            productRepository.Setup(p => p.GetProducts()).Returns(new List<Dto.Product>
            {
                new Dto.Product
                {
                    Id = productId,
                    Price = price
                }
            });

            priceCalculator.Setup(p=>p.GetPrice(It.IsAny<List<BasketProduct>>())).Returns(calculatedPrice);


            //act
            var result = basketManager.GetTotal(new Models.BasketViewModel {
                products = new List<BasketItemViewModel>
                {
                    new BasketItemViewModel
                    {
                        ProductId = 1,
                        Quanity = 3
                    }
                }});

            //assert
            Assert.AreEqual(calculatedPrice, result);
            productRepository.VerifyAll();
            priceCalculator.VerifyAll();
            priceCalculator.Verify(p => p.GetPrice(It.Is<List<BasketProduct>>(
               b => b.Count() == 3 
               && b.First().BasketProductId == "1-0" 
               && b.First().Id == productId 
               && b.First().Price == price)));
        }
    }
}
