using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator.Dto
{
    public class BasketProductWithOffer : BasketProduct
    {
        public decimal? OfferPrice { get; set; }
    }
}
