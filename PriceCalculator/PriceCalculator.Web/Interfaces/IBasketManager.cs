using PriceCalculator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator.Web.Interfaces
{
    public interface IBasketManager
    {
        decimal GetTotal(BasketViewModel basketTotalViewModel);
    }
}
