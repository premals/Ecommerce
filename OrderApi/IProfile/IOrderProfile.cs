using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.IProfile
{
    public interface IOrderProfile
    {
        Task<(bool IsSuccess, IEnumerable<Model.Order> orders, string Errormsg)> GetOrdersAsync(int customerId);
    }
}
