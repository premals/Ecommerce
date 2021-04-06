using CustomerApi.Interfaces;
using CustomerApi.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerApi.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<ProductService> logger;

        public ProductService(
            IHttpClientFactory httpClientFactory,
            ILogger<ProductService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess,Product product , string Errormsg)> GetProductAsync(int productid)
        {
            var client = httpClientFactory.CreateClient("ProductService");
            var response = await client.GetAsync($"api/Product/{productid}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Product>(content);
                return (true, result, string.Empty);
            }

            return (false, null, "Not Found");
        }
    }
}
