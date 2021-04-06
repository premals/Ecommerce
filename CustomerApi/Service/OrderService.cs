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
    public class OrderService : IOrderService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<OrderService> logger;

        public OrderService(
            IHttpClientFactory httpClientFactory,
            ILogger<OrderService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<Order> orders, string Errormsg)> GetOrderAsync(int customerid)
        {
            try
            {
                var client = httpClientFactory.CreateClient("OrderService");
                var response = await client.GetAsync($"api/order/orders/{customerid}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<IEnumerable<Order>>(content);
                    return (true, result, string.Empty);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }

            throw new NotImplementedException();
        }
    }
}