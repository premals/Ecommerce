using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.IRepository
{
    public interface IProductProvider
    {
        Task<(bool IsSuccess, IEnumerable<Model.Product> Products, string Errormsg)> GetProductAsync();
    }
}
