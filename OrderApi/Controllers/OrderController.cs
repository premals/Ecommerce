using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderApi.IProfile;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProfile orderProfile;
        private readonly ILogger<OrderController> logger;

        public OrderController(
            IOrderProfile orderProfile,
            ILogger<OrderController> logger)
        {
            this.orderProfile = orderProfile;
            this.logger = logger;
        }

        [HttpGet("Orders/{customerId}")]
        public async Task<IActionResult> GetOrders(int customerId)
        {
            var result = await orderProfile.GetOrdersAsync(customerId);
            logger.LogInformation("order api call is started.");
            if (result.IsSuccess)
            {
                logger.LogInformation("order api call is get the result of order.");
                return Ok(result.orders);
            }

            logger.LogInformation("order detail is not found for given  customer id.");
            return NotFound();
        }
    }
}