using PriceCalculator.Interfaces;
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
        public IList<ProductWithOffer> GetProductsWithOffersAttached(IList<Product> products)
        {
            var productOfferList = products.Select(p => new ProductWithOffer
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
            var milk = products.Select(p => p.Id == (int)ProductId.Milk).Count() / 2;

            if(milk == 0)
            {
                return productOfferList;
            }
            var countBread = 0;
            foreach(var product in productOfferList.Where(p=> p.Id == (int)ProductId.Bread))
            {
                product.OfferPrice = product.Price / 2;
                countBread++;
                if (countBread == milk)
                {
                    return productOfferList;
                }
            }
            return productOfferList;
        }
    }
}
