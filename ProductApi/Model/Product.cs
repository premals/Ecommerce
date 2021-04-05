using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sku { get; set; }

        public decimal Price { get; set; }

        public string Color { get; set; }
    }
}
