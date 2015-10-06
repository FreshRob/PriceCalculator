using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriceCalculator.Web.Models
{
    public class BasketViewModel
    {
        public IEnumerable<BasketItemViewModel> products { get; set; }
    }
}