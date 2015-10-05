using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Dto;
using PriceCalculator.Interfaces;

namespace PriceCalculator.Infrastructure
{
    class ProductRepository : IProductRepository
    {
        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
