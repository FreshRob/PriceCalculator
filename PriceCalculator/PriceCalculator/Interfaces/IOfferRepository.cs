﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator.Interfaces
{
    public interface IOfferRepository
    {
        IList<IOffer> GetOffers();
    }
}
