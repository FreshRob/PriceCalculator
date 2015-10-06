using PriceCalculator.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PriceCalculator.Web.Models;
using PriceCalculator.Interfaces;
using PriceCalculator.Dto;

namespace PriceCalculator.Web.Businesslogic
{
    public class BasketManager : IBasketManager
    {
        private IPriceCalculator priceCalculator;
        private IProductRepository productRepository;

        public BasketManager(IPriceCalculator priceCalculator, IProductRepository productRepository)
        {
            this.priceCalculator = priceCalculator;
            this.productRepository = productRepository;
        }

        public decimal GetTotal(BasketViewModel basketTotalViewModel)
        {
            if (basketTotalViewModel.products == null || !basketTotalViewModel.products.Any())
            {
                return  0;
            }

            var basketItems = new List<BasketProduct>();
            var products = productRepository.GetProducts();

            foreach (var basketProduct in basketTotalViewModel.products)
            {
                if (basketProduct.Quantity < 1)
                {
                    continue;
                }

                var product = products.Where(p => p.Id == basketProduct.ProductId).FirstOrDefault();

                if (product == null)
                {
                    continue;
                }

                for (var i = 0; i < basketProduct.Quantity; i++)
                {
                    basketItems.Add(new BasketProduct
                    {
                        Price = product.Price,
                        Id = product.Id,
                        Name = product.Name,
                        BasketProductId = string.Format("{0}-{1}", product.Id, i)
                    });
                }              
            }
            return priceCalculator.GetPrice(basketItems);
        }
    }
}