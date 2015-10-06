using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriceCalculator.Web.Models
{
    public class ProductViewModel
    {
        public IEnumerable<ProductItemViewModel> Products { get; set; }
    }
}