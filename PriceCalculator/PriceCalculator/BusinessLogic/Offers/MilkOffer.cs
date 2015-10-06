using PriceCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Dto;

namespace PriceCalculator.BusinessLogic.Offers
{
    public class MilkOffer : IOffer
    {
        public IList<ProductWithOffer> GetProductsWithOffersAttached(IList<Product> products)
        {
            var productOfferList = products.Select(p => new ProductWithOffer
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            const int numberOfMilkToGetTheOffer = 4;

            var numberOfMilkTheOfferCanBeAppledTo = products.Select(p => p.Id == (int)ProductId.Milk).Count() / numberOfMilkToGetTheOffer;

            if (numberOfMilkTheOfferCanBeAppledTo == 0)
            {
                return productOfferList;
            }
            var countMilkForOffer = 0;
            var countMilkToIgnore = 0;
            foreach (var product in productOfferList.Where(p => p.Id == (int)ProductId.Milk))
            {
                countMilkToIgnore++;

                if (countMilkToIgnore != numberOfMilkToGetTheOffer)
                {
                    continue;
                }

                countMilkForOffer++;
                product.OfferPrice = 0;
                countMilkToIgnore = 0;


                if (countMilkForOffer == numberOfMilkTheOfferCanBeAppledTo)
                {
                    return productOfferList;
                }
            }
            return productOfferList;
        }
    }
}
