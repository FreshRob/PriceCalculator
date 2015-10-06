using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Dto;
using PriceCalculator.Interfaces;

namespace PriceCalculator.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Butter",
                    Price = (decimal)0.8
                },
                new Product
                {
                    Id = 2,
                    Name = "Milk",
                    Price = (decimal)1.15,
                },
                new Product
                {
                    Id = 3,
                    Name = "Bread",
                    Price = (decimal)1.00
                }
            };
        }
    }
}
