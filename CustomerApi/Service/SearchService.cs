using CustomerApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Service
{
    public class SearchService : ISearchService
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;

        public SearchService(
            IOrderService orderService,
            IProductService productService)
        {
            this.orderService = orderService;
            this.productService = productService;
        }

        public async Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(int customerId)
        {
            var orderResult = await orderService.GetOrderAsync(customerId);
            if (orderResult.IsSuccess)
            {
                foreach(var order in orderResult.orders)
                {
                    foreach(var item in order.OrderItems)
                    {
                        var productResult = await productService.GetProductAsync(item.ProductId);
                        if (productResult.IsSuccess)
                        {
                            item.ProductName = productResult.product.Name;
                        }
                    }
                    
                }
                
                return (true, orderResult.orders);
            }

            return (false, null);
        }
    }
}
