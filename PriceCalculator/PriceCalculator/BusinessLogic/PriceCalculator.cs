﻿using PriceCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Dto;

namespace PriceCalculator.BusinessLogic
{
    public class PriceCalculator : IPriceCalculator
    {
        private IOfferRepository offerRepository;
        public PriceCalculator(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public decimal GetPrice(IEnumerable<BasketProduct> products)
        {
            var productList = products.ToList();
            var priceChanges = offerRepository.GetOffers().SelectMany(o => o.GetProductsWithOffersAttached(productList)).Where(p=>p.OfferPrice.HasValue);

            if (!priceChanges.Any())
            {
                return productList.Sum(p => p.Price);
            }

            return (from product in productList
             join priceChange in priceChanges on product.BasketProductId equals priceChange.BasketProductId into tempForLeftJoin
             from joinedArray in tempForLeftJoin.DefaultIfEmpty()
             select joinedArray == null ? product.Price : joinedArray.OfferPrice.Value).Sum();           
        }
    }
}
