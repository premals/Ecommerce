using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.IRepository;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductProvider productProvider;
        public ProductController(
            IProductProvider productProvider)
        {
            this.productProvider = productProvider;
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetProducts()
        {
            var response = await productProvider.GetProductAsync();
            if (response.IsSuccess)
            {
                return Ok(response.Products);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await productProvider.GetProductAsync();
            if (response.IsSuccess)
            {
                var product = response.Products.Where(x => x.Id == id).FirstOrDefault();
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            return NotFound();
        }
    }
}