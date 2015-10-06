using Ninject.Modules;
using PriceCalculator.Infrastructure;
using PriceCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PriceCalculator.BusinessLogic.Offers;

namespace PriceCalculator.Web.Module
{
    public class CalculatorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IPriceCalculator>().To<PriceCalculator.BusinessLogic.PriceCalculator>();
            Bind<IOffer>().To<BreadOffer>();
            Bind<IOffer>().To<MilkOffer>();
        }
    }
}