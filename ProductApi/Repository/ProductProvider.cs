using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductApi.DbModel;
using ProductApi.IRepository;
using ProductApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Repository
{
    /// <summary>
    /// Get the information about product.
    /// </summary>
    public class ProductProvider : IProductProvider
    {
        private readonly ProductDbContext productDbContext;
        private readonly ILogger<ProductProvider> logger;

        public ProductProvider(
            ProductDbContext productDbContext,
            ILogger<ProductProvider> logger)
        {
            this.productDbContext = productDbContext;
            this.logger = logger;
        }

        #region

        /// <summary>
        /// This method is used to get the information of product
        /// </summary>
        /// <params></params>
        /// <returns>IsSuccess, Products, Errormsg</returns>

        public async Task<(bool IsSuccess, IEnumerable<Model.Product> Products, string Errormsg)> GetProductAsync()
        {
            try
            {
                logger.LogInformation("Start the call of get productmethod");
                var products = await productDbContext.Products
                .Select(x => new Model.Product
                {
                    Color = x.Color,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Sku = x.Sku
                })
                .ToListAsync();

                if (products.Any())
                {
                    logger.LogInformation("Products retrive successfully.", products);
                    return (true, products, string.Empty);
                }


                return (false, null, "Not Found");
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message.ToString(), ex.Message);
                return (false, null, ex.Message);
            }
        }

        #endregion
    }
}