﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriceCalculator.Web.Models
{
    public class BasketItemViewModel
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}