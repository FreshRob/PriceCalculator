using PriceCalculator.Interfaces;
using PriceCalculator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PriceCalculator.Web.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET api/<controller>
        public ProductViewModel Get()
        {
            return new ProductViewModel
            {
                Products = productRepository.GetProducts().Select(p => new ProductItemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
            };
        }
    }
}