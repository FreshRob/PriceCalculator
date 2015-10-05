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
        public IList<ProductWithOffer> GetProductsWithOffersAttached(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }
    }
}
