﻿using PriceCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Dto;

namespace PriceCalculator.BusinessLogic.Offers
{
    public class BreadOffer : IOffer
    {
        public IList<BasketProductWithOffer> GetProductsWithOffersAttached(IList<BasketProduct> products)
        {
            var productOfferList = products.Select(p => new BasketProductWithOffer
            {
                BasketProductId = p.BasketProductId,
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            var numberOfBreadTheOfferCanBeAppliedTo =  Math.Floor(products.Where(p => p.Id == (int)ProductId.Butter).Count() / 2.0);

            if(numberOfBreadTheOfferCanBeAppliedTo == 0)
            {
                return productOfferList;
            }
            var countBread = 0;
            foreach(var product in productOfferList.Where(p=> p.Id == (int)ProductId.Bread))
            {
                product.OfferPrice = product.Price / 2;
                countBread++;
                if (countBread == numberOfBreadTheOfferCanBeAppliedTo)
                {
                    return productOfferList;
                }
            }
            return productOfferList;
        }
    }
}
