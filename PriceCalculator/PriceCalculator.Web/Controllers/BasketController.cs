using PriceCalculator.Dto;
using PriceCalculator.Interfaces;
using PriceCalculator.Web.Interfaces;
using PriceCalculator.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PriceCalculator.Web.Controllers
{
    public class BasketController : ApiController
    {
        private IBasketManager basketManager;
        public BasketController(IBasketManager basketManager)
        {
            this.basketManager = basketManager;
        }

        [HttpPost]
        public BasketTotalViewModel GetTotal([FromBody] BasketViewModel basket)
        {
            return new BasketTotalViewModel
            {
                Total = basketManager.GetTotal(basket)
            };               
        }
    }
}