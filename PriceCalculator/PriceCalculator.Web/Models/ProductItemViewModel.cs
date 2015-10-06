using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriceCalculator.Web.Models
{
    public class ProductItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}