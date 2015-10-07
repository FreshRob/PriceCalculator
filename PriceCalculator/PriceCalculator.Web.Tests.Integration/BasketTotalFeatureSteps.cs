using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using PriceCalculator.Web.Controllers;
using PriceCalculator.Web.Models;
using PriceCalculator.Web.Module;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace PriceCalculator.Web.Tests.Integration
{
    [Binding]
    public class BasketTotalFeatureSteps
    {
        private List<BasketItemViewModel> basketItems = new List<BasketItemViewModel>();

        [Given(@"The Basket has (.*) Bread")]
        public void GivenTheBasketHasBread(int p0)
        {
            basketItems.Add(new BasketItemViewModel
            {
                ProductId = 3,
                Quantity = p0
            });
        }
        
        [Given(@"The Basket has (.*) Butter")]
        public void GivenTheBasketHasButter(int p0)
        {
            basketItems.Add(new BasketItemViewModel
            {
                ProductId = 1,
                Quantity = p0
            });
        }
        
        [Given(@"The Basket has (.*) Milk")]
        public void GivenTheBasketHasMilk(int p0)
        {
            basketItems.Add(new BasketItemViewModel
            {
                ProductId = 2,
                Quantity = p0
            });
        }
        
        [Then(@"the total should be (.*)")]
        public void ThenTheTotalShouldBe(Decimal p0)
        {
            var kernel = new StandardKernel(new CalculatorModule());
            var controller = kernel.Get<BasketController>();
            var result = controller.GetTotal(new BasketViewModel
            {
                products = basketItems
            });

            Assert.AreEqual(p0, result.Total);
        }
    }
}
