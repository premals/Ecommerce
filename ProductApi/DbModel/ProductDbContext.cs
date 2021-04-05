using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.DbModel
{
    public class ProductDbContext : DbContext
    {   
        public ProductDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Pendrive", Color = "Black", Price = 50, Sku = "pnBlack"},
                new Product { Id = 2, Name = "Harddisk", Color = "Blue", Price = 80, Sku = "hdBlue" },
                new Product { Id = 3, Name = "Mouse", Color = "Red", Price = 30, Sku = "pnRed" },
                new Product { Id = 4, Name = "Ram", Color = "green", Price = 40, Sku = "rmGreen" },
                new Product { Id = 5, Name = "Keyboard", Color = "Black", Price = 10, Sku = "blackKeyboard" },
                new Product { Id = 6, Name = "Lancable", Color = "yellow", Price = 70, Sku = "lnYellow" },
                new Product { Id = 7, Name = "battery", Color = "Black", Price = 40, Sku = "batteryBlack" },
                new Product { Id = 8, Name = "dockStation", Color = "Black", Price = 50, Sku = "dockBlack" },
                new Product { Id = 9, Name = "Router", Color = "Black", Price = 20, Sku = "RouterBlack" },
                new Product { Id = 10, Name = "Laptop Stand", Color = "Black", Price = 5, Sku = "standBlack" }
                );
        }
    }
}
