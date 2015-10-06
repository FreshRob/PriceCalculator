using PriceCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator.Infrastructure
{
    public class OfferRepository : IOfferRepository
    {
        private readonly List<IOffer> offers;
        public OfferRepository(List<IOffer> offers)
        {
            this.offers = offers;
        }

        public IList<IOffer> GetOffers()
        {
            return offers;
        }
    }
}
