using PriceCalculator.Interfaces;
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
        private IList<IOffer> offers;
        public PriceCalculator(IList<IOffer> offers)
        {
            this.offers = offers;
        }

        public decimal GetPrice(IEnumerable<BasketProduct> products)
        {
            throw new NotImplementedException();
        }
    }
}
