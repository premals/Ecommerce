using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderApi.DbClasses;
using OrderApi.IProfile;
using OrderApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Profile
{
    /// <summary>
    /// This is used to represent the order data.
    /// </summary>
    public class OrderProfile : IOrderProfile
    {
        private readonly OrderDbContext _orderDbContext;
        private readonly ILogger<OrderProfile> logger;

        public OrderProfile(
            OrderDbContext orderDbContext,
            ILogger<OrderProfile> logger)
        {
            this._orderDbContext = orderDbContext;
            this.logger = logger;
        }

        #region
        /// <summary>
        /// This method is used to get data related order.
        /// </summary>
        /// <returns>IsSuccess, orders and errormsg</returns>
        public async Task<(bool IsSuccess, IEnumerable<Model.Order> orders, string Errormsg)> GetOrdersAsync(int customerId)
        {
            try
            {
                var orders = await _orderDbContext.Orders
                    .Where(x => x.CustomerId == customerId)
                    .Select(
                x => new Model.Order
                {
                    CustomerId = x.CustomerId,
                    Id = x.Id,
                    OrderDate = x.OrderDate,
                    OrderItems = GetOrderItems(x.OrderItems.ToList()),
                    Total = x.Total
                }).ToListAsync();

                if (orders != null && orders.Any())
                {
                    logger.LogInformation("The order api retrieved data sucessfully.");
                    return (true, orders, string.Empty);
                }

                logger.LogInformation("The order list is empty");
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }


        private IEnumerable<Model.OrderItems> GetOrderItems(List<DbEntity.OrderItem> items)
        {
            var itemList = new List<Model.OrderItems>();
            foreach (var item in items)
            {
                var orderItem = new Model.OrderItems()
                {
                    Id = item.Id,
                    OrderId = item.OrderId,
                    ProductId = item.OrderId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                };

                itemList.Add(orderItem);
            }

            return itemList;
        }
        #endregion


    }
}