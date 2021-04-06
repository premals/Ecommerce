using CustomerApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Interfaces
{
    public interface IProductService
    {
        Task<(bool IsSuccess, Product product, string Errormsg)> GetProductAsync(int productid);
    }
}
